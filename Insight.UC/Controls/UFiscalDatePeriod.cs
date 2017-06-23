using System;
using Insight.Domain.Model;
using Insight.UC.Common;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UFiscalDatePeriod : UFormBase, ISetup
    {
        private FiscalDatePeriod _fiscalDatePeriod;
        public event EventHandler<EventArgs> ItemSaved;

        public UFiscalDatePeriod()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            DataSource = FiscalDatePeriod.New();
            txtName.Text = getPeriodName();
        }

        private string getPeriodName()
        {
            return string.Format("{0}-{1}", dtpFinancialFrom.Value.Year,
                                            dtpFinancialTo.Value.Year);
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _fiscalDatePeriod;
            }
            set
            {
                _fiscalDatePeriod = value as FiscalDatePeriod;
                fillForm();
            }
        }

        private void fillObject()
        {
            _fiscalDatePeriod.Entity.Name = txtName.Text;
            _fiscalDatePeriod.Entity.Financial = new DatePeriod
                                                {
                                                    From = dtpFinancialFrom.Value.Date,
                                                    To = dtpFinancialTo.Value.Date
                                                };
            _fiscalDatePeriod.Entity.Assessment = new DatePeriod
                                                {
                                                    From = dtpAssessmentFrom.Value.Date,
                                                    To = dtpAssessmentTo.Value.Date
                                                };
        }

        private void fillForm()
        {
            dtpFinancialFrom.Value = _fiscalDatePeriod.Entity.Financial == null
                                        ? new DateTime(DateTime.Today.Year, 4, 1)
                                        : _fiscalDatePeriod.Entity.Financial.From;
            dtpFinancialTo.Value = _fiscalDatePeriod.Entity.Financial == null
                                        ? dtpFinancialFrom.Value.AddYears(1).AddDays(-1)
                                        : _fiscalDatePeriod.Entity.Financial.To;
            dtpAssessmentFrom.Value = _fiscalDatePeriod.Entity.Assessment == null
                                        ? dtpFinancialFrom.Value.AddYears(1)
                                        : _fiscalDatePeriod.Entity.Assessment.From;
            dtpAssessmentTo.Value = _fiscalDatePeriod.Entity.Assessment == null
                                        ? dtpAssessmentFrom.Value.AddYears(1).AddDays(-1)
                                        : _fiscalDatePeriod.Entity.Assessment.To;

            txtName.Text = getPeriodName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveFiscalDatePeriod);
        }

        private void saveFiscalDatePeriod()
        {
            ((FiscalDatePeriod)DataSource).Save();
            OnFiscalDatePeriodSaved(new EventArgs());
        }

        protected virtual void OnFiscalDatePeriodSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }

        private void dtpFinancialFrom_Leave(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDates);
        }

        void processDates()
        {
            dtpFinancialTo.Value = dtpFinancialFrom.Value.AddYears(1).AddDays(-1);
            dtpAssessmentFrom.Value = dtpFinancialFrom.Value.AddYears(1);
            dtpAssessmentTo.Value = dtpAssessmentFrom.Value.AddYears(1).AddDays(-1);
            txtName.Text = getPeriodName();
        }

        private void dtpFinancialTo_Leave(object sender, EventArgs e)
        {
            txtName.Text = getPeriodName();
        }
    }
}
