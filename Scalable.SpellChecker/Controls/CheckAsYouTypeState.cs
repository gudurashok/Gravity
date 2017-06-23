using System.Windows.Forms;

namespace Scalable.SpellChecker.Controls
{
	public class CheckAsYouTypeState
	{
		private readonly TextBoxBase _textBoxBaseInstance;

		public CheckAsYouTypeState(TextBoxBase textBoxBaseInstance)
		{
			_textBoxBaseInstance = textBoxBaseInstance;
		}

		public TextBoxBase TextBoxBaseInstance
		{
			get { return _textBoxBaseInstance; }
		}
	}
}
