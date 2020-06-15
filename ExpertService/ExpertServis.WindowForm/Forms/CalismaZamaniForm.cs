using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ExpertService.Model;

namespace ExpertServis.WindowForm.Forms
{
    public partial class CalismaZamaniForm : DevExpress.XtraEditors.XtraUserControl
    {
        public CalismaDonemi Dönem { get; set; }
        public CalismaZamaniForm(CalismaDonemi dönem)
        {
            Dönem = dönem;
            InitializeComponent();
        }

        private void CalismaZamaniForm_Load(object sender, EventArgs e)
        {
            GetValues();

        }

        private void footer1_Load(object sender, EventArgs e)
        {

        }
        void GetValues()
        {
            foreach (var item in this.Controls)
            {

                var tedit = item as DevExpress.XtraEditors.TimeEdit;
                if (tedit != null)
                {
                    var mask = tedit.Properties.Mask;
                    mask.EditMask = @"HH\:mm";
                    mask.UseMaskAsDisplayFormat = true;
                    mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    var propname = tedit.Name .Substring(0, tedit.Name.Length - 1);
                    var Gün = (Tanımlamalar.Günler)Enum.Parse(typeof(Tanımlamalar.Günler), tedit.Name .Replace(propname, ""));
                    var GünItem = Dönem.ZamanCizelgesis.FirstOrDefault(x => x.Gün == Gün);
                    var value = GetPropValue(GünItem, propname);
                    tedit.EditValue = value;
                }
            }
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
