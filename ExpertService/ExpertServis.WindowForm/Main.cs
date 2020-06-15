using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab.Buttons;
using ExpertService.Data;
using ExpertService.Model;
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
        public Main(UserTable user)
        {
            User = user;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var a = new Forms.DosyaForm();
            Container.AddControl(new Forms.CalismaZamaniForm());
            ElementDosyaParent.Elements.Clear();
            ElementParentTalepler.Elements.Clear();
            ElementParentUcretBilgileri.Elements.Clear();
            ElementParentÇalışmaDönemi.Elements.Clear();
            ElementTest.HeaderControl = simpleButton2;

            DosyaDoldur();
        }

        void DosyaDoldur(Func<Dosya, bool> prediticate = null)
        {
            var element = ElementDosyaParent;
            element.Elements.Clear();
            User.Dosyalar?
                .Where(prediticate == null ? a => true : prediticate)
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
            foreach (var x in dossya.EkDosya)
            {

                if (x.DosyaId == 5)
                {

                }
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
        private void Element_Click(object sender, EventArgs e)
        {
            var element = (AccordionControlElement)sender;
            switch (element.Tag)
            {
                case Dosya x:
                    ÇalışmaDönemiDodur(x);
                    TalepDoldur(x);
                    ÜcretBilgileriDoldur(x);                
                     RaporDoldur(x);
                    Container.Controls.Clear();
                    var form = new Forms.DosyaForm(x);
                    form.Dock = DockStyle.Fill;
                    Container.Controls.Add(form);
                    break;
                case CalismaDonemi x:
                    Container.Controls.Clear();                    
                    var f1 = new Forms.ÇalışmaDönemiForm(x);
                    f1.Dock = DockStyle.Fill;
                    Container.Controls.Add(f1);
                    break;
                case KıdemTazminatı a:
                    Container.Controls.Clear();
                    var TazminatForm = new Forms.TazminatForm(a);
                    TazminatForm.Dock = DockStyle.Fill;
                    Container.Controls.Add(TazminatForm);
                    break;
                default:
                    break;
            }
        }

        void ÇalışmaDönemiDodur(Dosya dosya, Func<CalismaDonemi, bool> predicate = null)
        {
            var element = ElementParentÇalışmaDönemi;

            element.Elements.Clear();
            dosya?.CalismaDonemis?
                .Where(predicate == null ? a => true : predicate)
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
            Donem?.ZamanCizelgesis?
                    .Where(predicate == null ? a => true : predicate)
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
            dosya?.Taleplers?
                .Where(predicate == null ? a => true : predicate)
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

                });
        }
        void ÜcretBilgileriDoldur(Dosya dosya, Func<UcretBilgileri, bool> predicate = null)
        {
            var element = ElementParentUcretBilgileri;

            element.Elements.Clear();
            dosya?.UcretBilgileris?
                .Where(predicate == null ? a => true : predicate)
                .ForEach(x =>
                {
                    var yeni = new AccordionControlElement()
                    {
                        Image = GetImage(ElementTipi.UcretBilgileri),
                        Style = ElementStyle.Item,
                        Tag = x,
                        Text = $"{x.Açıklama}"

                    };
                    element.Elements.Add(yeni);
                });
        }
        void RaporDoldur(Dosya dosya)
        {
            var element = ElementParentKıdemTaz;
            element.Elements.Clear();
            if (dosya == null || dosya.CalismaDonemis.Count == 0)
            {
                element.Style = ElementStyle.Item;
                return;
            }
             element.Style = ElementStyle.Group ;

            var KıdemTazminatı = new Rapor.KıdemTazminatı(TavanUcreti.TavanDonemleri, dosya);
            var yeni = new AccordionControlElement()
            {
                Image = GetImage(ElementTipi.UcretBilgileri),
                Style = ElementStyle.Item,
                Tag = KıdemTazminatı,
                Text = $"{KıdemTazminatı.ÖdenecekNetKıdemTazminatı.ToString("C2", CultureInfo.CreateSpecificCulture("tr-TR")) }"

            };
            element.Elements.Add(yeni);
            yeni.Click += Element_Click;
        }

        private void ElementDosyaParent_Click(object sender, EventArgs e)
        {
            Container.Controls.Clear();
            var form = new Forms.DosyaForm();
            form.Dock = DockStyle.Fill;
            Container.Controls.Add(form);
        }
    }
}

