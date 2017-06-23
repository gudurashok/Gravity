using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyDates : UBaseForm
    {
        private IList<PartyDate> _dates;

        public UPartyDates()
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
            cmbTitle.DataSource = ReferenceList.GetList(ListType.DateTypes);
            cmbTitle.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 100));
            ListView.Columns.Add(new iColumnHeader("DateValue", "Date", true));
        }

        public override object DataSource
        {
            get
            {
                return _dates;
            }
            set
            {
                _dates = (value as IList<PartyDate>).Select(d => d).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_dates);
            processItemSelection();
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
            var date = ListView.HasAnyItemsSelected() ? getSelectedDate() : new PartyDate();
            cmbTitle.Text = date.Label;
            dtpDate.Value = date.Value == DateTime.MinValue ? DateTime.Today : date.Value;
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addDate);
        }

        void addDate()
        {
            var date = new PartyDate();
            fillDate(date);
            validate(date);
            _dates.Add(date);
            fillForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateDate);
        }

        private void updateDate()
        {
            var date = getSelectedDate();
            fillDate(date);
            validate(date);
            fillForm();
        }

        private void validate(PartyDate date)
        {
            date.Validate();
            var selectedDate = _dates.Where(d => d != date)
                                    .SingleOrDefault(e => e.Label == cmbTitle.Text.Trim() &&
                                                        e.Value.Date == dtpDate.Value.Date);
            if (selectedDate != null)
                throw new ValidationException(Resources.DateWithSameTitleAlreadyExist);
        }

        private void fillDate(PartyDate date)
        {
            date.Label = cmbTitle.Text.Trim();
            date.Value = dtpDate.Value.Date;
        }

        private PartyDate getSelectedDate()
        {
            return ListView.SelectedItems.Count > 0
                        ? (PartyDate)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteDate);
        }

        private void deleteDate()
        {
            var date = getSelectedDate();
            _dates.Remove(date);
            fillForm();
            processItemSelection();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
