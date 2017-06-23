using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Scalable.Win.Controls
{
    public class EnumPanel : Panel
    {
        #region Properties

        [DefaultValue(false)]
        public bool IsFlagged { get; set; }

        public int Value
        {
            get { return getValue(); }
            set { setValue(value); }
        }

        #endregion

        #region Get Value

        private int getValue()
        {
            if (IsFlagged)
                return getSelectedCheckBoxVaues();
            else
                return getSelectedRadioButtonValue();
        }

        private int getSelectedCheckBoxVaues()
        {
            int result = 0;

            return (from CheckBox ctl in Controls.OfType<CheckBox>()
                    where ctl.Tag != null && ctl.Checked
                    select ctl).Aggregate(result, (current, ctl) => current | Convert.ToInt32(ctl.Tag));
        }

        private int getSelectedRadioButtonValue()
        {
            foreach (var ctl in Controls.OfType<RadioButton>()
                    .Where(ctl => ctl.Checked && ctl.Tag != null))
                return Convert.ToInt32(ctl.Tag);

            return 0;
        }

        #endregion

        #region Set Value

        private void setValue(int value)
        {
            if (IsFlagged)
                setCheckBoxValues(value);
            else
                setRadioButtonValue(value);
        }

        private void setCheckBoxValues(int value)
        {
            foreach (var ctl in Controls.OfType<CheckBox>()
                                .Where(ctl => ctl.Tag != null))
                ctl.Checked = Convert.ToBoolean(Convert.ToInt32(ctl.Tag) & value);
        }

        private void setRadioButtonValue(int value)
        {
            foreach (var ctl in Controls.OfType<RadioButton>()
                    .Where(ctl => Convert.ToInt32(ctl.Tag) == value))
            {
                ctl.Checked = true;
                return;
            }
        }

        #endregion
    }
}
