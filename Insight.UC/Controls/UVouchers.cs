﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Insight.Domain.Common;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Events;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Scalable.Shared.Enums;

namespace Insight.UC.Controls
{
    public partial class UVouchers : UPicklist
    {
        protected Daybook _selectedDaybook;
        protected FDaybooks _fDaybooks;
        protected CashBankTransactionType TransactionType;

        public UVouchers()
        {
            SearchProperty = "Account";
            InitializeComponent();
        }

        protected virtual void BuildColumns()
        {
            ListView.Columns.Clear();

            ListView.Columns.Add(new iColumnHeader("DocumentNr", "Doc. Nr", 60));
            ListView.Columns.Add(new iColumnHeader("Daybook", 100));
            ListView.Columns.Add(new iColumnHeader("Date", 70));
            ListView.Columns.Add(new iColumnHeader("Account", true));
            var amountCol = new iColumnHeader("Amount", DataType.Number, 100);
            amountCol.Format = CommonUtil.AmountFormat;
            ListView.Columns.Add(amountCol);
        }

        private void newVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(ProcessNewVoucher);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(toggleSearchBar);
        }

        private void toggleSearchBar()
        {
            if (uSearchBar.Visible)
                hideSearchBar();
            else
                showSearchBar();
        }

        private void hideSearchBar()
        {
            var searchBarHeight = uSearchBar.Height + 2;
            txt.Location = new Point(txt.Location.X, txt.Location.Y - searchBarHeight);
            lvw.Location = new Point(lvw.Location.X, lvw.Location.Y - searchBarHeight);
            lvw.Height += searchBarHeight;
            uSearchBar.Visible = false;
            searchToolStripMenuItem.Text = @"Show Searc&h";
        }

        private void showSearchBar()
        {
            var searchBarHeight = uSearchBar.Height + 2;
            txt.Location = new Point(txt.Location.X, txt.Location.Y + searchBarHeight);
            lvw.Location = new Point(lvw.Location.X, lvw.Location.Y + searchBarHeight);
            lvw.Height -= searchBarHeight;
            uSearchBar.Visible = true;
            searchToolStripMenuItem.Text = @"Hide Searc&h";
        }

        public override void Initialize()
        {
            BuildColumns();
            InitializeList();
            uSearchBar.Initialize();
            uSearchBar.Search += uSearchBar_Search;
            toggleSearchBar();
        }

        void uSearchBar_Search(object sender, VoucherSearchEventArgs e)
        {
            initializeList(e.Criteria);
        }

        public void InitializeList()
        {
            initializeList(new VoucherSearchCriteria());
        }

        private void initializeList(VoucherSearchCriteria criteria)
        {
            Repository = GetRepository(criteria);
            FillList(true);
        }

        protected virtual IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            throw new NotImplementedException("This method would have been overiden by derived class");
        }

        private void showVoucherForm(TransactionHeader header)
        {
            var voucherForm = new FVoucher(header, _fDaybooks, TransactionType);
            voucherForm.ShowDialog();
            FillList(true);
        }

        protected bool IsDaybookSelected(DaybookType type = DaybookType.Unknown)
        {
            _fDaybooks = new FDaybooks(type);
            if (_fDaybooks.ShowDialog() == DialogResult.OK)
            {
                _selectedDaybook = _fDaybooks.Daybook;
                return true;
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var e = new KeyEventArgs(((Keys)((int)msg.WParam)) | ModifierKeys);
            return processKeyMessage(e);
        }

        private bool processKeyMessage(KeyEventArgs e)
        {
            if (processSearchBarKey(e))
                return true;

            if (processSearch(e))
                return true;

            if (processRefresh(e))
                return true;

            if (processNew(e))
                return true;

            return false;
        }

        private bool processSearchBarKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
            {
                toggleSearchBar();
                uSearchBar.Focus();
                return true;
            }

            return false;
        }

        private bool processSearch(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.Control)
            {
                if (uSearchBar.Visible)
                    uSearchBar.btnSearch.PerformClick();

                return true;
            }

            return false;
        }

        private bool processRefresh(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && e.Modifiers == Keys.None)
            {
                FillList(true);
                return true;
            }

            return false;
        }

        private bool processNew(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                ProcessNewVoucher();
                return true;
            }

            return false;
        }

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            var header = GetTransactionHeader(e);
            showVoucherForm(header);
            base.OnItemOpened(e);
        }

        protected virtual TransactionHeader GetTransactionHeader(PicklistItemEventArgs e)
        {
            return ((TransactionListItem)e.PicklistItem).TransactionHeader;
        }

        protected void fillVoucherDetails(TransactionHeader header, TransactionHeader trans)
        {
            header.Account = trans.Account;
            header.Daybook = trans.Daybook;
            header.CompanyPeriod = trans.CompanyPeriod;
        }

        protected virtual void ProcessNewVoucher()
        {
            var header = TransactionFactory.GetTransactionHeader(TransactionType, _selectedDaybook.Entity.Type);
            header.Daybook = _selectedDaybook;
            showVoucherForm(header);
        }
    }
}
