using System;
using Gravity.Root.Common;
using Scalable.Shared.Repositories;
using Scalable.Win.Forms;
using Scalable.Shared.Common;

namespace Gravity.Root.Forms
{
    public partial class FOptions : FFormBase
    {
        private readonly IListRepository _repository;
        
        public FOptions(IListRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        protected override void OnLoad(EventArgs e)
        {
            EventHandlerExecutor.Execute(initilizeForm);
        }

        private void initilizeForm()
        {
            uOptions.Initialize(_repository);
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = string.Format("{0} Options", GravityApplication.GetProductName());
            lblTitle.Text = @"Please setup the following things as required";
        }
    }
}
