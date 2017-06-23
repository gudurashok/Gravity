using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Scalable.Win.Forms
{
    public partial class FList : FFormBase
    {
        #region Properties

        private object[] _picklistItems;
        public object[] PicklistItems
        {
            get { return _picklistItems; }
            set
            {
                _picklistItems = value;
                //uPicklist.SelectedItems = _picklistItems; //TODO: ...
            }
        }

        #endregion

        #region Constructor

        private FList()
        {
            InitializeComponent();
        }

        public FList(UPicklist picklist)
            : this()
        {
            uPicklist = picklist;
            uPicklist.Location = new Point(0, pnlHeader.Top + pnlHeader.Height + 1);
            uPicklist.Name = "uPicklist";
            uPicklist.TabIndex = 8;
            uPicklist.ItemSelected += uPicklist_ItemSelected;
            Controls.Add(uPicklist);
        }

        #endregion

        #region Initialize

        public void Initialize()
        {
            var size = uPicklist.MinimumSize.Width == 0 && uPicklist.MinimumSize.Height == 0
                           ? uPicklist.Size
                           : uPicklist.MinimumSize;
            ClientSize = new Size(size.Width, size.Height + pnlHeader.Height);
            uPicklist.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            MinimumSize = Size;
        }

        public void SetFormTitle(string titleText)
        {
            //TODO: could be different texts for Form and header like 
            // "Party Selection" & "Select a party" + text appened from the caller 
            // and its field like Customer, User, Party:Contact, Party:Group, Party:Relation etc.

            Text = titleText; //string.Format("Party: {0}", getFormTitle());
            lblTitle.Text = titleText; //getTitleText();
            //lblTitle2.Text = _party.Addresses.Count > 0 ? _party.Addresses[0].Address.ToString() : string.Empty;
        }

        private void uPicklist_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (SearchBox == null)
            {
                PicklistItems = new[] { e.PicklistItem }; //TODO e.PicklistItem has to be plural/array
                DialogResult = DialogResult.OK;
                return;
            }

            setDisplayMemberValue(e.PicklistItem);
            SearchBox.Value = e.PicklistItem;
            DialogResult = DialogResult.OK;
            SearchBox.Focus();
        }

        private void setDisplayMemberValue(object selectedItem)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.SearchProperty))
                return;

            var pi = selectedItem.GetType().GetProperty(SearchBox.SearchProperty);
            Debug.Assert(pi != null);
            var value = pi.GetValue(selectedItem, null);
            Debug.Assert(value != null);
            SearchBox.TextBox.Text = value.ToString();
        }

        #endregion
    }
}
