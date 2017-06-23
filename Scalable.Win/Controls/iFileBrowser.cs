using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Enums;

namespace Scalable.Win.Controls
{
    public class iFileBrowser
    {
        public string SelectedFileFullName { get; private set; }
        public string SelectedFileName { get; private set; }
        private readonly OpenFileDialog _ofd = new OpenFileDialog();
        private readonly Form _owner;

        public iFileBrowser(string title, Form owner, FileType fileType = FileType.All)
        {
            _ofd.Title = title;
            _owner = owner;

            if (fileType != FileType.All)
                _ofd.Filter = EnumUtil.GetEnumDescription(fileType);
        }

        public string Show()
        {
            _ofd.FileName = SelectedFileFullName;

            if (_ofd.ShowDialog(_owner) == DialogResult.OK)
            {
                SelectedFileFullName = _ofd.FileName;
                SelectedFileName = _ofd.SafeFileName;
                return SelectedFileFullName;
            }

            return string.Empty;
        }
    }
}
