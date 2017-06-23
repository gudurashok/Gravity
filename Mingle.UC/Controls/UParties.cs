using System;
using Mingle.Domain.ViewModel;
using Mingle.UC.Forms;
using Scalable.Win.Controls;
using Mingle.UC.Events;
using Mingle.Domain.Repositories;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Mingle.Domain.Model;
using System.Windows.Forms;
using Mingle.UC.Properties;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UParties : UPicklist
    {
        #region Declarations

        public event EventHandler<PartySelectedEventArgs> PartyOpened;
        public event EventHandler<PartySelectedEventArgs> PartySelected;

        #endregion

        #region Constructor

        public UParties()
        {
            InitializeComponent();
        }

        #endregion

        #region Loading

        public override void Initialize()
        {
            SearchProperty = "Name";
            build();
            togglePreview();
            HookEventHandlers();
            ListView.SelectTopItem();
        }

        private void build()
        {
            buildColumns();
            Repository = new Parties();
            FillList();
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", 190));
            ListView.Columns.Add(new iColumnHeader("Contact", 190));
            ListView.Columns.Add(new iColumnHeader("Phone", 110));
            ListView.Columns.Add(new iColumnHeader("Location", true));
        }

        public void HookEventHandlers()
        {
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
        }

        #endregion

        #region Item Selected

        protected override void OnItemSelected(PicklistItemEventArgs e)
        {
            OnPartySelected(new PartySelectedEventArgs(e.PicklistItem as Party));
            base.OnItemSelected(e);
        }

        protected virtual void OnPartySelected(PartySelectedEventArgs e)
        {
            if (PartySelected != null)
                PartySelected(this, e);
        }

        #endregion

        #region Open

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            var party = ((PartyListItem)e.PicklistItem).Party;
            party.PopulateFullDetails();
            showPartyForm(party);
            OnPartyOpened(new PartySelectedEventArgs(party));
            base.OnItemOpened(e);
        }

        protected virtual void OnPartyOpened(PartySelectedEventArgs e)
        {
            if (PartyOpened != null)
                PartyOpened(this, e);
        }

        #endregion

        #region Delete

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDeleteParty);
        }

        private void processDeleteParty()
        {
            if (MessageBoxUtil.GetConfirmationYesNo(Resources.DeleteParty) == DialogResult.No)
                return;

            var repo = new PartyRepository();
            repo.DeleteById(getSelectedParty().Entity.Id);
            refreshList();
        }

        private Party getSelectedParty()
        {
            if (ListView.HasAnyItemsSelected())
                return ((PartyListItem)ListView.SelectedItems[0].Tag).Party;

            return null;
        }

        private void refreshList()
        {
            FillList(true);
            setCommandButtonStates();
        }

        #endregion

        #region Preview Party Details

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelectionChangedEvent, sender, e);
        }

        private void processItemSelectionChangedEvent(object sender, EventArgs e)
        {
            setCommandButtonStates();

            if (!uPartyPreview.Visible)
                return;

            var args = (ListViewItemSelectionChangedEventArgs)e;
            previewParty(args.IsSelected ? ((PartyListItem)args.Item.Tag).Party : Party.New());
        }

        private void setCommandButtonStates()
        {
            if (ListView.HasOnlyOneItemSelected())
                enableCommandButtons();
            else
                disableCommandButtons();
        }

        private void enableCommandButtons()
        {
            btnOK.Enabled = true;
            btnOpen.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void disableCommandButtons()
        {
            btnOK.Enabled = false;
            btnOpen.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void previewParty(Party party)
        {
            party.PopulateFullDetails();
            uPartyPreview.FillForm(party);
        }

        #endregion

        #region New party form

        private void newPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewPartyEvent);
        }

        void processNewPartyEvent()
        {
            showPartyForm(Party.New());
        }

        #endregion

        #region Show party form

        private void showPartyForm(Party party)
        {
            var partyForm = new FPartyBasic(party);
            partyForm.ShowDialog();
            FillList(true);
        }

        #endregion

        #region Toggle party preview

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processPreview);
        }

        void processPreview()
        {
            if (!uPartyPreview.Visible && ListView.HasItems())
                previewParty(getSelectedParty() ?? Party.New());

            togglePreview();
        }

        private void togglePreview()
        {
            var previewHeight = uPartyPreview.Height + 2;
            uPartyPreview.Visible = !uPartyPreview.Visible;
            previewToolStripMenuItem.Text = uPartyPreview.Visible ? @"Hide Previe&w" : @"Show Previe&w";
            ListView.Height += uPartyPreview.Visible ? -previewHeight : previewHeight;
        }

        #endregion

        public void HidePreviewBar()
        {
            if(uPartyPreview.Visible)
                togglePreview();
        }
    }
}
