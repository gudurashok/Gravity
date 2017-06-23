using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Events;

namespace Scalable.Win.FormControls
{
    public partial class UListView : UFormBase
    {
        #region Declarations

        private bool isListFilled;
        public event PicklistItemSelectedEventHandler ItemSelected;

        #endregion

        #region Properties

        //private object[] _selectedItems;

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DefaultValue(null)]
        //[Browsable(false)]
        //public object[] SelectedItems
        //{
        //    get { return _selectedItems; }
        //    set
        //    {
        //        _selectedItems = value;
        //        SearchItem()...;
        //    }
        //}

        private IListRepository _repository;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Browsable(false)]
        public IListRepository Repository
        {
            get { return _repository; }
            set
            {
                _repository = value;
                isListFilled = false;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Browsable(false)]
        protected IEnumerable<dynamic> ListData
        {
            set { lvw.FillData(value); }
        }

        [DefaultValue(null)]
        public string SearchProperty { get; set; }

        public void FillList(bool forceFill = false)
        {
            if (isListFilled && !forceFill)
                return;

            fillListInternal();
            isListFilled = true;
        }

        private void fillListInternal()
        {
            if (Repository == null)
                return;

            //TODO: lvw.GetVisibleRowCount()))
            const int pageSize = 1024;

            var data = Repository.SearchItems(new PicklistSearchCriteria(true, pageSize));
            lvw.FillData(data);

            if (!lvw.HasOnlyOneItemSelected())
                txt.Clear();

            txt.Select();
        }

        public iListView ListView
        {
            get { return lvw; }
        }

        #endregion

        #region Constructor

        protected UListView()
        {
            InitializeComponent();
            hookEventHandlers();
        }

        private void hookEventHandlers()
        {
            lvw.DoubleClick += lvw_DoubleClick;
            txt.Search += txt_Search;
            lvw.ItemSelectionChanged += lvw_ItemSelectionChanged;
        }

        void lvw_DoubleClick(object sender, EventArgs e)
        {
            raiseItemSelectedEvent();
        }

        public virtual void Initialize()
        {
            //Should be overridden
        }

        #endregion

        #region Item Selection

        protected void raiseItemSelectedEvent()
        {
            if (lvw.SelectedItems.Count == 0)
                return;

            //TODO:... need store selectedItems probably
            OnItemSelected(getSelectedItemArgs());
        }

        protected virtual void OnItemSelected(PicklistItemEventArgs e)
        {
            if (ItemSelected != null)
                ItemSelected(this, e);
        }

        protected PicklistItemEventArgs getSelectedItemArgs()
        {
            return new PicklistItemEventArgs(lvw.SelectedItems[0].Tag);
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && lvw.Focused)
                txt.Text = getSearchPropertyValue(e.Item);
        }

        #endregion

        #region KeyPress Handling

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    raiseItemSelectedEvent();
                    break;
                case Keys.F4:
                    if (ModifierKeys == Keys.None)
                        txt.Focus();
                    break;
                case Keys.D:
                    if (ModifierKeys == Keys.Alt)
                        txt.Focus();
                    break;
                case Keys.F5:
                    if (ModifierKeys == Keys.None)
                        fillListInternal();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Text Searching

        private void txt_Search(object sender, PicklistSearchEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.SearchText))
                return;

            var lvi = SearchItem(e.SearchText);
            if (lvi == null)
                return;

            e.Result = new PicklistSearchResult(Text = getSearchPropertyValue(lvi), null);
        }

        //TODO: need to think more on this...
        //public ListViewItem SearchItem(object picklistItem)
        //{
        //    if (lvw.Items.Count == 0)
        //        return null;

        //    var lvi = lvw.Items.Cast<ListViewItem>()
        //        .FirstOrDefault(i => i.Tag.Equals(picklistItem));

        //    if (lvi == null)
        //        return null;

        //    lvi.Selected = true;
        //    return lvi;
        //}

        public ListViewItem SearchItem(string searchText)
        {
            if (lvw.Items.Count == 0)
                return null;

            var lvi = lvw.Items.Cast<ListViewItem>()
                .FirstOrDefault(i => searchPropertyValue(i, searchText));

            if (lvi == null)
                return null;

            lvi.Selected = true;
            return lvi;
        }

        private bool searchPropertyValue(ListViewItem item, string searchText)
        {
            var value = getSearchPropertyValue(item);
            return value.StartsWith(searchText, true, null);
        }

        private string getSearchPropertyValue(ListViewItem item)
        {
            var value = getPropertyValue(item.Tag, SearchProperty);
            if (value == null)
                return "";

            return value.ToString();
        }

        private object getPropertyValue(object item, string propertyName)
        {
            var pi = item.GetType().GetProperty(propertyName);
            Debug.Assert(pi != null, string.Format("Cannot find property name: '{0}' on object. Column name used for value member.", propertyName));
            return pi.GetValue(item, null);
        }

        #endregion
    }
}
