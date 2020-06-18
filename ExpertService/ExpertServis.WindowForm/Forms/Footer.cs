using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ExpertServis.WindowForm.Forms
{
    public partial class Footer : DevExpress.XtraEditors.XtraUserControl
    {
        public string Update { get; set; }
        public string Delete { get; set; }

        public Footer()
        {
            InitializeComponent();
        }
        private void Footer_Load(object sender, EventArgs e)
        {

        }
        private void btneAdd_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("asdfgg");
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
