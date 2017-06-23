namespace Scalable.Win.FormControls
{
    partial class UListView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt = new Scalable.Win.Controls.iTextBox();
            this.lvw = new Scalable.Win.Controls.iListView();
            this.SuspendLayout();
            // 
            // pnlCommandBar
            // 
            this.CommandBar.Location = new System.Drawing.Point(-1, 242);
            this.CommandBar.Size = new System.Drawing.Size(210, 35);
            this.CommandBar.TabIndex = 2;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(208, 20);
            this.txt.TabIndex = 0;
            // 
            // lvw
            // 
            this.lvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvw.FullRowSelect = true;
            this.lvw.GridLines = true;
            this.lvw.Location = new System.Drawing.Point(0, 23);
            this.lvw.MultiSelect = false;
            this.lvw.Name = "lvw";
            this.lvw.Size = new System.Drawing.Size(208, 216);
            this.lvw.TabIndex = 1;
            this.lvw.UseCompatibleStateImageBehavior = false;
            this.lvw.View = System.Windows.Forms.View.Details;
            // 
            // UListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lvw);
            this.Name = "UListView";
            this.Size = new System.Drawing.Size(208, 276);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Scalable.Win.Controls.iTextBox txt;
        public Scalable.Win.Controls.iListView lvw;
    }
}
