using DevExpress.Utils.Extensions;
using DevExpress.XtraTab.Buttons;
using ExpertService.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertServis.WindowForm
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public UserTable User  { get; set; }
        public Main(UserTable user )
        {
            User = user;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            User.Dosyalar.ForEach(x => 
            {
                //new AccordionControlElement();
            });
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }
    }
    }

