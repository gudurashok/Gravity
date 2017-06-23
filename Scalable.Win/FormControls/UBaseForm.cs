using System.Diagnostics;
using System.Windows.Forms;
using Scalable.Win.Controls;
using Scalable.Win.DataBinding;
using Scalable.Win.Enums;
using System.ComponentModel;

namespace Scalable.Win.FormControls
{
    public partial class UBaseForm : UserControl
    {
        #region Properties

        private object _dataSource;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual object DataSource
        {
            get
            {
                new DataFiller(this, _dataSource, DataFillerAction.FillObject).Execute();
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                new DataFiller(this, _dataSource, DataFillerAction.FillForm).Execute();
            }
        }

        #endregion

        #region Constructor

        public UBaseForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Keyboard Navigation

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //TODO: pressing Shift + M or Shift + O is moving to next/prev field
            // As a temporary patch is applied to return if keys are M or O
            if ((keyData & Keys.M) == Keys.M || (keyData & Keys.O) == Keys.O ||
                    (keyData & Keys.OemQuestion) == Keys.OemQuestion ||
                        ((keyData & Keys.OemMinus) == Keys.OemMinus && (keyData & Keys.Shift) == Keys.Shift))
                return base.ProcessCmdKey(ref msg, keyData);

            moveBetweenFields(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void moveBetweenFields(Keys keyData)
        {
            if (ActiveControl is UBaseForm || ActiveControl is SplitContainer)
                return;

            if (isButtonControl(ActiveControl))
                return;

            if (isTextBoxWithMultiline(ActiveControl))
                return;

            if (isRichTextBoxWithMultiline(ActiveControl))
                return;

            if (isArrowKey(keyData))
            {
                if (isListControl(ActiveControl))
                    return;

                if (isDateTimePickerControl(ActiveControl))
                    return;

                if (isNumericUpDownControl(ActiveControl))
                    return;
            }

            if (shouldMoveBetweenControls(keyData))
                SelectNextControl(ActiveControl, moveForward(keyData), true, true, true);
        }

        private bool isNumericUpDownControl(Control control)
        {
            return control is iNumericUpDown || control is NumericUpDown;
        }

        private bool isDateTimePickerControl(Control control)
        {
            return control is iDateTimePicker || control is DateTimePicker;
        }

        private bool isTextBoxWithMultiline(Control control)
        {
            if (!(control is iTextBox) && !(control is TextBox))
                return false;

            var txt = (control as TextBox);
            return txt.Multiline;
        }

        private bool isRichTextBoxWithMultiline(Control control)
        {
            if (!(control is iRichTextBox) && !(control is RichTextBox))
                return false;

            var rtb = (control as RichTextBox);
            return rtb.Multiline;
        }

        private bool isListControl(Control control)
        {
            return control is iListView || control is iComboBox || control is ListControl;
        }

        private bool isButtonControl(Control control)
        {
            return control is iButton || control is Button;
        }

        private bool shouldMoveBetweenControls(Keys keyData)
        {
            if (isAltKey(keyData) || isControlKey(keyData))
                return false;

            return isEnterOrArrowKey(keyData);
        }

        private bool isEnterOrArrowKey(Keys keyData)
        {
            if (isEnterKey(keyData) || isShiftEnterKey(keyData))
                return true;

            return isArrowKey(keyData);
        }

        private static bool isArrowKey(Keys keyData)
        {
            return keyData == Keys.Down ||
                   keyData == Keys.Up;
        }

        private bool moveForward(Keys keyData)
        {
            return keyData == Keys.Down ||
                    isEnterKey(keyData);
        }

        private bool isEnterKey(Keys keyData)
        {
            return keyData == Keys.Enter;
        }

        private bool isShiftEnterKey(Keys keyData)
        {
            return (keyData & Keys.Shift) == Keys.Shift &&
                    (keyData & Keys.Enter) == Keys.Enter;
        }

        private bool isAltKey(Keys keyData)
        {
            return (keyData & Keys.Alt) == Keys.Alt;
        }

        private bool isControlKey(Keys keyData)
        {
            return (keyData & Keys.Control) == Keys.Control;
        }

        #endregion

        #region Data Binding

        protected virtual void setDataBindings(object dataSource)
        {
            new DataFiller(this, dataSource, DataFillerAction.SetDataBinding).Execute();
        }

        #endregion
    }
}
