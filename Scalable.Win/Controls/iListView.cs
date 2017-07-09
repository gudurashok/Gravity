using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using Scalable.Shared.Enums;

namespace Scalable.Win.Controls
{
    public class iListView : ListView
    {
        #region Constructors

        public iListView()
        {
            setupCopyContextMenuItems();
            //setWindowTheme(Handle, "Explorer", null);
        }

        //[DllImport("uxtheme.dll")]
        //private static extern int setWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        #endregion

        #region Alternate Coloring

        public void SetAlternateColor()
        {
            var alternate = false;

            foreach (ListViewItem lvi in Items)
            {
                if (alternate)
                    setAlternateColor(lvi);

                alternate = !alternate;
            }
        }

        private void setAlternateColor(ListViewItem lvi)
        {
            lvi.UseItemStyleForSubItems = true;
            lvi.BackColor = Color.LightYellow;
        }

        #endregion

        #region Copy Items to Clipboard

        private void setupCopyContextMenuItems()
        {
            var copyAllMenuItem = new MenuItem("Copy All");
            var copySelectedMenuItem = new MenuItem("Copy");
            copyAllMenuItem.Click += copyAllMenuItem_Click;
            copySelectedMenuItem.Click += copySelectedMenuItemMenuItem_Click;
            ContextMenu = new ContextMenu(new[] { copyAllMenuItem, copySelectedMenuItem });
        }

        void copySelectedMenuItemMenuItem_Click(object sender, EventArgs e)
        {
            copyItemsToClipboard(SelectedItems.Cast<ListViewItem>());
        }

        void copyAllMenuItem_Click(object sender, EventArgs e)
        {
            copyItemsToClipboard(Items.Cast<ListViewItem>());
        }

        private void copyItemsToClipboard(IEnumerable<ListViewItem> items)
        {
            Clipboard.Clear();

            var text = new StringBuilder();

            foreach (var item in items)
                text.AppendLine(toStringSelectItemText(item));

            Clipboard.SetText(text.ToString());
        }

        private string toStringSelectItemText(ListViewItem item)
        {
            var result = new StringBuilder();

            foreach (var subItem in item.SubItems.Cast<ListViewItem.ListViewSubItem>())
                result.Append(subItem.Text).Append("\t");

            return result.ToString();
        }

        #endregion

        //protected override void OnCacheVirtualItems(CacheVirtualItemsEventArgs e)
        //{
        //    base.OnCacheVirtualItems(e);
        //}

        //protected override void OnRetrieveVirtualItem(RetrieveVirtualItemEventArgs e)
        //{

        //    //VirtualMode = true;
        //    //VirtualListSize = 

        //    base.OnRetrieveVirtualItem(e);
        //}

        //protected override void OnSearchForVirtualItem(SearchForVirtualItemEventArgs e)
        //{
        //    base.OnSearchForVirtualItem(e);
        //}


        #region Declarations

        private bool isListPopulating;

        #endregion

        #region Data Filling

        public void FillData(IEnumerable<dynamic> data, bool selectTopItem = false)
        {
            var index = getCurrentSelectedItemIndex();

            Items.Clear();

            if (noDataExist(data))
            {
                ResizeColumns();
                return;
            }

            isListPopulating = true;

            foreach (var item in data)
                Items.Add(CreateListItem(item));

            if (HasItems())
                if (selectTopItem)
                    SelectTopItem();
                else
                    SelectItem(index, true);

            isListPopulating = false;
            ResizeColumns();
        }

        private int getCurrentSelectedItemIndex()
        {
            return HasAnyItemsSelected() ? SelectedItems[0].Index : 0;
        }

        private static bool noDataExist(IEnumerable<dynamic> data)
        {
            return data == null || data.Count() == 0;
        }

        public ListViewItem CreateListItem(object data)
        {
            //TODO: should use iListViewItem
            var lvi = new ListViewItem(getColumnValue(data, Columns[0] as iColumnHeader));
            lvi.Tag = data;

            for (var i = 1; i < Columns.Count; i++)
                lvi.SubItems.Add(getColumnValue(data, Columns[i] as iColumnHeader));

            return lvi;
        }

        private string getColumnValue(object data, iColumnHeader col)
        {
            var pi = data.GetType().GetProperty(col.Name);
            Debug.Assert(pi != null, string.Format("Property Name '{0}' not found on object '{1}'", col.Name, data));
            var value = pi.GetValue(data, null);
            if (value == null)
                return "";

            //TODO: Use column DataType and auto format accordingly
            if (col.DataType == DataType.Number)
            {
                if (!string.IsNullOrWhiteSpace(col.Format))
                    return Convert.ToDecimal(value).ToString(col.Format);
            }

            return value.ToString();
        }

        #endregion

        #region Search Item

        public ListViewItem SearchItem(string searchText)
        {
            var lvi = FindItemWithText(searchText, true, 0, true);
            if (lvi != null)
                lvi.Selected = true;

            return lvi;
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            base.OnItemSelectionChanged(e);

            if (e.IsSelected)
                highlight(e.Item);
            else
                clearHighlight(e.Item);
        }

        private void clearHighlight(ListViewItem lvi)
        {
            if (lvi == null)
                return;

            lvi.ForeColor = Color.Black;
            lvi.BackColor = Color.White;
            lvi.Selected = false;
        }

        private void highlight(ListViewItem lvi)
        {
            lvi.ForeColor = SystemColors.HighlightText;
            lvi.BackColor = SystemColors.Highlight;
            lvi.EnsureVisible();
        }

        #endregion

        #region Column Auto Resizing

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (isListPopulating)
                return;

            ResizeColumns();
        }

        public void ResizeColumns()
        {
            var resizableColumnCount = getResizableColumnCount();

            if (resizableColumnCount == 0)
                return;

            var resizableWidth = getResizableWidth() / resizableColumnCount;
            var adjustableWidth = resizableWidth;
            var remainderWidth = resizableWidth - adjustableWidth;

            foreach (var column in (Columns.Cast<iColumnHeader>().Where(c => c.AutoResizable)))
                Columns[column.Name].Width += adjustableWidth;

            if (remainderWidth > 0)
                adjustRemainingWidth(remainderWidth);
        }

        private void adjustRemainingWidth(int remainderWidth)
        {
            var column = Columns.Cast<iColumnHeader>().FirstOrDefault(c => c.AutoResizable);
            if (column != null)
                Columns[column.Name].Width += remainderWidth;
        }

        private int getResizableWidth()
        {
            return ClientSize.Width - Columns.Cast<iColumnHeader>().Sum(c => c.Width);
        }

        private int getResizableColumnCount()
        {
            return (Columns.Cast<iColumnHeader>().Where(c => c.AutoResizable)).Count();
        }

        #endregion

        #region Item Selection

        public bool HasItems()
        {
            return (Items.Count > 0);
        }

        public bool HasAnyItemsSelected()
        {
            return (SelectedItems.Count > 0);
        }

        public bool HasOnlyOneItemSelected()
        {
            return (SelectedItems.Count == 1);
        }

        public void SelectLastItem(bool setFocus = false)
        {
            SelectItem(Items.Count - 1, setFocus);
        }

        public void SelectNextItem(ListViewItem selectedItem, bool setFocus = false)
        {
            SelectItem(selectedItem.Index, setFocus);
        }

        public void SelectTopItem(bool setFocus = false)
        {
            SelectItem(0, setFocus);
        }

        public void SelectItem(int index, bool setFocus = false)
        {
            if (Items.Count == 0)
                return;

            if (index < 0)
                index = 0;

            if (index > Items.Count - 1)
                index = Items.Count - 1;

            SelectItem(Items[index], setFocus);
        }

        public void SelectItem(ListViewItem lvi, bool setFocus = false)
        {
            if (lvi == null)
                return;

            lvi.Selected = true;
            lvi.EnsureVisible();

            if (!setFocus)
                return;

            Focus();
        }

        #endregion

        #region Get Visibile Row Count

        public int GetVisibleRowCount()
        {
            return SendMessage(Handle, LVM_GETCOUNTPERPAGE, IntPtr.Zero, IntPtr.Zero);
        }

        private const Int32 LVM_FIRST = 0x1000;
        private const Int32 LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40);

        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        #endregion


        public void BoldListItem(ListViewItem item)
        {
            if (item == null) return;
            item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);
        }
    }
}
