namespace Synergy.UC.Controls
{
    partial class UTaskStatistics
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
            this.txtCurrentTask = new Scalable.Win.Controls.iTextBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(2, 0);
            this.txt.Size = new System.Drawing.Size(424, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 22);
            this.lvw.Size = new System.Drawing.Size(424, 196);
            this.lvw.SelectedIndexChanged += new System.EventHandler(this.lvw_SelectedIndexChanged);
            // 
            // CommandBar
            // 
            this.CommandBar.Size = new System.Drawing.Size(430, 35);
            // 
            // txtCurrentTask
            // 
            this.txtCurrentTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentTask.BackColor = System.Drawing.Color.White;
            this.txtCurrentTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentTask.Location = new System.Drawing.Point(2, 220);
            this.txtCurrentTask.Name = "txtCurrentTask";
            this.txtCurrentTask.ReadOnly = true;
            this.txtCurrentTask.Size = new System.Drawing.Size(424, 20);
            this.txtCurrentTask.TabIndex = 3;
            // 
            // UTaskStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCurrentTask);
            this.MinimumSize = new System.Drawing.Size(428, 276);
            this.Name = "UTaskStatistics";
            this.Size = new System.Drawing.Size(428, 276);
            this.Controls.SetChildIndex(this.txtCurrentTask, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iTextBox txtCurrentTask;
    }
}
