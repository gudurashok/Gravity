﻿using System;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Shared.Repositories;
using Scalable.Win.FormControls;
using Scalable.Win.Controls;

namespace Gravity.Root.Controls
{
    public partial class UOptions : UListView
    {
        public UOptions()
        {
            InitializeComponent();
        }

        public void Initialize(IListRepository repository)
        {
            buildColoumns();
            Repository = repository;
            FillList();
            SearchProperty = "Caption";
            ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
            ListView.SelectTopItem(true);
        }

        private void buildColoumns()
        {
            ListView.Columns.Add(new iColumnHeader("Caption", true));
        }

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedtem, sender, e);
        }

        void processSelectedtem(object sender, EventArgs e)
        {
            var args = (ListViewItemSelectionChangedEventArgs)e;
            var entity = (EntityItem)args.Item.Tag;
            var control = Controls.Find(entity.Editor.Name, false).FirstOrDefault();

            if (control == null)
            {
                setLocation(entity);
                Controls.Add(entity.Editor);
            }
            else
                entity.Editor = control as UListView;

            if (entity.Editor == null) return;

            if (args.IsSelected)
            {
                entity.Editor.Visible = true;
                entity.Editor.FillList(true);
                return;
            }

            entity.Editor.Visible = false;
        }

        private void setLocation(EntityItem entity)
        {
            entity.Editor.Left = ListView.Left + ListView.Width + 2;
            entity.Editor.Width = ClientSize.Width - entity.Editor.Left - 2;
            entity.Editor.Height = ListView.Height + txt.Height + 2;
        }
    }
}
