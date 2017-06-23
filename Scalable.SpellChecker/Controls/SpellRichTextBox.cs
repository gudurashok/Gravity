using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Scalable.SpellChecker.Controls
{
    public class SpellRichTextBox : RichTextBox
    {
        private bool _enableSpellCheck = true;
        private readonly Pen _errorPen = new Pen(Color.Red, 1);
        private Spelling _spellChecker;

        public SpellRichTextBox()
        {
            Application.Idle += OnIdle;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free pen resources
                if (_errorPen != null)
                    _errorPen.Dispose();
            }
            base.Dispose(disposing);
        }

        protected void OnScroll(EventArgs e)
        {
        }

        protected virtual void OnIdle(object sender, EventArgs e)
        {
        }

        [Browsable(true)]
        [CategoryAttribute("SpellCheck")]
        [Description("The Spelling object to use when spell checking")]
        public Spelling SpellChecker
        {
            get { return _spellChecker; }
            set { _spellChecker = value; }
        }

        [Browsable(true)]
        [CategoryAttribute("SpellCheck")]
        [Description("The color of the wavy underline that marks misspelled words")]
        public Color ErrorColor
        {
            get { return _errorPen.Color; }
            set { _errorPen.Color = value; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryAttribute("SpellCheck")]
        [Description("Enable As You Type spell checking")]
        public bool EnableSpellCheck
        {
            get { return _enableSpellCheck; }
            set { _enableSpellCheck = value; }
        }
    }
}
