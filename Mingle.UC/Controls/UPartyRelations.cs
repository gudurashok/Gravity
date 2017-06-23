using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.Domain.ViewModel;
using Mingle.UC.Picklists;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyRelations : UBaseForm
    {
        private IList<PersonRelation> _relations;

        public UPartyRelations()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            buildColumns();
            txbContacts.PickList = PicklistFactory.Parties.Form;
            fillDropDowns();
        }

        private void fillDropDowns()
        {
            var oldValue = cmbRelationType.Text;
            cmbRelationType.DataSource = null;
            cmbRelationType.DataSource = ReferenceList.GetList(ListType.RelationTypes);
            cmbRelationType.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Contact", true));
            ListView.Columns.Add(new iColumnHeader("Relation", 120));
        }

        public override object DataSource
        {
            get
            {
                return _relations;
            }
            set
            {
                _relations = (value as IList<PersonRelation>).Select(r => r).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_relations);
            processSelectedRelation();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addRelation);
        }

        void addRelation()
        {
            var relation = new PersonRelation();
            fillRelation(relation);
            relation.Validate();
            validate(relation);
            _relations.Add(relation);
            fillForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateRelation);
        }

        void updateRelation()
        {
            var relation = getSelectedRelation();
            validate(relation);
            fillRelation(relation);
            relation.Validate();
            fillForm();
        }

        private void fillRelation(PersonRelation relation)
        {
            relation.Person = txbContacts.Value == null ? null : ((PartyListItem)txbContacts.Value).Party;
            relation.Relation = cmbRelationType.Text.Trim();
        }

        private PersonRelation getSelectedRelation()
        {
            return ListView.SelectedItems.Count > 0
                        ? (PersonRelation)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteRelation);
        }

        void deleteRelation()
        {
            _relations.Remove(getSelectedRelation());
            fillForm();
            processSelectedRelation();
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedRelation);
        }

        void processSelectedRelation()
        {
            setCommandButtonStates();
            fillControls();
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
        }

        private void fillControls()
        {
            var relation = ListView.HasAnyItemsSelected() ? getSelectedRelation() : new PersonRelation();
            txbContacts.Value = getContact(relation);
            cmbRelationType.Text = relation.Relation;
        }

        private PartyListItem getContact(PersonRelation relation)
        {
            return relation.Person == null ? null : new PartyListItem { Party = relation.Person };
        }

        private void validate(PersonRelation relation)
        {
            var selectedRelation = _relations.Where(r => r != relation)
                                            .SingleOrDefault(c => c.PersonId == getPersonId() &&
                                                                  c.Relation == cmbRelationType.Text.Trim());

            if (selectedRelation != null)
                throw new ValidationException(Resources.RelationAlreadyExistWithSameDetails);
        }

        private string getPersonId()
        {
            return txbContacts.Value == null ? string.Empty : ((PartyListItem)txbContacts.Value).Party.Entity.Id;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
