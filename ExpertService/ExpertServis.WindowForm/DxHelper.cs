using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using DevExpress.XtraBars.Navigation;

namespace ExpertServis.WindowForm
{
    public class DxHelper
    {
        public DxHelper()
        {
            //((System.Drawing.Image)(resources.GetObject("accordionControlElement6.ImageOptions.Image")));
            //Properties.Resources.adateoccurring_32x32
        }
        public static Dictionary<ElementTipi, Image> DxImages { get; set; } = new Dictionary<ElementTipi, Image>()
        {
            {ElementTipi.dosyaparent , Properties.Resources.bofileattachment_32x32 },
            {ElementTipi.dosyachild, Properties.Resources.bofileattachment_16x16 },
            {ElementTipi.ÇalışmadönemiParent , Properties.Resources.adateoccurring_32x32 },
            {ElementTipi.ÇalışmaDönemiChild  , Properties.Resources.adateoccurring_16x16 },
            {ElementTipi.ÇalışmaZamanı  , Properties.Resources.showworktimeonly_16x16 },
            {ElementTipi.TaleplerParent  , Properties.Resources.financial_32x32 },
            {ElementTipi.TaleplerChild   , Properties.Resources.financial_16x16 },
            {ElementTipi.UcretBilgileri    , Properties.Resources.salesanalysis_16x16 },



        };

        public static Image GetImage(ElementTipi tip) => DxImages.FirstOrDefault(x => x.Key == tip).Value;
        public enum ElementTipi
        {
            dosyaparent,
            dosyachild,
            ÇalışmadönemiParent,
            ÇalışmaDönemiChild,
            ÇalışmaZamanı,
            TaleplerParent,
            TaleplerChild,
            UcretBilgileri
        }
        public class MydxNavigator
        {
            public List<AccordionControlElement> Dosyalar { get; set; }=new List<AccordionControlElement>();
            public List<AccordionControlElement> Talepler { get; set; } = new List<AccordionControlElement>();
            //public List<AccordionControlElement> Dosyalar { get; set; } = new List<AccordionControlElement>();

            public MydxNavigator()
            {
                var asdg = new Main(null);
                //asdg.ElementCalismaZamanı.c
            }
        }
    }
}
