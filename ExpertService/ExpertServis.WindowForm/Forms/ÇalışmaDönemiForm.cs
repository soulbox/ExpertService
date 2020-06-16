using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpertService.Model;

namespace ExpertServis.WindowForm.Forms
{
    public partial class ÇalışmaDönemiForm : DevExpress.XtraEditors.XtraUserControl
    {
        public CalismaDonemi CalismaDonemi { get; set; }
        public ÇalışmaDönemiForm(CalismaDonemi donem)
        {

            InitializeComponent();
            CalismaDonemi = donem;


        }

        private void ÇalışmaDönemiForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            if (CalismaDonemi == null)
            {
                footer1.btneAdd.Visible = false;
            }
            else
            {
                GetValues();
            }

        }

        void GetValues()
        {
            dateStart.EditValue = CalismaDonemi.StartDate;
            dateFinish.EditValue = CalismaDonemi.FinishDate;
            chckFazlaMesai.Checked = CalismaDonemi.FazlaMesaiAlındı;
            chckKıdem.Checked = CalismaDonemi.KıdemAlındı;
            chckİhbar.Checked = CalismaDonemi.ihbarAlındı;
            foreach (var item in this.Controls)
            {

                var tedit = item as DevExpress.XtraEditors.TimeEdit;
                if (tedit != null)
                {
                    var mask = tedit.Properties.Mask;
                    mask.EditMask = @"HH\:mm";
                    mask.UseMaskAsDisplayFormat = true;
                    mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    var propname = tedit.Name.Substring(0, tedit.Name.Length - 1);
                    var Gün = (Tanımlamalar.Günler)Enum.Parse(typeof(Tanımlamalar.Günler), tedit.Name.Replace(propname, ""));
                    var GünItem = CalismaDonemi.ZamanCizelgesis.FirstOrDefault(x => x.Gün == Gün);
                    var value = GünItem.GetPropValue(propname);
                    tedit.EditValue = value;

                }
            }
        }
        
    }
    public static class ext
    {
        public static object GetPropValue<T>(this T src, string propName)
           where T : class
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
