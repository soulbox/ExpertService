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
using ExpertService.Model;
using DevExpress.XtraEditors.Filtering.Templates;
using NodaTime;

namespace ExpertServis.WindowForm.Forms
{
    public partial class DosyaForm : DevExpress.XtraEditors.XtraUserControl
    {
        public Dosya dosya { get; set; }
        public DosyaForm(Dosya DosyaParam)
        {
            dosya = DosyaParam;
            InitializeComponent();
        }
        public DosyaForm()
        {
            InitializeComponent();

        }


        private void DosyaForm_Load(object sender, EventArgs e)
        {
            footer1.btneAdd.Click += BtneAdd_Click;
            footer1.btnUpdate.Click += BtnUpdate_Click;
            footer1.btnDelete.Click += BtnDelete_Click;
            if (dosya != null)
            {
                GetValues(dosya);
                //footer1.btneAdd.Visible = false;
                //ToplamÇalışma();

            }
        }

        void GetValues(Dosya dos)
        {
            txtDosyaNo.Text = dos.DosyaNo;
            txtAdı.Text = dos.Adı;
            txtSoyadı.Text = dos.Soyadı;
            txtTCNO.Text = dos.TCNO.ToString();
            dateDavaTarihi.EditValue = dos.DavaTarihi;
            dateKayıtTarihi.EditValue = dos.CreatedDate;
            chckZaman.Checked = dos.ZamanAsimi;
            txtAçıklama.Text = dos.Açıklama;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtneAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void footer1_Load(object sender, EventArgs e)
        {

        }
    }

}
