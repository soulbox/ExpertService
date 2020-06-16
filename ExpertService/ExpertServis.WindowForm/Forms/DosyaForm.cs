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
using ExpertService.DAL;
//using System.Data.Entity.Migrations;
using DevExpress.ExpressApp.Win.Templates;

namespace ExpertServis.WindowForm.Forms
{
    public partial class DosyaForm : DevExpress.XtraEditors.XtraUserControl
    {
        public Dosya dosya { get; set; }
        public Main MainForm { get; set; }
        public DosyaForm(Dosya DosyaParam)
        {
            dosya = DosyaParam;

            InitializeComponent();
        }
        public DosyaForm()
        {
            InitializeComponent();

        }
        Boolean hasAnadosya => dosya?.AnaDosyaID != null ? true : false;
        Boolean hasDosya => dosya != null ? true : false;

        private void DosyaForm_Load(object sender, EventArgs e)
        {
            MainForm = Main.MainForm;
            this.Dock = DockStyle.Fill;
            footer1.btneAdd.Click += BtneAdd_Click;
            footer1.btnUpdate.Click += BtnUpdate_Click;
            footer1.btnDelete.Click += BtnDelete_Click;
            footer1.btneAdd.Text = hasDosya ? "Ek Dosya Ekle" : "Yeni Dosya";

            if (hasDosya)
                GetValues(dosya);
            else
            {
                footer1.btnUpdate.Visible = false;
                footer1.btnDelete.Visible = false;

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

        Dosya SetValues(Dosya dos, bool isActive)
        {
            dos.DosyaNo = txtDosyaNo.Text;
            dos.Adı = txtAdı.Text;
            dos.Soyadı = txtSoyadı.Text;
            dos.TCNO = long.Parse(txtTCNO.Text);
            dos.DavaTarihi = (DateTime)dateDavaTarihi.EditValue;
            dos.ZamanAsimi = chckZaman.Checked;
            dos.Açıklama = txtAçıklama.Text;
            dos.isActive = isActive;
            dos.UpdatedDate = dos.DosyaId > 0 ? DateTime.Now : (DateTime?)null;
            dos.DeletedDate = !isActive ? DateTime.Now : (DateTime?)null;
            dos.AnaDosyaID = hasDosya ? dosya.DosyaId : (int?)null;
            dos.UserId = MainForm.User.UserId;
            return dos;
        }
        Dosya YeniDosyaOluştur()
        {
            return SetValues(new Dosya(), true);
        }
        Dosya EkdosyaOluştur()
        {
            return SetValues(new Dosya(), true);
        }
        Dosya DosyaGüncelle(Dosya dos)
        {

            return SetValues(dos, true);
        }
        Dosya DosyaSil(Dosya dos)
        {

            return SetValues(dos, false);
        }
        private void BtneAdd_Click(object sender, EventArgs e)
        {
            if (!hasDosya)//yenidosya
            {
                var yeni = YeniDosyaOluştur();

                using (DbEntity DB = new DbEntity())
                {
                    //DB.Dosya.AddOrUpdate(yeni);
                    
                    DB.SaveChanges();
                }

                DbManager.DB.Dosya.Add(yeni);
                if (DbManager.DB.SaveChanges() > 0)
                {
                    MainForm.User.Dosyalar.Add(yeni);
                    MainForm.DosyaDoldur();
                    MessageBox.Show("Eklendi");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        private void footer1_Load(object sender, EventArgs e)
        {

        }
    }

}
