using System.Windows.Forms;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Synergy.UC.Controls
{
    public partial class USuggestions : UPicklist
    {
        public USuggestions()
        {
            InitializeComponent();
            MakeList();
            buildColumns();
            lvw.ItemSelectionChanged += lvw_ItemSelectionChanged;
        }

        void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnOpen.Enabled = lvw.HasAnyItemsSelected();
        }

        private void buildColumns()
        {
            lvw.Columns.Add(new iColumnHeader("SuggestionItem", "Suggestions", true));
        }
    }
}
