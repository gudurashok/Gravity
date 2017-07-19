using System;
using Scalable.Shared.Common;
using Scalable.Win.Events;

namespace Scalable.Win.FormControls
{
    public partial class UPicklist : UListView
    {
        #region Declarations

        private bool isListMode;
        public event PicklistItemSelectedEventHandler ItemOpened;

        #endregion

        #region Constructor

        public UPicklist()
        {
            InitializeComponent();
        }

        #endregion

        #region OK button click - Item Selected

        void btnOK_Click(object sender, EventArgs e)
        {
            raiseItemSelectedEvent();
        }

        #endregion

        #region Item Open

        private void btnOpen_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(raiseItemOpenedEvent);
        }

        private void raiseItemOpenedEvent()
        {
            if (lvw.SelectedItems.Count == 0)
                return;

            OnItemOpened(getSelectedItemArgs());
        }

        protected virtual void OnItemOpened(PicklistItemEventArgs e)
        {
            ItemOpened?.Invoke(this, e);
        }

        #endregion

        public void MakeList()
        {
            btnOK.Hide();
            btnOpen.Size = btnOK.Size;
            btnOpen.Location = btnOK.Location;
            isListMode = true;
        }

        protected override void OnItemSelected(PicklistItemEventArgs e)
        {
            if (isListMode)
                OnItemOpened(e);
            else
                base.OnItemSelected(e);
        }
    }
}
