using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Entities;

namespace Synergy.UC.Controls
{
    public partial class UTaskChecklist : UFormBase
    {
        private IList<ChecklistItemEntity> _checklistItems;
        public event EventHandler SaveChecklist;

        private bool _readonly;
        public bool Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                _readonly = value;
                lvwTaskChecklist.Enabled = !_readonly;
            }
        }

        public UTaskChecklist()
        {
            _checklistItems = new List<ChecklistItemEntity>();
            InitializeComponent();
        }

        public override object DataSource
        {
            get
            {
                return _checklistItems;
            }
            set
            {
                _checklistItems = value as IList<ChecklistItemEntity>;
            }
        }

        public void Initialize()
        {
            buildColumns();
            lvwTaskChecklist.FillData(_checklistItems);
            checkItemsIfStatusDone();
        }

        private void checkItemsIfStatusDone()
        {
            var items = lvwTaskChecklist.Items.Cast<ListViewItem>().ToList();

            foreach (var item in items)
                item.Checked = ((ChecklistItemEntity)item.Tag).IsDone;
        }

        private void buildColumns()
        {
            lvwTaskChecklist.Columns.Add(new iColumnHeader("Nr", 50));
            lvwTaskChecklist.Columns.Add(new iColumnHeader("Name", true));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSaveCheckedItems);
        }

        void processSaveCheckedItems()
        {
            if (!_readonly)
            {
                var result = lvwTaskChecklist.Items.Cast<ListViewItem>().ToList();
                foreach (var item in result)
                    ((ChecklistItemEntity)item.Tag).IsDone = item.Checked;
            }
            OnSaveChecklist(new EventArgs());
        }

        protected virtual void OnSaveChecklist(EventArgs e)
        {
            if (SaveChecklist != null)
                SaveChecklist(this, e);
        }
    }
}
