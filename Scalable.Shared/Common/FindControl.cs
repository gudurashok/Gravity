using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scalable.Shared.Common
{
    public static class FindControl
    {
        public static void SetFocusToControl(object sender, string propertyName)
        {
            if (String.IsNullOrWhiteSpace(propertyName))
                return;

            var control = sender as Control;
            if (control == null)
                return;

            var form = control.FindForm();

            //var result = (from ctl in form.Descendants<Control>()
            //              where ctl.Tag != null && ctl.Tag.ToString().Equals(propertyName)
            //              select ctl).FirstOrDefault();

            var result = form.Descendants<Control>()
                .FirstOrDefault(c => c.Tag != null &&
                                     c.Tag.ToString().Equals(propertyName));

            if (result == null)
                return;

            result.Focus();
        }

        public static Control GetControl(Control.ControlCollection controls, Predicate<Control> match)
        {
            //USAGE:
            //Control control = GetControl(this.Controls, ctl => ctl.TabIndex == 9);
            //Control control = GetControl(this.Controls, ctl => ctl.Text == "Some text");

            foreach (Control control in controls)
            {
                if (match(control)) return control;

                if (control.Controls.Count <= 0) continue;
                var result = GetControl(control.Controls, match);
                if (result != null) return result;
            }

            return null;
        }

        public static IEnumerable<T> Descendants<T>(this Control control) where T : class
        {
            foreach (Control child in control.Controls)
            {
                var childOfT = child as T;
                if (childOfT != null)
                    yield return childOfT;

                if (child.HasChildren)
                    foreach (var descendant in Descendants<T>(child))
                        yield return descendant;
            }
        }
    }
}
