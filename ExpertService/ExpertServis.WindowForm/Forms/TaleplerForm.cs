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

        }


        private void TaleplerForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            Enum.GetValues(typeof(Tanımlamalar.TalepTipi)).Cast<Tanımlamalar.TalepTipi>().ToList().ForEach(x =>
            {
                lisTalepTipi.Items.Add(x);
            });
            FooterLogic<Talepler> foot = new FooterLogic<Talepler>
                (
                new Func<Talepler>(() => CreateTalep()),
                new Func<Talepler>(() => UpdateTalep()),
                new Func<Talepler>(() => DeleteTalep()),
                footer1

                );
            foot.UpdStr = $"{Talepler?.TalepTipi.ToString()}";
            foot.DelStr = foot.UpdStr;
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
               t.Hesapla = chckHesapla.Checked;
               t.TalepTipi = (TalepTipi)lisTalepTipi.SelectedValue;
               t.DosyaId = Main.MainForm.ÇalışmaDosyası.Id;

            }
            return t;
        }

        Talepler CreateTalep() => SetValues(new Talepler(), ormtype.add);
        Talepler UpdateTalep() => SetValues(Talepler, ormtype.update);
        Talepler DeleteTalep() => SetValues(Talepler, ormtype.delete);


    }

}
