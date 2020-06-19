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
    public partial class İhbarTazminatıForm : XtraUserControl
    {
        public Dosya Dosya { get; set; }
        public İhbarTazminatıForm()
        {
            InitializeComponent();
        }
        public İhbarTazminatıForm(Dosya dosya)
        {
            Dosya = dosya;
            InitializeComponent();

        }
        private void İhbarTazminatı_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.BringToFront();

        }
    }
}
