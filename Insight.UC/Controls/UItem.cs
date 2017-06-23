using System;
using Insight.Domain.Model;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UItem : UFormBase, ISetup
    {
        private Item _item;
        public event EventHandler<EventArgs> ItemSaved;

        public UItem()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            DataSource = Item.New();
            txbItemGroup.PickList = PicklistFactory.ItemGroup.Form;
            txbItemCategory.ItemSelected += txbCategory_ItemSelected;
            txbItemCategory.PickList = PicklistFactory.ItemCategory.Form;
            txbItemGroup.ItemSelected += txbGroup_ItemSelected;
        }

        void txbGroup_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;
        }

        void txbCategory_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;
        }

        public override object DataSource
        {
            get
            {
                FillObject();
                return _item;
            }
            set
            {
                _item = value as Item;
                FillForm();
            }
        }

        private void FillForm()
        {
            txtName.Text = _item.Entity.Name;
            txtCode.Text = _item.Entity.Code;
            txtShortName.Text = _item.Entity.ShortName;
            txbItemCategory.Value = getItemCategory();
            txbItemGroup.Value = getItemGroup();
            chkHasBom.Checked = _item.Entity.HasBom;
            chkIsActive.Checked = _item.Entity.IsActive;
        }

        private ItemGroup getItemGroup()
        {
            return _item.Entity.GroupId == null ? null : (ItemGroup)txbItemGroup.Value;
        }

        private ItemCategory getItemCategory()
        {
            return _item.Entity.CategoryId == null ? null : (ItemCategory)txbItemCategory.Value;
        }

        private void FillObject()
        {
            _item.Entity.Name = txtName.Text;
            _item.Entity.Code = txtCode.Text;
            _item.Entity.CategoryId = getItemCategoryId();
            _item.Entity.GroupId = getItemGroupId();
            _item.Entity.ShortName = txtShortName.Text;
            _item.Entity.HasBom = chkHasBom.Checked;
            _item.Entity.IsActive = chkIsActive.Checked;
        }

        private string getItemGroupId()
        {
            return txbItemGroup.Value == null
                       ? null
                       : ((ItemGroup)txbItemGroup.Value).Entity.Id;
        }

        private string getItemCategoryId()
        {
            return txbItemCategory.Value == null
                       ? null
                       : ((ItemCategory)txbItemCategory.Value).Entity.Id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSave);
        }

        void processSave()
        {
            ((Item)DataSource).Save();
            OnItemSaved(new EventArgs());
        }

        protected virtual void OnItemSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }
    }
}
