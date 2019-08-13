using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertService

{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        protected override void OnShown(EventArgs e)
        {
           
            base.OnShown(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var Kullanıci = DBManager.Db.Kullanici.Where(x => x.KullaniciAdi == txtUser.Text && x.Sifre == txtPw.Text).FirstOrDefault();
            if (Kullanıci == null)
                MetroMessageBox.Show(this, "Kullanıcı adı veya şifresi yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MetroMessageBox.Show(this, $"Kullanıcı:{Kullanıci.Adı.ToUpper()} {Kullanıci.Soyadı.ToUpper()}\nHoşgeldiniz. ", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
