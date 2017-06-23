using System;
using Scalable.Shared.Common;
using Scalable.Shared.Model;

namespace Scalable.Win.FormControls
{
    public partial class UNotes : UFormBase
    {
        public event EventHandler NotesSaved;
        private NotesFormArgs _args;

        public UNotes()
        {
            InitializeComponent();
        }

        public void Initialize(NotesFormArgs args)
        {
            _args = args;
            rtbNotes.ReadOnly = args.ReadOnly;

            if (_args.IsRtf)
                rtbNotes.RichText = args.Notes;
            else
                rtbNotes.Text = args.Notes;

            rtbNotes.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processOK);
        }

        void processOK()
        {
            if (!_args.ReadOnly && _args.Required &&
                string.IsNullOrWhiteSpace(rtbNotes.Text))
                return;

            _args.Notes = _args.IsRtf ? rtbNotes.Rtf : rtbNotes.Text;

            OnNotesSaved(new EventArgs());
        }

        protected virtual void OnNotesSaved(EventArgs e)
        {
            if (NotesSaved != null)
                NotesSaved(this, e);
        }
    }
}
