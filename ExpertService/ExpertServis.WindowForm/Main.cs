using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab.Buttons;
using ExpertService.Data;
using ExpertService.Model;
using ExpertServis.WindowForm.Forms;
using ExpertServis.WindowForm.Rapor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExpertServis.WindowForm.DxHelper;

namespace ExpertServis.WindowForm
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public UserTable User { get; set; }
        public static Main MainForm;
        public Dosya ÇalışmaDosyası { get; set; }
        public Main(UserTable user)
        {
            User = user;
            InitializeComponent();
            MainForm = this;

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            ElementDosyaParent.Elements.Clear();
            ElementParentTalepler.Elements.Clear();
            ElementParentUcretBilgileri.Elements.Clear();
            ElementParentÇalışmaDönemi.Elements.Clear();
            ElementParentKıdemTaz.Elements.Clear();
            Container.Controls.Clear();
            //Container.AddControl(new Forms.İhbarTazminatıForm());

            ElementTest.HeaderControl = simpleButton2;
            ÇalışmaDosyası = null;
            DosyaDoldur();
        }


        public void DosyaDoldur(Func<Dosya, bool> prediticate = null)
        {

            var element = ElementDosyaParent;
            element.Elements.Clear();

            User.Dosya?
                .Where(x => x.AnaDosyaID == null && x.isActive)
                .Where(prediticate == null ? a => true : prediticate)
                .Where(x => x.isActive)
                .OrderBy(x => x.AnaDosyaID)
                .ForEach(x =>
            {
                var yeni = new AccordionControlElement()
                {
                    Image = GetImage(ElementTipi.dosyachild),
                    //Style = x.EkDosya?.Count > 0 ? ElementStyle.Group : ElementStyle.Item,
                    Style = ElementStyle.Group,
                    Tag = x,
                    Text = $"{x.Adı } {x.Soyadı }-{x.DavaTarihi.ToShortDateString()}"
                    //Text = $"{x.Adı } {x.Soyadı }"

                };
                element.Elements.Add(yeni);
                yeni.Click += Element_Click;
                DosyalarıDoldur(x, yeni);
            });
        }
        void DosyalarıDoldur(Dosya dossya, AccordionControlElement element)
        {
            if (dossya.EkDosya == null) return;
            var ekdosyalar = dossya.EkDosya
                .Where(x => x.isActive)
                .ToList();
            foreach (var x in ekdosyalar)
            {

                var yeni = new AccordionControlElement()
                {
                    Image = GetImage(ElementTipi.EkDosya),
                    //Style = x.EkDosya?.Count  == 0 ? ElementStyle.Item : ElementStyle.Group,
                    Style = ElementStyle.Group,

                    Tag = x,
                    Text = $"{x.Adı } {x.Soyadı }-{x.DavaTarihi.ToShortDateString()}",

                };

                element.Elements.Add(yeni);
                yeni.Click += Element_Click;
                if (x.EkDosya?.Count > 0)
                    DosyalarıDoldur(x, yeni);
            }
        }
        public void Element_Click(object sender, EventArgs e)
        {
            var element = (AccordionControlElement)sender;
            Container.Controls.Clear();
            switch (element.Tag)
            {
                case Dosya x:
                    ÇalışmaDönemiDodur(x);
                    TalepDoldur(x);
                    ÜcretBilgileriDoldur(x);
                    KıdemTazminatıDoldur(x);
                    ihbarTazminatıDoldur(x);
                    Container.Controls.Add(new Forms.DosyaForm(x));
                    ÇalışmaDosyası = x;
                    break;
                case CalismaDonemi x:
                    Container.Controls.Add(new Forms.ÇalışmaDönemiForm(x));
                    break;
                case KıdemTazminatı x:
                    Container.Controls.Add(new Forms.TazminatForm(x));
                    break;
                case Talepler x:
                    Container.Controls.Add(new Forms.TaleplerForm(x));
                    break;
                case UcretBilgileri x:
                    Container.Controls.Add(new Forms.ÜcretBilgileriForm(x));
                    break;
                case İhbarTazminatı x:
                    Container.Controls.Add(new Forms.İhbarTazminatıForm(x));
                    break;
                default:
                    break;
            }
        }

        void ÇalışmaDönemiDodur(Dosya dosya, Func<CalismaDonemi, bool> predicate = null)
        {
            var element = ElementParentÇalışmaDönemi;

            element.Elements.Clear();
            dosya?.CalismaDonemi?
                .Where(predicate == null ? a => true : predicate)
                .Where(x => x.isActive)

                .ForEach(x =>
                {
                    var yeni = new AccordionControlElement()
                    {
                        Image = GetImage(ElementTipi.ÇalışmaDönemiChild),
                        Style = ElementStyle.Group,
                        Tag = x,
                        Text = $"{x.StartDate.ToShortDateString()}-{x.FinishDate.ToShortDateString()}"

                    };
                    element.Elements.Add(yeni);
                    yeni.Click += Element_Click;
                    ZamanCizelgesiDoldur(x);
                });
        }
        void ZamanCizelgesiDoldur(CalismaDonemi Donem, Func<ZamanCizelgesi, bool> predicate = null)
        {
            var element = ElementParentÇalışmaDönemi.Elements.FirstOrDefault(x => x.Tag == Donem);
            element.Elements.Clear();
            string format = @"hh\:mm";
            Donem?.ZamanCizelgesi?
                    .Where(predicate == null ? a => true : predicate)
                    .Where(x => x.isActive)
                    .ForEach(x =>
                    {
                        var txt = $"{x.Gün.ToString()}-[{x.NetTime.ToString(format) }]";

                        var yeni = new AccordionControlElement()
                        {
                            Image = GetImage(ElementTipi.ÇalışmaZamanı),

                            Style = ElementStyle.Item,
                            Tag = x,
                            //Text = $"{x.Gün}-[{x.StartTime.ToString(format)}-{x.EndTime.ToString(format)}]"
                            Text = $"{x.Gün.ToString()}-[{x.NetTime.ToString(format) }]"
                        };
                        element.Elements.Add(yeni);
                    });
        }
        void TalepDoldur(Dosya dosya, Func<Talepler, bool> predicate = null)
        {
            var element = ElementParentTalepler;

            element.Elements.Clear();
            dosya?.Talepler?
                .Where(predicate == null ? a => true : predicate)
                 .Where(x => x.isActive)

                .ForEach(x =>
                {
                    var yeni = new AccordionControlElement()
                    {
                        Image = GetImage(ElementTipi.TaleplerChild),
                        Style = ElementStyle.Item,
                        Tag = x,
                        //Text = $"{ Regex.Replace(x.TalepTipi.ToString(), "[A-Z]", " $0")}"
                        Text = Tanımlamalar.GetTalepKalemleri(x.TalepTipi),


                    };
                    element.Elements.Add(yeni);
                    yeni.Click += Element_Click;
                });
        }
        void ÜcretBilgileriDoldur(Dosya dosya, Func<UcretBilgileri, bool> predicate = null)
        {
            var element = ElementParentUcretBilgileri;

            element.Elements.Clear();
            dosya?.UcretBilgileri?
                .Where(predicate == null ? a => true : predicate)
                .Where(x => x.isActive)
                .ForEach(x =>
                {
                    var yeni = new AccordionControlElement()
                    {
                        Image = GetImage(ElementTipi.UcretBilgileri),
                        Style = ElementStyle.Item,
                        Tag = x,
                        Text = $"{x.Açıklama}-{x.Tutar.ToCultureString()}"

                    };
                    element.Elements.Add(yeni);
                    yeni.Click += Element_Click;

                });
        }
        void KıdemTazminatıDoldur(Dosya dosya)
        {
            var element = ElementParentKıdemTaz;
            element.Elements.Clear();
            if (dosya == null || dosya.CalismaDonemi?.Count == 0)
            {
                element.Style = ElementStyle.Item;
                return;
            }
            element.Style = ElementStyle.Group;

            var KıdemTazminatı = new Rapor.KıdemTazminatı(TavanUcreti.TavanDonemleri, dosya);
            var yeni = new AccordionControlElement()
            {
                Image = GetImage(ElementTipi.Tazminat),
                Style = ElementStyle.Item,
                Tag = KıdemTazminatı,
                Text = $"{KıdemTazminatı.ÖdenecekNetKıdemTazminatı.ToString("C2", CultureInfo.CreateSpecificCulture("tr-TR")) }"

            };
            element.Elements.Add(yeni);
            yeni.Click += Element_Click;
        }
        void ihbarTazminatıDoldur(Dosya dosya)
        {
            var element = Elementİhbar;
            element.Elements.Clear();
            if (dosya == null || dosya.CalismaDonemi?.Count == 0)
            {
                element.Style = ElementStyle.Item;
                return;
            }
            element.Style = ElementStyle.Group;

            var ihbartaz = new Rapor.İhbarTazminatı( dosya);
            var yeni = new AccordionControlElement()
            {
                Image = GetImage(ElementTipi.Tazminat),
                Style = ElementStyle.Item,
                Tag = ihbartaz,
                Text = $"Ödenecek Net İhbar Taz. :{ihbartaz.ÖdenecekNetİhbar.ToCultureString()}\nÖdenecek Net Kötü Niyet Taz. :{ihbartaz.ÖdenecekNetİhbar.ToCultureString()}"

            };
            element.Elements.Add(yeni);
            yeni.Click += Element_Click;
        }
        private void ElementDosyaParent_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
            Container.Controls.Add(new Forms.DosyaForm());
        }
        private void ElementParentÇalışmaDönemi_Click(object sender, EventArgs e)
        {
            if (ÇalışmaDosyası != null)
            {
                Container.Controls.Clear();
                Container.Controls.Add(new Forms.ÇalışmaDönemiForm());
            }

        }

        private void ElementParentTalepler_Click(object sender, EventArgs e)
        {
            if (ÇalışmaDosyası != null)
            {
                Container.Controls.Clear();
                Container.Controls.Add(new Forms.TaleplerForm());
            }
        }

        private void ElementParentUcretBilgileri_Click(object sender, EventArgs e)
        {
            if (ÇalışmaDosyası != null)
            {
                Container.Controls.Clear();
                Container.Controls.Add(new Forms.ÜcretBilgileriForm());
            }
        }
    }
}

