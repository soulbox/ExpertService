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
using System.Globalization;

namespace ExpertServis.WindowForm.Forms
{
    public partial class ÜcretBilgileriForm : DevExpress.XtraEditors.XtraUserControl
    {
        public UcretBilgileri UcretBilgileri { get; set; }
        public ÜcretBilgileriForm()
        {
            InitializeComponent();
        }
        public ÜcretBilgileriForm(UcretBilgileri ucret)
        {
            UcretBilgileri = ucret;
            InitializeComponent();

        }
        private void ÜcretBilgileriForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            txtTutar.Properties.Mask.Culture = CultureInfo.CreateSpecificCulture("tr-TR");
            listeUcretler.DataSource = Enum.GetValues(typeof(Tanımlamalar.ÜcretTipi)).Cast<Tanımlamalar.ÜcretTipi>();
            if (UcretBilgileri == null)
            {
                footer1.btnUpdate.Visible = false;
            }
            else
            {
                footer1.btneAdd.Visible = false;

                GetValues();
            }
        }
        void GetValues()
        {
            listeUcretler.SetSelected(listeUcretler.Items.IndexOf(UcretBilgileri.Açıklama), true);
            //chckHesapla.Checked = Talepler.Hesapla;
            txtTutar.EditValue = UcretBilgileri.Tutar;
        }
    }
}
