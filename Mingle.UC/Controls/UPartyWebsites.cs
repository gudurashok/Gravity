using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyWebsites : UBaseForm
    {
        private IList<Website> _websites;

        public UPartyWebsites()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            buildColumns();
            fillDropDowns();
        }

        private void fillDropDowns()
        {
            var oldValue = cmbTitle.Text;
            cmbTitle.DataSource = null;
            cmbTitle.DataSource = ReferenceList.GetList(ListType.WebsiteTypes);
            cmbTitle.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 100));
            ListView.Columns.Add(new iColumnHeader("Url", "Website", true));
        }

        public override object DataSource
        {
            get
            {
                return _websites;
            }
            set
            {
                _websites = (value as IList<Website>).Select(w => w).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            fillList();
            processItemSelection();
        }

        private void fillList()
        {
            ListView.FillData(_websites.OrderByDescending(w => w.IsPreferred));
            ListView.BoldListItem(ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((Website) i.Tag).IsPreferred));
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelection);
        }

        void processItemSelection()
        {
            setCommandButtonStates();
            fillControls();
        }

        private void fillControls()
        {
            var website = ListView.HasAnyItemsSelected() ? getSelectedWebsite() : new Website();
            cmbTitle.Text = website.Label;
            txtWebsite.Text = website.Url;
            chkIsActive.Checked = website.IsActive;
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
            btnPreferred.Enabled = ListView.HasAnyItemsSelected();
            chkIsActive.Enabled = ListView.HasAnyItemsSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addWebsite);
        }

        void addWebsite()
        {
            var website = new Website();
            fillWebsite(website);
            validate(website);
            _websites.Add(website);
            fillList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateWebsite);
        }

        private void updateWebsite()
        {
            var website = getSelectedWebsite();
            fillWebsite(website);
            validate(website);
            fillList();
        }

        private void validate(Website website)
        {
            website.Validate();
            var selectedWebsite = _websites.Where(w => w != website)
                                        .SingleOrDefault(e => e.Label == cmbTitle.Text.Trim() &&
                                                            e.Url == txtWebsite.Text.Trim());
            if (selectedWebsite != null)
                throw new ValidationException(Resources.WebsiteWithSameTitleAlreadyExist);
        }

        private void fillWebsite(Website website)
        {
            website.Label = cmbTitle.Text.Trim();
            website.Url = txtWebsite.Text.Trim();
            website.IsActive = true;
        }

        private Website getSelectedWebsite()
        {
            return ListView.SelectedItems.Count > 0
                        ? (Website)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteWebsite);
        }

        private void deleteWebsite()
        {
            var website = getSelectedWebsite();
            _websites.Remove(website);
            fillList();
            processItemSelection();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setPreferred);
        }

        void setPreferred()
        {
            foreach (var website in _websites)
                website.IsPreferred = false;

            var selectedWebsite = getSelectedWebsite();
            selectedWebsite.IsPreferred = true;
            fillList();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var website = getSelectedWebsite();
            if (website != null)
                website.IsActive = chkIsActive.Checked;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
