using System;
using System.Linq;
using System.Windows.Forms;
using Mingle.Domain.Model;
using Mingle.Domain.Repositories;
using Mingle.Domain.ViewModel;
using Mingle.UC.Common;
using Mingle.UC.Events;
using Mingle.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UParty : UListView
    {
        public event EventHandler<PartySelectedEventArgs> PartySelected;
        public event EventHandler<PartySavedEventArgs> PartySaved;
        private Party _party;

        public UParty()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            ReferenceList.LoadLists();
            buildColumns();
            txbParty.PickList = PicklistFactory.Parties.Form;
            txbParty.ItemSelected += txbParty_ItemSelected;
            Repository = new EntityListRepository();
            FillList();
            SearchProperty = "Caption";
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
            ListView.SelectTopItem(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Caption", true));
        }

        public override object DataSource
        {
            get
            {
                return _party;
            }
            set
            {
                _party = value as Party;
                fillForm();
            }
        }

        private void fillForm()
        {
            txbParty.Value = new PartyListItem { Party = _party };
        }

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedtem, sender, e);
        }

        void processSelectedtem(object sender, EventArgs e)
        {
            var args = (ListViewItemSelectionChangedEventArgs)e;
            var entity = (EntityItem)args.Item.Tag;
            var editor = (UBaseForm)entity.Editor;
            var control = Controls.Find(editor.Name, false).FirstOrDefault();

            if (control == null)
            {
                setLocation(editor);
                editor.DataSource = _party;
                Controls.Add(editor);
            }
            else
                editor = (UBaseForm)control;

            editor.Visible = args.IsSelected;
        }

        private void setLocation(UBaseForm editor)
        {
            editor.Left = ListView.Left + ListView.Width + 2;
            editor.Top = ListView.Top;
            editor.Width = ClientSize.Width - editor.Left - 2;
            editor.Height = ListView.Height;
        }

        void txbParty_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedParty);
        }

        void processSelectedParty()
        {
            _party = getParty();
            OnPartySelected(new PartySelectedEventArgs(_party));
            refreshForm();
        }

        private Party getParty()
        {
            if (txbParty.Value == null)
                return Party.New();

            var party = ((PartyListItem)txbParty.Value).Party;
            if (party.IsNew())
                return Party.New();

            var repo = new PartyRepository();
            return repo.GetById(party.Entity.Id, true);
        }

        void refreshForm()
        {
            Repository = new EntityListRepository();
            reAssignData();
        }

        protected virtual void OnPartySelected(PartySelectedEventArgs e)
        {
            if (PartySelected != null)
                PartySelected(this, e);
        }

        #region Party commandBar button actions

        private void commandBarButton_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandBarAction, sender);
        }

        private void processCommandBarAction(object sender)
        {
            if (CommandBar[sender].IsSave())
                saveParty();
            else if (CommandBar[sender].IsCancel())
                processCancel();

            if (CommandBar[sender].IsNew())
                processNew();

            OnPartySaved(new PartySavedEventArgs(_party, CommandBar[sender]));
        }

        private void saveParty()
        {
            processSaveParty();
            var repo = new PartyRepository();
            repo.Save(_party);

            refreshLists();
        }

        private void processNew()
        {
            DataSource = Party.New();
            reAssignData();
        }

        private void processCancel()
        {
            DataSource = getParty();
            reAssignData();
        }

        protected virtual void OnPartySaved(PartySavedEventArgs e)
        {
            if (PartySaved != null)
                PartySaved(this, e);
        }

        #endregion

        private void processSaveParty()
        {
            foreach (var control in Controls.Cast<object>().Where(control => (control as IParty) != null))
                ((IParty)control).Save();

            ReferenceList.LoadLists();
        }

        private void reAssignData()
        {
            foreach (var control in Controls.Cast<object>().Where(control => (control as IParty) != null))
                ((IParty)control).Control.DataSource = _party;
        }

        private void refreshLists()
        {
            foreach (var control in Controls.Cast<object>().Where(control => (control as IParty) != null))
                ((IParty)control).RefreshLists();
        }

        private void chkEnableSelection_CheckedChanged(object sender, EventArgs e)
        {
            txbParty.Enabled = chkEnableSelection.Checked;
        }
    }
}
