using System;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Forms;

namespace Synergy.UC.Controls
{
    public partial class UTaskTemplates : UPicklist
    {
        public UTaskTemplates()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new TaskTemplates();
            FillList();
            hookEventHandlers();
        }

        private void hookEventHandlers()
        {
            ItemOpened += UTaskTemplates_ItemOpened;
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
        }

        void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            setCommandButtonState();
        }

        private void setCommandButtonState()
        {
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
            btnOpen.Enabled = ListView.HasAnyItemsSelected();
            btnOK.Enabled = ListView.HasAnyItemsSelected();
        }

        void UTaskTemplates_ItemOpened(object sender, PicklistItemEventArgs e)
        {
            showTemplateForm(e.PicklistItem as TaskTemplate);
        }

        private void showTemplateForm(TaskTemplate template)
        {
            var fTemplate = new FTaskTemplate(template);
            fTemplate.ShowDialog();
            FillList(true);
        }

        private void buildColumns()
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        private void commandButtons_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandButtonActions, sender);
        }

        private void processCommandButtonActions(object sender)
        {
            if (CommandBar[sender].IsNew())
                processNewTemplate();

            if (CommandBar[sender].IsDelete())
                deleteSelectedTemplate();
        }

        private void deleteSelectedTemplate()
        {
            var selectedTemplate = getSelectedItemArgs().PicklistItem as TaskTemplate;
            if (selectedTemplate == null)
                return;

            var dialog = MessageBoxUtil.GetConfirmationYesNo(string.Format("Are you sure to delete {0} template",
                                                                  selectedTemplate.Entity.Name));
            if (dialog != DialogResult.Yes)
                return;

            var repo = new TaskRepository();
            repo.DeleteById(selectedTemplate.Entity.Id);

            FillList(true);
            setCommandButtonState();
        }

        private void processNewTemplate()
        {
            showTemplateForm(TaskTemplate.New());
        }
    }
}
