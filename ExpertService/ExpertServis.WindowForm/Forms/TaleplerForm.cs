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
using static ext;
using static ExpertServis.WindowForm.Forms.Ext;
using static ExpertService.Model.Tanımlamalar;
using static ExpertService.DAL.DbManager;

using DevExpress.ExpressApp.Win.Templates;

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
            lisTalepTipi.SetSelected(lisTalepTipi.Items.IndexOf(Talepler.TalepTipi), true);
            chckHesapla.Checked = Talepler.Hesapla;

        }
        Talepler SetValues(Talepler t, ormtype Otype)
        {
            t.isActive = Otype != ormtype.delete;
            if (Otype != ormtype.delete)
            {
                Talepler.Hesapla = chckHesapla.Checked;
                Talepler.TalepTipi = (TalepTipi)lisTalepTipi.SelectedValue;
                Talepler.DosyaId = Main.MainForm.ÇalışmaDosyası.Id;

            }
            return t;
        }

        Talepler CreateTalep() => SetValues(new Talepler(), ormtype.add);
        Talepler UpdateTalep() => SetValues(Talepler, ormtype.update);
        Talepler DeleteTalep() => SetValues(Talepler, ormtype.delete);



        private void BtneAdd_Click(object sender, EventArgs e)
        {
            var yeni = CreateTalep();
            UnitWork.TalepRepo.Add(yeni);
            if (UnitWork.Complete() > 0)
            {
                Main.MainForm.User.Dosya.Select(x => x.Taleplers).ToList().Add(new List<Talepler>() { yeni });
                Msg("Eklendi");
                Main.MainForm.Form1_Load(null, null);

            }
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
