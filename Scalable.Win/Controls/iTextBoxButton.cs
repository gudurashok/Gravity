using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Scalable.Shared.Extensions;
using Scalable.Shared.Model;
using Scalable.Win.Events;
using Scalable.Win.Forms;

namespace Scalable.Win.Controls
{
    public partial class iTextBoxButton : UserControl
    {
        public event PicklistItemSelectedEventHandler ItemSelected;

        #region Properties

        //[DefaultValue(AutoCompleteMode.None)]
        //public AutoCompleteMode AutoCompleteMode
        //{
        //    set { TextBox.AutoCompleteMode = value; }
        //}

        [DefaultValue(null),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public FList PickList { get; set; }

        [DefaultValue(null)]
        public string SearchProperty { get; set; }

        private object _value;

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                TextBox.Text = _value == null ? "" : getDisplayMemberValue(_value);
            }
        }

        #endregion

        public iTextBoxButton()
        {
            InitializeComponent();
            initialize();
            TextBox.Search += txt_Search;
            TextBox.KeyDown += txt_KeyDown;
            TextBox.Leave += txt_Leave;
            Button.Click += btn_Click;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                Value = null;
                return;
            }

            if (Value != null)
            {
                if (!TextBox.Text.Equals(getDisplayMemberValue(_value)))
                    TextBox.Text = getDisplayMemberValue(_value);

                OnItemSelected(new PicklistItemEventArgs(Value));
                return;
            }

            Button.PerformClick();
            if (Value == null)
                Focus();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsF4())
                Button.PerformClick();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (PickList == null)
                return;

            if (String.IsNullOrWhiteSpace(PickList.uPicklist.SearchProperty))
                PickList.uPicklist.SearchProperty = SearchProperty;

            PickList.SearchBox = this;
            PickList.uPicklist.FillList();
            PickList.uPicklist.txt.Text = TextBox.Text;
            PickList.uPicklist.SearchItem(TextBox.Text);
            var result = PickList.ShowDialog();
            if (result == DialogResult.OK)
                OnItemSelected(new PicklistItemEventArgs(Value));
            else
                TextBox.Select();
        }

        private void txt_Search(object sender, PicklistSearchEventArgs e)
        {
            if (PickList == null)
                return;

            if (e.SearchText.Length == 0)
            {
                e.Result = new PicklistSearchResult(e.SearchText, null);
                Value = e.Result.Value;
                return;
            }

            const int count = 1; //TODO: could be used increased for switching with F6...
            var result = PickList.uPicklist.Repository.SearchItems(new PicklistSearchCriteria(e.SearchText, count));
            e.Result = new PicklistSearchResult(result.Count == 0 ? e.SearchText : getDisplayMemberValue(result[0]), result.Count == 0 ? null : result[0]);
            Value = e.Result.Value;

            //var result = PickList.uPicklist.ListData.FirstOrDefault(i => match(i, e.SearchText));
            //e.Result = new SearchResult(result == null ? e.SearchText : getDisplayMemberValue(result), result);
            //Value = e.Result.Value;
        }

        private string getDisplayMemberValue(object item)
        {
            var value = getPropertyValue(item, SearchProperty);
            if (value == null)
                return "";

            return value.ToString();
        }

        //private bool match(object item, string searchText)
        //{
        //    Debug.Assert(SearchProperty != null && !string.IsNullOrWhiteSpace(SearchProperty), "SearchProperty is Null/Empty");

        //    var value = getPropertyValue(item, SearchProperty);
        //    if (value == null)
        //        return false;

        //    return value.ToString().StartsWith(searchText, StringComparison.OrdinalIgnoreCase);
        //}

        private object getPropertyValue(object item, string propertyName)
        {
            var pi = item.GetType().GetProperty(propertyName);
            Debug.Assert(pi != null, string.Format("Cannot find property name: {0} on object. Column name used for value member.", propertyName));
            return pi.GetValue(item, null);
        }

        private void initialize()
        {
            TextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            Button.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            Width = TextBox.Width++ + Button.Width;

            TextBox.Location = new Point(0, 0);
            Button.Height = TextBox.Height + 2;
            Button.Location = new Point(TextBox.Width, -1);

            TextBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            TextBox.AutoCompleteMode = AutoCompleteMode.Append;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            initialize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = TextBox.Height;
        }

        protected virtual void OnItemSelected(PicklistItemEventArgs e)
        {
            if (ItemSelected != null)
                ItemSelected(this, e);
        }
    }
}
