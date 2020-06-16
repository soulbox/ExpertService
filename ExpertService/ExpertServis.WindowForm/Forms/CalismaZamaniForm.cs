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
          

        }

        private void footer1_Load(object sender, EventArgs e)
        {

        }
      

        object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

    }

}
