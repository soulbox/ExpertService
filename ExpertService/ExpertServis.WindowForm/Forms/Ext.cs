using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpertServis.WindowForm.Forms
{
    public static class Ext
    {
        public static void Msg(string message, string caption = "Bilgi", MessageBoxButtons buton = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
            => XtraMessageBox.Show(message, caption, buton, icon);
    //    public static void MsgBilgi(string message)
    //=> XtraMessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static DialogResult MsgQuestion(string message,string caption)
=> XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        public static void MsgError(string message, string caption)
=> XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        public static DialogResult MsgErrorQuestion(string message, string caption)
=> XtraMessageBox.Show(message, caption, MessageBoxButtons.YesNo , MessageBoxIcon.Error);
        public   enum ormtype
        {
            add,
            update,
            delete
        }
        static CultureInfo culture = CultureInfo.CreateSpecificCulture("tr-TR");
        public static string ToCultureString(this decimal source)
        {
            return source.ToString("C2", culture);
        }
    }
}
