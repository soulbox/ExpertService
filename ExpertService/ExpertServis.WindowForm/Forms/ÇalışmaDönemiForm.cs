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
        }
    }
}
