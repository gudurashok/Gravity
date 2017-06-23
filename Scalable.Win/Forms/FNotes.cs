using System;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Events;

namespace Scalable.Win.Forms
{
    public partial class FNotes : FFormBase
    {
        #region Declarations

        private readonly NotesFormArgs _args;

        #endregion

        #region Constructor

        public FNotes(NotesFormArgs args)
        {
            InitializeComponent();
            _args = args;
            uNotes.Initialize(args);
        }

        #endregion

        #region Initialization

        protected override void OnLoad(EventArgs e)
        {
            EventHandlerExecutor.Execute(initialize);
        }

        void initialize()
        {
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = _args.Caption;
            lblTitle.Text = _args.ReadOnly
                            ? _args.Title
                            : string.Format("Enter {0}", _args.Title);
        }

        #endregion

        #region Save notes

        private void uNotes_NotesSaved(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(closeForm);
        }

        void closeForm()
        {
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
