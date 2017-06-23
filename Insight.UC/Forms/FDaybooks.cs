using System;
using System.Drawing;
using System.Windows.Forms;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Picklists;
using Scalable.Win.Events;
using Scalable.Win.Forms;

namespace Insight.UC.Forms
{
    public partial class FDaybooks : FFormBase
    {
        private readonly DaybookType _type;
        public Daybook Daybook { get; set; }

        public FDaybooks(DaybookType type = DaybookType.Unknown)
        {
            _type = type;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var uDaybooks = PicklistFactory.DaybooksOfType(_type).Control;
            uDaybooks.Initialize();
            uDaybooks.FillList(true);
            uDaybooks.ItemSelected += uDaybooks_ItemSelected;
            uDaybooks.Location = new Point(0, pnlHeader.Height);
            uDaybooks.Size = new Size(ClientSize.Width, ClientSize.Height - pnlHeader.Height);
            uDaybooks.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Controls.Add(uDaybooks);
            setFormTitle();
        }

        void uDaybooks_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            Daybook = ((DaybookListItem)e.PicklistItem).Daybook;
            DialogResult = DialogResult.OK;
        }

        private void setFormTitle()
        {
            Text = @"Daybooks";
            lblTitle.Text = @"Select daybook";
        }
    }
}
