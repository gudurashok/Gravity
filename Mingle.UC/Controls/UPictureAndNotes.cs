using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Mingle.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Enums;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPictureAndNotes : UBaseForm
    {
        private Party _party;

        public UPictureAndNotes()
        {
            InitializeComponent();
        }

        public override object DataSource
        {
            get
            {
                return _party;
            }
            set
            {
                _party = value as Party;
                fillForm();
            }
        }

        private void fillForm()
        {
            setPicture();
            rtbNotes.Text = _party.Entity.Notes;
        }

        private void setPicture()
        {
            if (_party.Entity.Photo == null)
            {
                pctPhoto.Image = null;
                return;
            }
            setPreviewImage(new Bitmap(new MemoryStream(_party.Entity.Photo)));
        }

        private void setPreviewImage(Bitmap image)
        {
            pctPhoto.Image = getThumbnail(image);
            pctPhoto.Padding = getPadding((Bitmap)pctPhoto.Image);
        }

        private Padding getPadding(Bitmap image)
        {
            if (isMoreWide(image))
                return new Padding(0, (pctPhoto.Height - image.Height) / 2, 0, (pctPhoto.Height - image.Height) / 2);

            if (isMoreHeight(image))
                return new Padding((pctPhoto.Width - image.Width) / 2, 0, (pctPhoto.Width - image.Width) / 2, 0);

            return new Padding();
        }

        private Image getThumbnail(Bitmap image)
        {
            return image.GetThumbnailImage(
                            (int)getThumbDimensions(image).Width,
                            (int)getThumbDimensions(image).Height,
                            null, new IntPtr());
        }

        private SizeF getThumbDimensions(Bitmap image)
        {
            if (isMoreWide(image))
                return new SizeF(pctPhoto.Width, (pctPhoto.Width * image.Height) / image.Width);

            if (isMoreHeight(image))
                return new SizeF((pctPhoto.Height * image.Width) / image.Height, pctPhoto.Height);

            return new SizeF(pctPhoto.Width, pctPhoto.Height);
        }

        private bool isMoreHeight(Bitmap image)
        {
            return image.Width / pctPhoto.Width < image.Height / pctPhoto.Height;
        }

        private bool isMoreWide(Bitmap image)
        {
            return image.Width / pctPhoto.Width > image.Height / pctPhoto.Height;
        }

        public void Save()
        {
            _party.Entity.Photo = getPhoto();
            _party.Entity.Notes = rtbNotes.Text;
        }

        private byte[] getPhoto()
        {
            return pctPhoto.Image == null 
                        ? null 
                        : (byte[])(new ImageConverter().ConvertTo(pctPhoto.Image, typeof(byte[])));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(openFileBrowser);
        }

        void openFileBrowser()
        {
            var fileBrowser = new iFileBrowser("Select Image", null, FileType.Images);
            fileBrowser.Show();

            if (!string.IsNullOrWhiteSpace(fileBrowser.SelectedFileFullName))
                setPreviewImage(new Bitmap(fileBrowser.SelectedFileFullName));
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(removeImage);
        }

        private void removeImage()
        {
            pctPhoto.Image = null;
            _party.Entity.Photo = null;
        }
    }
}
