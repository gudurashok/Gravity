using System.Windows.Forms;
namespace Scalable.Win.Controls
{
    public class iFolderBrowser
    {
        public string SelectedPath { get; private set; }
        private readonly FolderBrowserDialog _fpd = new FolderBrowserDialog();
        private readonly Form _owner;

        public iFolderBrowser(string description, Form owner)
        {
            _fpd.Description = description;
            _owner = owner;
        }

        public string Show()
        {
            _fpd.SelectedPath = SelectedPath;

            if (_fpd.ShowDialog(_owner) == DialogResult.OK)
            {
                SelectedPath = _fpd.SelectedPath;
                return SelectedPath;
            }

            return string.Empty;
        }
    }
}
