using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab.Buttons;
using ExpertService.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                .ForEach(x =>
            {
                var yeni = new AccordionControlElement()
                {
                    Image = GetImage(ElementTipi.dosyachild),
                    Style = ElementStyle.Item,
                    Tag = x,
                    Text = $"{x.Adı } {x.Soyadı }-{x.DavaTarihi.ToShortDateString()}"
                    //Text = $"{x.Adı } {x.Soyadı }"

                };
                element.Elements.Add(yeni);
                yeni.Click += Element_Click;
                //ÇalışmaDönemiDodur(x);
                //TalepDoldur(x);
                //ÜcretBilgileriDoldur(x);
            });
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

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }

        private void ElementTest_Click(object sender, EventArgs e)
        {

        }
    }
}

