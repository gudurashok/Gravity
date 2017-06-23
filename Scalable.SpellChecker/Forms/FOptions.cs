using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Scalable.Win.Forms;

namespace Scalable.SpellChecker.Forms
{
    public partial class FOptions : FFormBase
    {
        private readonly Spelling _spellChecker;

        public FOptions(ref Spelling spell)
        {
            InitializeComponent();
            _spellChecker = spell;
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = @"Options";
            lblTitle.Text = @"Options for spellcheck";
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _spellChecker.IgnoreWordsWithDigits = IgnoreDigitsCheck.Checked;
            _spellChecker.IgnoreAllCapsWords = IgnoreUpperCheck.Checked;
            _spellChecker.IgnoreHtml = IgnoreHtmlCheck.Checked;
            _spellChecker.MaxSuggestions = int.Parse(MaxSuggestions.Text, CultureInfo.CurrentUICulture);
            Close();
        }

        private void FOptions_Load(object sender, EventArgs e)
        {
            IgnoreDigitsCheck.Checked = _spellChecker.IgnoreWordsWithDigits;
            IgnoreUpperCheck.Checked = _spellChecker.IgnoreAllCapsWords;
            IgnoreHtmlCheck.Checked = _spellChecker.IgnoreHtml;
            MaxSuggestions.Text = _spellChecker.MaxSuggestions.ToString(CultureInfo.CurrentUICulture);

            // set dictionary info
            txtCopyright.Text = _spellChecker.Dictionary.Copyright;

            // Get all modules
            var localItems = new ArrayList();
            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                var item = new ListViewItem();
                item.Text = module.ModuleName;

                // Get version info
                var verInfo = module.FileVersionInfo;
                var versionStr = String.Format("{0}.{1}.{2}.{3}",
                    verInfo.FileMajorPart,
                    verInfo.FileMinorPart,
                    verInfo.FileBuildPart,
                    verInfo.FilePrivatePart);
                item.SubItems.Add(versionStr);

                // Get file date info
                var lastWriteDate = File.GetLastWriteTime(module.FileName);
                var dateStr = lastWriteDate.ToString("MMM dd, yyyy", CultureInfo.CurrentUICulture);
                item.SubItems.Add(dateStr);

                assembliesListView.Items.Add(item);

                // Stash assemply related list view items for later
                if (module.ModuleName.ToLower().StartsWith("netspell"))
                    localItems.Add(item);
            }

            // Extract the assemply related modules and move them to the top
            for (var i = localItems.Count; i > 0; i--)
            {
                var localItem = (ListViewItem)localItems[i - 1];
                assembliesListView.Items.Remove(localItem);
                assembliesListView.Items.Insert(0, localItem);
            }
        }
    }
}
