using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;

namespace Scalable.SpellChecker.Controls
{
    [ProvideProperty("EnableCheck", typeof(TextBoxBase))]
    [ProvideProperty("SpellChecker", typeof(TextBoxBase))]
    public class CheckAsYouType : Component, ISupportInitialize, IExtenderProvider, IMessageFilter
    {
        private Container _components;
        private readonly Hashtable _textBoxes = new Hashtable();
        private Spelling _spellChecker;

        public CheckAsYouType(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        public CheckAsYouType()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Application.AddMessageFilter(this);
            Application.Idle += OnIdle;
        }

        #region Extended Properties

        [
        Category("SpellChecker"),
        Description("Spell Check this Control As You Type"),
        ]
        public bool GetEnableCheck(TextBoxBase extendee)
        {
            return _textBoxes.Contains(extendee.Handle);
        }

        public void SetEnableCheck(TextBoxBase extendee, bool value)
        {
            if (value && !_textBoxes.Contains(extendee.Handle))
            {
                _textBoxes.Add(extendee.Handle, new CheckAsYouTypeState(extendee));
                extendee.TextChanged += OnTextChanged;
                extendee.MouseDown += OnMouseDown;
            }
            else if (!value && _textBoxes.Contains(extendee.Handle))
            {
                _textBoxes.Remove(extendee);
                extendee.TextChanged -= OnTextChanged;
                extendee.MouseDown -= OnMouseDown;
            }
        }

        [
        Category("SpellChecker"),
        Description("Spell Check instance to use"),
        ]
        public Spelling GetSpellChecker(TextBoxBase extendee)
        {
            return _spellChecker;
        }

        public void SetSpellChecker(TextBoxBase extendee, Spelling value)
        {
            _spellChecker = value;
        }

        #endregion //Extended Properties

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
        }

        #endregion

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is TextBoxBase;
        }

        #endregion

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message m)
        {
            // only listen to extended controls
            if (_textBoxes.Contains(m.HWnd))
            {
                var textBox = ((CheckAsYouTypeState)_textBoxes[m.HWnd]).TextBoxBaseInstance;

                switch (m.Msg)
                {
                    case NativeMethods.WM_PAINT:
                        OnPaint(textBox, null);
                        break;
                    case NativeMethods.WM_ERASEBKGND:
                        Console.WriteLine(string.Format("WM_ERASEBKGND:{0}", textBox.Name));
                        break;
                    case NativeMethods.WM_HSCROLL:
                        Console.WriteLine(string.Format("WM_HSCROLL:{0}", textBox.Name));
                        break;
                    case NativeMethods.WM_VSCROLL:
                        Console.WriteLine(string.Format("WM_VSCROLL:{0}", textBox.Name));
                        break;
                    case NativeMethods.WM_CAPTURECHANGED:
                        Console.WriteLine(string.Format("WM_CAPTURECHANGED:{0}", textBox.Name));
                        break;
                    default:
                        Console.WriteLine(string.Format("Msg: 0x{0}", m.Msg.ToString("x4")));
                        break;
                }
            }

            // never handle messages
            return false;
        }

        #endregion

        #region ISupportInitialize Members

        public void BeginInit()
        {
            // TODO:  Add TextBoxExtender.BeginInit implementation
        }

        public void EndInit()
        {
            // TODO:  Add TextBoxExtender.EndInit implementation
        }

        #endregion

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBoxBase)) 
                return;

            var textBox = (TextBoxBase)sender;
            Console.WriteLine(string.Format("OnTextChanged:{0}", textBox.Name));
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (!(sender is TextBoxBase)) 
                return;

            var textBox = (TextBoxBase)sender;
            Console.WriteLine(string.Format("OnPaint:{0}", textBox.Name));
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is TextBoxBase)) 
                return;

            var textBox = (TextBoxBase)sender;
            Console.WriteLine(string.Format("OnMouseDown:{0}", textBox.Name));
        }

        private void OnIdle(object sender, EventArgs e)
        {

        }
    }
}
