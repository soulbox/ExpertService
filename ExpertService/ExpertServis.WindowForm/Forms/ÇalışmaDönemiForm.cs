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
using static ExpertService.DAL.DbManager;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.Data.Helpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraNavBar;
using static ExpertServis.WindowForm.Forms.Ext;
namespace ExpertServis.WindowForm.Forms
{
    public partial class ÇalışmaDönemiForm : DevExpress.XtraEditors.XtraUserControl
    {
        public CalismaDonemi CalismaDonemi { get; set; }
        public Main MainForm { get; set; }

        public ÇalışmaDönemiForm()
        {
            InitializeComponent();
        }
        public ÇalışmaDönemiForm(CalismaDonemi donem)
        {

            InitializeComponent();
            CalismaDonemi = donem;


        }

        private void ÇalışmaDönemiForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            MainForm = Main.MainForm;

            footer1.btneAdd.Click += BtneAdd_Click;
            footer1.btnDelete.Click += BtnDelete_Click;
            footer1.btnUpdate.Click += BtnUpdate_Click;

            //var aaaa = ((TimeSpan)StartTime1.EditValue);
            this.Controls.OfType<TimeEdit>().ForEach(x => x.EditValue = new TimeSpan(0, 0, 0));
            if (CalismaDonemi == null)
            {

                footer1.btnUpdate.Visible = false;
                footer1.btnDelete.Visible = false;

            }
            else
            {
                GetValues();
                footer1.btneAdd.Visible = false;


            }

        }

        void GetValues()
        {
            dateStart.EditValue = CalismaDonemi.StartDate;
            dateFinish.EditValue = CalismaDonemi.FinishDate;
            chckFazlaMesai.Checked = CalismaDonemi.FazlaMesaiAlındı;
            chckKıdem.Checked = CalismaDonemi.KıdemAlındı;
            chckİhbar.Checked = CalismaDonemi.ihbarAlındı;
            foreach (var item in this.Controls)
            {

                var tedit = item as DevExpress.XtraEditors.TimeEdit;
                if (tedit != null)
                {
                    var mask = tedit.Properties.Mask;
                    mask.EditMask = @"HH\:mm";
                    mask.UseMaskAsDisplayFormat = true;
                    mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    var propname = tedit.Name.Substring(0, tedit.Name.Length - 1);
                    var Gün = (Tanımlamalar.Günler)Enum.Parse(typeof(Tanımlamalar.Günler), tedit.Name.Replace(propname, ""));
                    var GünItem = CalismaDonemi.ZamanCizelgesi.FirstOrDefault(x => x.Gün == Gün);
                    var value = GünItem.GetPropValue(propname);
                    tedit.EditValue = value;

                }
            }
        }
        CalismaDonemi SetValues(CalismaDonemi c, ormtype Otype)
        {
            c.isActive = Otype != ormtype.delete;
            if (Otype != ormtype.delete)
            {
                c.StartDate = (DateTime)dateStart.EditValue;
                c.FinishDate = (DateTime)dateFinish.EditValue;
                c.FazlaMesaiAlındı = chckFazlaMesai.Checked;
                c.KıdemAlındı = chckKıdem.Checked;
                c.ihbarAlındı = chckİhbar.Checked;
                c.DosyaId = MainForm.ÇalışmaDosyası.Id;

            }
            switch (Otype)
            {
                case ormtype.add:
                    foreach (var item in Enum.GetValues(typeof(Tanımlamalar.Günler)))
                    {
                        c.ZamanCizelgesi.Add(new ZamanCizelgesi()
                        {
                            CalismaDonemiId = c.Id,
                            Gün = (Tanımlamalar.Günler)item,
                            StartTime = GetControlTimeValue($"StartTime{(int)item}"),
                            EndTime = GetControlTimeValue($"EndTime{(int)item}"),
                            RestTime = GetControlTimeValue($"RestTime{(int)item}"),
                            isActive = Otype != ormtype.delete,
                        });
                    }
                    break;
                case ormtype.update:
                    c.ZamanCizelgesi?.ForEach(x =>
                    {
                        x.StartTime = GetControlTimeValue($"StartTime{(int)x.Gün}");
                        x.EndTime = GetControlTimeValue($"EndTime{(int)x.Gün}");
                        x.RestTime = GetControlTimeValue($"RestTime{(int)x.Gün}");
                        x.isActive = Otype != ormtype.delete;
                    });
                    break;
                case ormtype.delete:
                    c.ZamanCizelgesi?.ForEach(x => x.isActive = false);
                    break;
                default:
                    break;
            }
            return c;
        }
        CalismaDonemi CreateDonem() => SetValues(new CalismaDonemi(), ormtype.add);
        CalismaDonemi UpdateDonem() => SetValues(CalismaDonemi, ormtype.update);
        CalismaDonemi DeleteDonem() => SetValues(CalismaDonemi, ormtype.delete);

        TimeEdit GetControl(string str)
        {
            return this.Controls.OfType<TimeEdit>().FirstOrDefault(x => x.Name == str);
        }
        TimeSpan GetControlTimeValue(string str)
        {
            var c = GetControl(str);
            if (c.EditValue.GetType() == typeof(TimeSpan))
                return (TimeSpan)c.EditValue;
            else
                return ((DateTime)c.EditValue).TimeOfDay;
        }

        //CalismaDonemi Create() { }
        private void BtneAdd_Click(object sender, EventArgs e)
        {
            var yeni = CreateDonem();
            UnitWork.CalismaRepo.Add(yeni);
            if (UnitWork.Complete() > 0)
            {
                MainForm.User.Dosya.Select(x => x.CalismaDonemis).ToList().Add(new List<CalismaDonemi>() { yeni });

                Msg("Eklendi");
                MainForm.Form1_Load(null, null);

            }
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (MsgQuestion($"DosyaNo:{MainForm.ÇalışmaDosyası.DosyaNo}\nDönemi:{CalismaDonemi.StartDate.ToShortDateString()} - {CalismaDonemi.FinishDate.ToShortDateString()}\nGüncellensin mi?", "Güncelle") == DialogResult.Yes)
            {
                var güncel = UpdateDonem();
                if (UnitWork.Complete() > 0)
                {

                    Msg("Güncellendi");
                    MainForm.Form1_Load(null, null);

                }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MsgErrorQuestion($"DosyaNo:{MainForm.ÇalışmaDosyası.DosyaNo}\nDönemi:{CalismaDonemi.StartDate.ToShortDateString()} - {CalismaDonemi.FinishDate.ToShortDateString()}\nSilinsin mi?", "Sil") == DialogResult.Yes)
            {
                var sil = DeleteDonem();
                if (UnitWork.Complete() > 0)
                {

                    Msg("Silindi.!");
                    MainForm.Form1_Load(null, null);

                }
            }
        }






    }
    public static class ext
    {
        public static object GetPropValue<T>(this T src, string propName)
           where T : class
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
