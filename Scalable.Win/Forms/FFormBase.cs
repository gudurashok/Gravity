using System.Windows.Forms;
using Scalable.Win.Controls;

namespace Scalable.Win.Forms
{
    public partial class FFormBase : Form
    {
        #region Constructor

        public FFormBase()
        {
            InitializeComponent();
        } 

        #endregion

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    MoveBetweenFields(e);
        //    //if (e.KeyCode != Keys.Enter || e.Alt || e.Control)
        //    //    return;
        //}

        //private void MoveBetweenFields(KeyEventArgs e)
        //{
        //    if (isListControl(ActiveControl))
        //        return;

        //    if (isButtonControl(ActiveControl))
        //        return;

        //    if (shouldMoveBetweenControls(e))
        //        if (e.Shift)
        //            SendKeys.Send("+{TAB}");
        //        else
        //            SendKeys.Send("{TAB}");

        //        //SelectNextControl(ActiveControl, moveForward(keyData), true, true, true);
        //}

        //private bool isListControl(Control control)
        //{
        //    return control is iListView || control is ListControl;
        //}

        //private bool isButtonControl(Control control)
        //{
        //    return control.GetType() == typeof(Button);
        //}

        //private bool shouldMoveBetweenControls(KeyEventArgs e)
        //{
        //    if (e.Alt || e.Control)
        //        return false;

        //    return isEnterOrArrowKey(e);
        //}

        //private bool isEnterOrArrowKey(KeyEventArgs e)
        //{
        //    if (isEnterKey(e.KeyData) || isShiftEnterKey(e))
        //        return true;

        //    return e.KeyData == Keys.Down ||
        //           e.KeyData == Keys.Up;
        //}

        //private bool moveForward(Keys keyData)
        //{
        //    return keyData == Keys.Down ||
        //            isEnterKey(keyData);
        //}

        //private bool isEnterKey(Keys keyData)
        //{
        //    return keyData == Keys.Enter;
        //}

        //private bool isShiftEnterKey(KeyEventArgs e)
        //{
        //    return (e.Shift & e.KeyCode == Keys.Enter);
        //}
    }
}
