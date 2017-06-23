namespace Synergy.UC.Controls
{
    partial class UTaskChecklist
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
            this.lvwTaskChecklist = new Scalable.Win.Controls.iListView();
            this.btnOK = new Scalable.Win.Controls.iCommandButton();
            this.CommandBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnOK);
            this.CommandBar.Location = new System.Drawing.Point(-1, 131);
            this.CommandBar.Size = new System.Drawing.Size(159, 35);
            this.CommandBar.TabIndex = 2;
            // 
            // lvwTaskChecklist
            // 
            this.lvwTaskChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTaskChecklist.CheckBoxes = true;
            this.lvwTaskChecklist.FullRowSelect = true;
            this.lvwTaskChecklist.GridLines = true;
            this.lvwTaskChecklist.Location = new System.Drawing.Point(2, 2);
            this.lvwTaskChecklist.MultiSelect = false;
            this.lvwTaskChecklist.Name = "lvwTaskChecklist";
            this.lvwTaskChecklist.Size = new System.Drawing.Size(153, 127);
            this.lvwTaskChecklist.TabIndex = 1;
            this.lvwTaskChecklist.UseCompatibleStateImageBehavior = false;
            this.lvwTaskChecklist.View = System.Windows.Forms.View.Details;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(41, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UTaskChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwTaskChecklist);
            this.Name = "UTaskChecklist";
            this.Size = new System.Drawing.Size(157, 165);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lvwTaskChecklist, 0);
            this.CommandBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnOK;
        private Scalable.Win.Controls.iListView lvwTaskChecklist;
    }
}
