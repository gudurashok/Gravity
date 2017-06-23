using System.Collections.Generic;
using System.Windows.Forms;
using Scalable.Win.Events;
using Scalable.Win.Forms;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Forms
{
    public partial class FSuggestions : FFormBase
    {
        private readonly string _searchText;
        public string SelectedSuggestion;
        public IList<string> Suggestions
        {
            set
            {
                uSuggestions.Repository = new Suggestions(value);
                uSuggestions.FillList(true);
            }
        }

        public FSuggestions(string searchText)
        {
            InitializeComponent();
            _searchText = searchText;
            setFormTitle();
            uSuggestions.SearchProperty = "SuggestionItem";
            uSuggestions.ItemOpened += uSuggestions_ItemOpened;
        }

        private void setFormTitle()
        {
            Text = @"Suggestions";
            lblTitle.Text = string.Format("Suggestions for \"{0}\"", _searchText);
        }

        void uSuggestions_ItemOpened(object sender, PicklistItemEventArgs e)
        {
            SelectedSuggestion = ((Suggestion)e.PicklistItem).SuggestionItem;
            DialogResult = DialogResult.OK;
        }
    }
}
