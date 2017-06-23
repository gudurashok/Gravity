using System;
using System.ComponentModel;

namespace Scalable.Win.Enums
{
    [Flags]
    public enum FileType
    {
        [Description("All files|*.*")]
        All,
        [Description("Image files|*.jpg; *.jpeg; *.jpe; *.jfif; *.gif; *.tif; *.tiff; *.bmp; *.dib; *.png")]
        Images,
        [Description("Text files|*.txt")]
        TextFiles, 
    }
}
