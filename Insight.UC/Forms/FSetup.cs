using System;
using System.Drawing;
using System.Windows.Forms;
using Insight.UC.Common;
using Scalable.Shared.Common;
using Scalable.Win.Forms;

namespace Insight.UC.Forms
{
    public partial class FSetup : FFormBase
    {
        private readonly ISetup _control;

        public FSetup(ISetup control)
        {
            InitializeComponent();
            _control = control;
        }

        protected override void OnLoad(EventArgs e)
        {
            setFormTitle();
            _control.Initialize();
            setFormSizeForControl();
            _control.ItemSaved += control_ItemSaved;
        }

        private void setFormSizeForControl()
        {
            var control = (UserControl)_control;
            ClientSize = new Size(control.Width, pnlHeader.Height + control.Height);
            MinimumSize = Size;

            if (control.MaximumSize.Width != 0 && control.MaximumSize.Height != 0)
                MaximumSize = new Size(Size.Width + control.MaximumSize.Width - control.Size.Width,
                                    Size.Height + control.MaximumSize.Height - control.Size.Height);

            control.Location = new Point(-1, pnlHeader.Height);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Controls.Add(control);
        }

        void control_ItemSaved(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(Close);
        }

        private void setFormTitle()
        {
            Text = string.Format("Entry Form");
            lblTitle.Text = string.Format("Enter details");
        }
    }
}
