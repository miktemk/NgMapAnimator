using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NgMapAnimator
{
    public class WinformUtils
    {
        public static void MakeTextFieldNumeric(TextBox textBox)
        {
            textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler((sender, args) => {
                args.Handled = !char.IsDigit(args.KeyChar) && !char.IsControl(args.KeyChar);
            });
        }

        public static void BindTextField<T>(TextBox textBox, Func<T> getter, Action<string> setter)
        {
            textBox.Text = "" + getter();
            textBox.TextChanged += (sender, e) => { setter(textBox.Text); };
        }
        public static void BindTextArea<T>(RichTextBox textBox, Func<T> getter, Action<string> setter)
        {
            textBox.Text = "" + getter();
            textBox.TextChanged += (sender, e) => { setter(textBox.Text); };
        }
    }
}
