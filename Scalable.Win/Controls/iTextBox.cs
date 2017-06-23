using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Shared.Enums;
using Scalable.Win.Events;

namespace Scalable.Win.Controls
{
    public class iTextBox : TextBox, ITextBoxBase
    {
        #region Declarations

        private readonly iTextBoxProcessor _textBoxProcessor;

        #endregion

        #region Properties

        [DefaultValue(null)]
        public string InputFilterExpr
        {
            get { return _textBoxProcessor.InputFilterExpr; }
            set { _textBoxProcessor.InputFilterExpr = value; }
        }

        [DefaultValue(TextCaseStyle.Normal)]
        public TextCaseStyle AutoCasing
        {
            get { return _textBoxProcessor.AutoCasing; }
            set { _textBoxProcessor.AutoCasing = value; }
        }

        public event PicklistSearchEventHandler Search;

        #endregion

        #region Constructor

        public iTextBox()
        {
            _textBoxProcessor = new iTextBoxProcessor(this);
            _textBoxProcessor.Search += _textBoxProcessor_Search;
        }

        void _textBoxProcessor_Search(object sender, PicklistSearchEventArgs e)
        {
            OnSearch(e);
        }

        protected virtual void OnSearch(PicklistSearchEventArgs e)
        {
            if (Search != null)
                Search(this, e);
        }

        #endregion

        #region Event Handlers

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _textBoxProcessor.ProcessOnEnter();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.Handled)
                return;

            if ((ModifierKeys & Keys.Control) == Keys.Control ||
                (ModifierKeys & Keys.Alt) == Keys.Alt)
                return;

            if (!string.IsNullOrWhiteSpace(InputFilterExpr) &&
                !_textBoxProcessor.IsKeyCharValid(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (AutoCompleteMode == AutoCompleteMode.None)
                _textBoxProcessor.PerformAutoCasing(e);
            else if (e.KeyChar != '\r')
                _textBoxProcessor.PerformAutoCompletion(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _textBoxProcessor.ProcessOnKeyDown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            EventHandlerExecutor.Execute(processTextChanged);
        }

        void processTextChanged()
        {
            if (string.IsNullOrWhiteSpace(InputFilterExpr) || string.IsNullOrWhiteSpace(Text) || ReadOnly)
                return;

            if (Text.Any(ch => !_textBoxProcessor.IsKeyCharValid(ch)))
            {
                Text = null;
                throw new ValidationException("Text not matching with given input expresssion");
            }
        }

        #endregion
    }
}
