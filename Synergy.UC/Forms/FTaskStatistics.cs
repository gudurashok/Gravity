using Scalable.Win.Forms;

namespace Synergy.UC.Forms
{
    public partial class FTaskStatistics : FFormBase
    {
        public FTaskStatistics()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            setFormTitle();
            uTaskStatistics.Initialize();
        }

        private void setFormTitle()
        {
            Text = @"Task Statistics";
            lblTitle.Text = @"Task Statistics";
        }
    }
}
