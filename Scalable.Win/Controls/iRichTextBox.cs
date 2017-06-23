using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Scalable.Shared.Common;
using System.ComponentModel;

namespace Scalable.Win.Controls
{
    public class iRichTextBox : RichTextBox
    {
        public iRichTextBox()
        {
            ShowSelectionMargin = true;
            LinkClicked += iRichTextBox_LinkClicked;
        }

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RichText
        {
            set
            {
                if (string.IsNullOrEmpty(value) || (value.StartsWith(@"{\rtf1\")))
                    Rtf = value;
                else
                    Text = value;
            }
        }

        void iRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processLinkClickedEvent, this, e);
        }

        void processLinkClickedEvent(object sender, EventArgs e)
        {
            var args = (LinkClickedEventArgs)e;
            Process.Start(args.LinkText);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            EventHandlerExecutor.Execute(processKeyDown, this, e);
        }

        private void processKeyDown(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;

            if (args.KeyCode == Keys.B && args.Modifiers == Keys.Control)
                makeTextBold();
            else if (args.KeyCode == Keys.I && args.Modifiers == Keys.Control)
            {
                makeTextItalic();
                args.SuppressKeyPress = true;
            }
            else if (args.KeyCode == Keys.U && args.Modifiers == Keys.Control)
                makeTextUnderline();
            else if (args.KeyCode == Keys.T && args.Modifiers == Keys.Control)
                makeTextStrikeout();
            else if (args.KeyCode == Keys.K && args.Modifiers == Keys.Control)
                changeTextColor();
            else if (args.KeyCode == Keys.M && args.Modifiers == Keys.Control)
                changeTextBackColor();
            else if (args.KeyCode == Keys.D && args.Modifiers == Keys.Control)
                changeTextFont();
            else if (args.KeyCode == Keys.G && (args.Modifiers & Keys.Control) == Keys.Control)
                zoomText();
            else if (args.KeyCode == Keys.P && args.Modifiers == Keys.Control)
                printText();
            else if (args.KeyCode == Keys.OemCloseBrackets && args.Modifiers == Keys.Control)
                increaseTextSize();
            else if (args.KeyCode == Keys.OemOpenBrackets && args.Modifiers == Keys.Control)
                decreaseTextSize();
        }

        private void zoomText()
        {
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                ZoomFactor -= 0.2f;
            else
                ZoomFactor += 0.2f;
        }

        private void printText()
        {
            //MessageBoxUtil.ShowMessage("Printing is disabled now. - Thanks");
        }

        private void decreaseTextSize()
        {
            SelectionFont = (new Font(SelectionFont.FontFamily, SelectionFont.SizeInPoints - 1, SelectionFont.Style));
        }

        private void increaseTextSize()
        {
            SelectionFont = (new Font(SelectionFont.FontFamily, SelectionFont.SizeInPoints + 1, SelectionFont.Style));
        }

        void makeTextBold()
        {
            SelectionFont = new Font(SelectionFont, SelectionFont.Bold
                                                    ? SelectionFont.Style & ~FontStyle.Bold
                                                    : SelectionFont.Style | FontStyle.Bold);
        }

        void makeTextItalic()
        {
            SelectionFont = new Font(SelectionFont, SelectionFont.Italic
                                                    ? SelectionFont.Style & ~FontStyle.Italic
                                                    : SelectionFont.Style | FontStyle.Italic);
        }

        void makeTextUnderline()
        {
            SelectionFont = new Font(SelectionFont, SelectionFont.Underline
                                                    ? SelectionFont.Style & ~FontStyle.Underline
                                                    : SelectionFont.Style | FontStyle.Underline);
        }

        void makeTextStrikeout()
        {
            SelectionFont = new Font(SelectionFont, SelectionFont.Strikeout
                                                    ? SelectionFont.Style & ~FontStyle.Strikeout
                                                    : SelectionFont.Style | FontStyle.Strikeout);
        }

        void changeTextColor()
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = SelectionColor;

            if (colorDialog.ShowDialog() != DialogResult.OK ||
                        colorDialog.Color == SelectionColor)
                return;

            SelectionColor = colorDialog.Color;
        }

        void changeTextBackColor()
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = SelectionBackColor;

            if (colorDialog.ShowDialog() != DialogResult.OK ||
                    colorDialog.Color == SelectionBackColor)

                return;

            SelectionBackColor = colorDialog.Color;
        }

        private void changeTextFont()
        {
            var fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.Color = SelectionColor;
            fontDialog.Font = SelectionFont;
            fontDialog.FontMustExist = true;
            fontDialog.ShowApply = true;

            if (fontDialog.ShowDialog() != DialogResult.OK ||
                            (fontDialog.Font == SelectionFont &&
                             fontDialog.Color == SelectionColor))
                return;

            SelectionFont = fontDialog.Font;
            SelectionColor = fontDialog.Color;
        }
    }
}
