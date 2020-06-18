using DevExpress.ExpressApp.Win.Templates;
using DevExpress.Utils.Extensions;
using DevExpress.XtraDashboardLayout;
using ExpertService.DAL;
using ExpertService.DAL.Repo.Abstract;
using ExpertService.DAL.Repo.Concreate;
using ExpertService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ExpertServis.WindowForm.Forms.Ext;
namespace ExpertServis.WindowForm.Forms
{
    public class FooterLogic<Entity>
     where Entity : class
    {
        public IRepository<Entity> Repo { get; set; }
        public Footer Footer { get; set; }
        public Func<Entity> AddEntity { get; set; }
        public Func<Entity> UpdateEntity { get; set; }
        public Func<Entity> DeleteEntity { get; set; }
        //public string DelStr { get; set; }
        public string UpdorDeleteStr { get; set; }

        public FooterLogic(Func<Entity> add, Func<Entity> Upd, Func<Entity> del, Footer footer)
        {

            var asgg = DbManager.UnitWork.GetType().GetProperties();
            var type = DbManager.UnitWork.GetType();
            foreach (var item in type.GetProperties())
            {
                var obj = item.GetValue(DbManager.UnitWork) as IRepository<Entity>;
                if (obj != null)
                {
                    Repo = obj;
                    break;
                }
            }

            AddEntity = add;
            UpdateEntity = Upd;
            DeleteEntity = del;
            Footer = footer;
            Footer.btneAdd.Click += BtneAdd_Click;
            Footer.btnDelete.Click += BtnDelete_Click;
            Footer.btnUpdate.Click += BtnUpdate_Click;

        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MsgErrorQuestion($"{UpdorDeleteStr}\nSilinsin mi?", "Sil") == DialogResult.Yes)
            {
                var sil = DeleteEntity();
                if (DbManager.UnitWork.Complete() > 0)
                {
                    Msg("Silindi.!");
                    Main.MainForm.Form1_Load(null, null);
                }
            }

        }

        void addcollection(object obje, Entity add)
        {

            foreach (var item in obje.GetType().GetProperties())
            {
                var obj = item.GetValue(obje) as ICollection<Entity>;
                var obj2 = item.GetValue(obje);
                if (obj != null)
                {
                    obj.Add(add);
                    break;
                }
                else if (obj2 is ICollection)
                {
                    addcollection(obj2, add);
                }

            }

        }

        private void BtneAdd_Click(object sender, EventArgs e)
        {
            var yeni = AddEntity();
            Repo.Add(yeni);
            if (DbManager.UnitWork.Complete() > 0)
            {
                addcollection(Main.MainForm.User, yeni);
                Msg("Eklendi");
                Main.MainForm.Form1_Load(null, null);

            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (MsgQuestion($"{UpdorDeleteStr}\nGüncellensin mi?", "Güncelle") == DialogResult.Yes)
            {
                var güncel = UpdateEntity();
                if (DbManager.UnitWork.Complete() > 0)
                {

                    Msg("Güncellendi");
                    Main.MainForm.Form1_Load(null, null);
                }
            }
        }




    }
}
