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
//using System.Data.Entity.Migrations.Model;

namespace ExpertServis.WindowForm.Forms
{
    public partial class TaleplerForm : DevExpress.XtraEditors.XtraUserControl
    {
        public Talepler Talepler { get; set; }
        public TaleplerForm()
        {
            InitializeComponent();
        }
        public TaleplerForm(Talepler talep)
        {
            Talepler = talep;
            InitializeComponent();
            footer1.btneAdd.Click += BtneAdd_Click;
            footer1.btnUpdate.Click += BtnUpdate_Click;
            footer1.btnDelete.Click += BtnDelete_Click; ;

        }


        private void TaleplerForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            Enum.GetValues(typeof(Tanımlamalar.TalepTipi)).Cast<Tanımlamalar.TalepTipi>().ToList().ForEach(x =>
            {
                lisTalepTipi.Items.Add(x);
            });
            //dgviewTalepler.Columns[0].Caption = "Talepler";
            if (Talepler == null)
            {
                footer1.btnUpdate.Visible = false;
            }
            else
            {
                footer1.btneAdd .Visible = false;
                GetValues();
            }
        }
        void GetValues()
        {
            lisTalepTipi.SetSelected(lisTalepTipi.Items.IndexOf(Talepler.TalepTipi), true);
            chckHesapla.Checked = Talepler.Hesapla;

        }

        private void BtneAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
