using System.Drawing;
using System.Windows.Forms;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.UC.Common;
using Insight.UC.Controls;
using Insight.UC.Events;
using Scalable.Win.Forms;

namespace Insight.UC.Forms
{
    public partial class FVoucher : FFormBase
    {
        private readonly TransactionHeader _transaction;
        private readonly TransactionType _type;

        public FVoucher()
        {
            InitializeComponent();
        }

        public FVoucher(TransactionHeader transaction, FDaybooks fDaybooks, TransactionType type = TransactionType.None)
            : this()
        {
            _type = type;
            _transaction = transaction;
            initialize();
            var control = VoucherFactory.GetVoucherForm(_transaction.Daybook.Entity.Type, fDaybooks, type);
            initializeVoucherUIControl(control);
            Controls.Add(control);
        }

        private void initializeVoucherUIControl(UVoucher control)
        {
            ClientSize = new Size(control.Width, pnlHeader.Height + control.Height);
            MinimumSize = Size;

            if (control.MaximumSize.Width != 0 && control.MaximumSize.Height != 0)
                MaximumSize = new Size(Size.Width + control.MaximumSize.Width - control.Size.Width,
                                    Size.Height + control.MaximumSize.Height - control.Size.Height);

            control.Location = new Point(-1, pnlHeader.Height);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            control.Initialize();
            control.DataSource = _transaction;
            control.TransactionSaved += control_TransactionSaved;
        }

        void control_TransactionSaved(object sender, VoucherSavedEventArgs e)
        {
            if (e.Action.IsClose())
                DialogResult = DialogResult.OK;
        }

        private void initialize()
        {
            setFormTitle();

            //var daybookForm = new FDaybooks();
            //if (daybookForm.ShowDialog() == DialogResult.OK)
            //    _daybook = daybookForm.Daybook;
        }

        private void setFormTitle()
        {
            Text = string.Format("{0} {1}", _transaction.Daybook.Entity.Type, _type == TransactionType.None ? (object)"" : _type);
            lblTitle.Text = Text;
        }
    }
}
