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

namespace ExpertServis.WindowForm.Forms
{
    public partial class CalismaZamaniForm : DevExpress.XtraEditors.XtraUserControl
    {
        public CalismaZamaniForm()
        {
            InitializeComponent();
        }

        private void CalismaZamaniForm_Load(object sender, EventArgs e)
        {
            //timeEdit1.Properties.Mask.EditMask = @"HH\:mm";
            //timeEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            foreach (var item    in this.Controls )
            {
                var tspan = item  as DevExpress.XtraEditors.TimeSpanEdit ;
                var tedit = item as DevExpress.XtraEditors.TimeEdit ;
                if (tspan != null)
                {
                    var mask = tspan.Properties.Mask;
                    mask.EditMask = @"hh\:mm";
                    mask.UseMaskAsDisplayFormat = true;
                    mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.TimeSpan;
                }
                if (tedit!=null)
                {
                    var mask = tedit.Properties.Mask;
                    mask.EditMask = @"hh\:mm";
                    mask.UseMaskAsDisplayFormat = true;
                    mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.TimeSpan;

                }
            }
        }
    }
}
