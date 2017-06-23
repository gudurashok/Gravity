using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Enums;
using Scalable.Win.Events;

namespace Scalable.Win.Controls
{
    public class iComboBox : ComboBox, ITextBoxBase
    {
        #region Declarations

        private readonly iTextBoxProcessor _textBoxProcessor;

        #endregion

        #region Constructor

        public iComboBox()
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

        public void SelectItem(Func<dynamic, bool> predicate)
        {
            SelectedItem = (DataSource as IEnumerable<dynamic>).FirstOrDefault(predicate);
        }

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

        #region Event Handlers

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (DropDownStyle != ComboBoxStyle.DropDown)
                return;

            _textBoxProcessor.ProcessOnEnter();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (DropDownStyle != ComboBoxStyle.DropDown)
                return;

            base.OnKeyPress(e);

            if (e.Handled)
                return;

            if (!string.IsNullOrWhiteSpace(InputFilterExpr) &&
                !_textBoxProcessor.IsKeyCharValid(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.Handled)
                return;

            //if (AutoCompleteMode == AutoCompleteMode.None)
            //    _textBoxProcessor.PerformAutoCasing(e);
            //else
            //{

            //var oldText = getOldInputText();
            //var index = FindString(oldText + e.KeyChar);
            //if (index < 0)
            //    return;

            //SelectedIndex = index;
            //e.Handled = true;
            //Select(oldText.Length, Text.Length - oldText.Length);

            //_textBoxProcessor.PerformAutoCompletion(e);
            //}
        }

        //private string getOldInputText()
        //{
        //    return Text.Substring(0, SelectionStart);
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (DropDownStyle != ComboBoxStyle.DropDown)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    SelectedIndex = -1;
                    return;
                }

                return;
            }

            _textBoxProcessor.ProcessOnKeyDown(e);
        }

        #endregion

        #region Data binding

        public void Databind(string valueMember, string displayMember, IEnumerable<dynamic> dataSource)
        {
            ValueMember = valueMember;
            DisplayMember = displayMember;
            DataSource = dataSource;
        }

        public void Databind(string valueMember, string displayMember, IEnumerable<dynamic> dataSource, int selectedIndex)
        {
            Databind(valueMember, displayMember, dataSource, null, selectedIndex);
        }

        public void Databind(string valueMember, string displayMember, IEnumerable<dynamic> dataSource, Func<dynamic, bool> predicate, int selectedIndex)
        {
            if (predicate != null)
                dataSource = dataSource.Where(predicate).ToList();

            Databind(valueMember, displayMember, dataSource);

            if (HasItems())
                SelectedIndex = selectedIndex;
        }

        public void Databind(string valueMember, string displayMember, IEnumerable<dynamic> dataSource, Func<dynamic, bool> predicate, object selectedItem)
        {
            if (predicate != null)
                dataSource = dataSource.Where(predicate).ToList();
            
            Databind(valueMember, displayMember, dataSource);

            if (HasItems())
                SelectedItem = selectedItem;
        }

        public void Databind(string valueMember, string displayMember, IEnumerable<dynamic> dataSource, object selectedItem)
        {
            Databind(valueMember, displayMember, dataSource, null, selectedItem);
        }

        public bool HasItems()
        {
            return Items.Count > 0;
        }

        #endregion
    }
}
