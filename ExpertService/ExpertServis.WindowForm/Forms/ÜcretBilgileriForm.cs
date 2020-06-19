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
using static ExpertServis.WindowForm.Forms.Ext;
using static ExpertService.Model.Tanımlamalar;

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
            Enum.GetValues(typeof(Tanımlamalar.ÜcretTipi)).Cast<Tanımlamalar.ÜcretTipi>()
               .ToList()
               .ForEach(x =>
           {
               listeUcretler.Items.Add(x);
           });

            FooterLogic<UcretBilgileri> foot = new FooterLogic<UcretBilgileri>
                (
                new Func<UcretBilgileri>(() => SetValues(new UcretBilgileri(), ormtype.add)),
                new Func<UcretBilgileri>(() => SetValues(UcretBilgileri, ormtype.update)),
                new Func<UcretBilgileri>(() => SetValues(UcretBilgileri, ormtype.delete)),
                footer1

                );
            foot.UpdStr = $"Açıklama:{UcretBilgileri?.Açıklama}\nTutar:{UcretBilgileri?.Tutar.ToCultureString()}";
            foot.DelStr = foot.UpdStr;

            if (UcretBilgileri == null)
            {
                footer1.btnUpdate.Visible = false;
                footer1.btnDelete.Visible = false;
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
            txtTutar.EditValue = UcretBilgileri.Tutar;
        }

        UcretBilgileri SetValues(UcretBilgileri u, ormtype Otype)
        {
            u.isActive = Otype != ormtype.delete;
            if (Otype != ormtype.delete)
            {
                u.Tutar = (decimal)txtTutar.EditValue;
                u.DosyaId = Main.MainForm.ÇalışmaDosyası.Id;
                u.Açıklama = (ÜcretTipi)listeUcretler.SelectedValue;

            }
            return u;
        }
    }
}
