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
using ExpertServis.WindowForm.Rapor;
using System.Globalization;
using System.Runtime.CompilerServices;
using DevExpress.XtraGrid.Views.Grid;
using ExpertService.Data;

namespace ExpertServis.WindowForm.Forms
{
    public partial class TazminatForm : DevExpress.XtraEditors.XtraUserControl
    {
        public KıdemTazminatı KıdemTazminatı { get; set; }
        public TazminatForm(KıdemTazminatı tazminat)
        {
            KıdemTazminatı = tazminat;
            InitializeComponent();
        }

        private void TazminatForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            dgControl.DataSource = KıdemTazminatı.TavanUcretler.ToList();


            var TutarFormat = dgview.Columns["Tutar"].DisplayFormat;
            TutarFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            TutarFormat.Format = CultureInfo.CreateSpecificCulture("tr-TR");
            TutarFormat.FormatString = "C2";
            dgview.Columns[0].Caption = "Başlangıç";
            dgview.Columns[1].Caption = "Bitiş";




            dgDonemControl.DataSource = KıdemTazminatı.Dosya.CalismaDonemi
                .OrderByDescending(x => x.Id)
                .Select(x => new { x.StartDate, x.FinishDate, x.Yıl, x.Ay, x.Gün, x.ToplamGün })
                .ToList();

            dgDonemView.Columns["Yıl"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            dgDonemView.Columns["Ay"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            dgDonemView.Columns["Gün"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            dgDonemView.Columns["ToplamGün"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            dgDonemView.Columns["Yıl"].SummaryItem.DisplayFormat = "{0}yıl";
            dgDonemView.Columns["Ay"].SummaryItem.DisplayFormat = "{0}ay";
            dgDonemView.Columns["Gün"].SummaryItem.DisplayFormat = "{0}gün";
            dgDonemView.Columns["ToplamGün"].SummaryItem.DisplayFormat = "{0}gün";




            dateBaşlamaTarihi.EditValue = KıdemTazminatı.işeBaşlamatarihi;
            dateiştenÇıkış.EditValue = KıdemTazminatı.iştençıkıştarihi;
            txtTavanDonemi.Text = $"{KıdemTazminatı.TavanDönemi.StartDate.ToShortDateString()} - {KıdemTazminatı.TavanDönemi.EndDate.ToShortDateString()}";
            txtTavan.Text = $"{KıdemTazminatı.Tavan.ToCultureString()}";
            txtBrüt.Text = $"{KıdemTazminatı.Brüt.ToCultureString()}";
            txtTazminatEsasYıllık.Text = $"{KıdemTazminatı.TazminatEsasAylık  .ToCultureString()}";
            txtYılToplamı.Text = $"{KıdemTazminatı.TazminatEsasAylık.ToCultureString()} / 1yıl X {KıdemTazminatı.HizmetYıl}yıl ={KıdemTazminatı.YıllıkToplamÜcret.ToCultureString() } ";
            txtAyToplamı.Text = $"{KıdemTazminatı.TazminatEsasAylık.ToCultureString()} / 12ay X {KıdemTazminatı.HizmetAy }ay ={KıdemTazminatı.AylıkToplamÜcret.ToCultureString() } ";
            txtGünToplamı.Text = $"{KıdemTazminatı.TazminatEsasAylık.ToCultureString()} / 365gün X {KıdemTazminatı.HizmetGün }gün ={KıdemTazminatı.GünlükToplamÜcret.ToCultureString() } ";
            txtToplamBrüt.Text = $"{KıdemTazminatı.ToplamBrütKıdemTazminatı.ToCultureString()}";
            txtDamgaVergisi.Text = $"{KıdemTazminatı.DamgaVergisi.ToCultureString()}";
            txtNetKıdemTazminatı.Text = $"{KıdemTazminatı.NetKıdemTazminatı.ToCultureString()}";
            txtMahsupEdilicekTutar.Text = $"{KıdemTazminatı.MahsupEdilicekTutar.ToCultureString()}";
            txtÖdenecekNetKıdemTaz.Text = $"{KıdemTazminatı.ÖdenecekNetKıdemTazminatı.ToCultureString()}";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgview_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            GridView gv = sender as GridView;
            var value = gv.GetRow(e.RowHandle) as TavanDonem;
            if (value == KıdemTazminatı.TavanDönemi)
            {
                e.Appearance.BackColor = Color.LawnGreen;
            }

        }
    }
}
public static class ext
{

}

