using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ExpertService.Model;
using ExpertServis.WindowForm.Rapor;
using DevExpress.Utils.Extensions;
using Microsoft.EntityFrameworkCore.Internal;

namespace ExpertServis.WindowForm.Forms
{
    public partial class İhbarTazminatıForm : XtraUserControl
    {
        //public Dosya Dosya { get; set; }
        public İhbarTazminatı Tazminatı { get; set; }

        public İhbarTazminatıForm()
        {
            InitializeComponent();
        }
        public İhbarTazminatıForm(İhbarTazminatı ihbar)
        {
            //Dosya = dosya;
            Tazminatı = ihbar;
            //Dosya = ihbar.Dosya;
            InitializeComponent();

        }
        private void İhbarTazminatı_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            if (Tazminatı == null) return;
            GetControl(this);


            //todo for each kontrol et

            foreach (var item in Tazminatı?.GetType().GetProperties())
            {

                //var ctr = controllist.FirstOrDefault(x => x.Name.Replace("1", "").Replace("2", "") == item.Name);

                controllist.Where(x => x.Name.Replace("1", "").Replace("2", "") == item.Name).ToList().ForEach(ctr => 
                {
                    //if (ctr == null) continue;
                    if (item.GetValue(Tazminatı) is decimal)
                        ctr.Text = ((decimal)item.GetValue(Tazminatı)).ToCultureString();
                    if (item.GetValue(Tazminatı) is int)
                    {
                        var ints = (int)item.GetValue(Tazminatı);
                        var str = string.Format("{0:n0} gün", ints);
                        ctr.Text = str;

                    }
                    if (item.GetValue(Tazminatı) is DateTime)
                        ctr.Text = ((DateTime)item.GetValue(Tazminatı)).ToShortDateString();
                });
                

            }

        }
        //List<LabelControl> GetControl(string str)
        //{
        //    this.Controls.OfType<LabelControl>().ForEach(x =>
        //    {
        //        var name = x.Name;
        //        if (name.Contains(str))
        //        {

        //        }
        //    });
        //    return this.Controls.OfType<LabelControl>().Where(x => x.Name.Contains(str)).ToList();
        //}
        List<LabelControl> controllist;

        List<LabelControl> GetControl(Control ctr)
        {
            controllist = controllist ?? new List<LabelControl>();

            foreach (var x in ctr.Controls)
            {
                if (x is LabelControl)
                    controllist.Add((LabelControl)x);
                if (((Control)x).Controls.Count > 0) GetControl((Control)x);
            }

            return controllist;

        }
    }
}
