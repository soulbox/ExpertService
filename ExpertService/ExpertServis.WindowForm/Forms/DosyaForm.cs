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
using DevExpress.Utils.Extensions;

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

        Dosya SetValues(Dosya dos, bool isActive, int? anadosyaId)
        {
            if (isActive)
            {
                dos.DosyaNo = txtDosyaNo.Text;
                dos.Adı = txtAdı.Text;
                dos.Soyadı = txtSoyadı.Text;
                dos.TCNO = long.Parse(txtTCNO.Text);
                dos.DavaTarihi = (DateTime)dateDavaTarihi.EditValue;
                dos.ZamanAsimi = chckZaman.Checked;
                dos.Açıklama = txtAçıklama.Text;
                dos.UserId = MainForm.User.Id;
                dos.AnaDosyaID = anadosyaId;
                dos.UpdatedDate = dos.Id > 0 ? DateTime.Now : (DateTime?)null;
            }
            else 
                dos.DeletedDate =DateTime.Now ;
            dos.isActive = isActive;
            return dos;
        }
        Dosya YeniDosyaOluştur()
        {

            return SetValues(new Dosya(), true, (int?)null);
        }
        Dosya EkdosyaOluştur()
        {
            return SetValues(new Dosya(), true, dosya.Id);
        }
        Dosya DosyaGüncelle(Dosya dos)
        {

            return SetValues(dos, true, dosya.AnaDosyaID);
        }
        Dosya DosyaSil(Dosya dos)
        {
            return SetValues(dos, false, dos.AnaDosyaID);
        }
        void EkdosyaSil(Dosya ekdosya)
        {
            ekdosya.EkDosya.ToList().ForEach(x =>
            {
                DosyaSil(x);
                if (ekdosya.EkDosya?.Count > 0)
                    EkdosyaSil(x);
            });

        }
        private void BtneAdd_Click(object sender, EventArgs e)
        {
            var yeni = !hasDosya ? YeniDosyaOluştur() : EkdosyaOluştur();
            DbManager.DB.Dosya.Add(yeni);
            if (DbManager.DB.SaveChanges() > 0)
            {
                MainForm.User.Dosya.Add(yeni);
                MainForm.DosyaDoldur();
                Msg("Eklendi");
                MainForm.Container.Controls.Clear();
            }

        }

        void Msg(string message) => XtraMessageBox.Show(message);
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show($"{dosya.DosyaNo} Güncellensin mi?", "Güncelle", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DosyaGüncelle(dosya);

                if (DbManager.DB.SaveChanges() > 0)
                {
                    //MainForm.User.Dosya.Add(yeni);
                    MainForm.DosyaDoldur();
                    Msg("Güncellendi.");
                    MainForm.Container.Controls.Clear();

                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var str = "";
            if (dosya.EkDosya?.Count > 0)
                str = $"Dosya No:{dosya.DosyaNo}\nBu dosyaya ait ek dosyalarla beraber silisin mi?";
            else str = $"{dosya.DosyaNo } Silinsin mi?";

            if (XtraMessageBox.Show($"{str } Silinsin mi?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dosya.EkDosya?.Count > 0)
                {
                    DosyaSil(dosya);
                    EkdosyaSil(dosya);
                }
                else
                    DosyaSil(dosya);
                if (DbManager.DB.SaveChanges() > 0)
                {
                    //MainForm.User.Dosya.Add(yeni);
                    MainForm.DosyaDoldur();
                    Msg("Silindi!.");
                    MainForm.Container.Controls.Clear();

                }
            }
        }





        private void footer1_Load(object sender, EventArgs e)
        {

        }
    }

}
