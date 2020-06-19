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
using ExpertServis.WindowForm.Rapor;

namespace ExpertServis.WindowForm.Forms
{
    public partial class İhbarTazminatıForm : XtraUserControl
    {
        //public Dosya Dosya { get; set; }
        public İhbarTazminatı Tazminatı { get; set; }

        public İhbarTazminatıForm()
        {
            InitializeComponent();
        }
        public İhbarTazminatıForm(İhbarTazminatı ihbar)
        {
            //Dosya = dosya;
            Tazminatı = ihbar;
            //Dosya = ihbar.Dosya;
            InitializeComponent();

        }
        private void İhbarTazminatı_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (Tazminatı == null) return;
            //todo for each kontrol et
            foreach (var item in Tazminatı?.GetType().GetProperties())
            {
                GetControl(item.Name).ForEach(x =>
                {

                    if (item.GetValue(Tazminatı) is decimal)
                        x.Text = ((decimal)item.GetValue(Tazminatı)).ToCultureString();
                    if (item.GetValue(Tazminatı) is int)
                        x.Text = ((int)item.GetValue(Tazminatı)).ToString("C2");
                    if (item.GetValue(Tazminatı) is DateTime)
                        x.Text = ((DateTime)item.GetValue(Tazminatı)).ToShortDateString();



                });
            }

        }
        List<LabelControl> GetControl(string str)
        {
            return this.Controls.OfType<LabelControl>().Where(x => x.Name.Contains(str)).ToList();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
