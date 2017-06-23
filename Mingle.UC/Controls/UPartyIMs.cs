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
    public partial class UPartyIMs : UBaseForm
    {
        private IList<InstantMessenger> _ims;

        public UPartyIMs()
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
            fillIMTitles();
            fillIMNames();
        }

        private void fillIMTitles()
        {
            var oldValue = cmbTitle.Text;
            cmbTitle.DataSource = null;
            cmbTitle.DataSource = ReferenceList.GetList(ListType.IMTitleTypes);
            cmbTitle.Text = oldValue;
        }

        private void fillIMNames()
        {
            var oldValue = cmbIMName.Text;
            cmbIMName.DataSource = null;
            cmbIMName.DataSource = ReferenceList.GetList(ListType.IMTypes);
            cmbIMName.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 100));
            ListView.Columns.Add(new iColumnHeader("IMId", "IM Id", true));
            ListView.Columns.Add(new iColumnHeader("IMName", "IM Name", 100));
        }

        public override object DataSource
        {
            get
            {
                return _ims;
            }
            set
            {
                _ims = (value as List<InstantMessenger>).Select(i => i).ToList();
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
            ListView.FillData(_ims.OrderByDescending(i => i.IsPreferred));
            ListView.BoldListItem(
                ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((InstantMessenger) i.Tag).IsPreferred));
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
            var im = ListView.HasAnyItemsSelected() ? getSelectedIM() : new InstantMessenger();
            cmbTitle.Text = im.Label;
            txtIMId.Text = im.ToString();
            cmbIMName.Text = im.IMName;
            chkIsActive.Checked = im.IsActive;
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
            EventHandlerExecutor.Execute(addIM);
        }

        void addIM()
        {
            var im = new InstantMessenger();
            fillIM(im);
            validate(im);
            _ims.Add(im);
            fillList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateIM);
        }

        private void updateIM()
        {
            var im = getSelectedIM();
            fillIM(im);
            validate(im);
            fillList();
        }

        private void validate(InstantMessenger im)
        {
            im.Validate();
            var selectedIM = _ims.Where(i => i != im)
                                .SingleOrDefault(
                                    i => i.Label == cmbTitle.Text.Trim() &&
                                        i.ToString() == txtIMId.Text.Trim() &&
                                        i.IMName == cmbIMName.Text.Trim());

            if (selectedIM != null)
                throw new ValidationException(Resources.ImWithSameDetailsAlreadyExist);
        }

        private void fillIM(InstantMessenger im)
        {
            im.Label = cmbTitle.Text.Trim();
            im.IMId = txtIMId.Text.Trim();
            im.IMName = cmbIMName.Text.Trim();
            im.IsActive = true;
        }

        private InstantMessenger getSelectedIM()
        {
            return ListView.SelectedItems.Count > 0
                        ? (InstantMessenger)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteIM);
        }

        private void deleteIM()
        {
            var im = getSelectedIM();
            _ims.Remove(im);
            fillList();
            processItemSelection();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setPreferred);
        }

        void setPreferred()
        {
            foreach (var im in _ims)
                im.IsPreferred = false;

            var selectedIM = getSelectedIM();
            selectedIM.IsPreferred = true;
            fillList();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var im = getSelectedIM();
            if (im != null)
                im.IsActive = chkIsActive.Checked;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
