namespace Synergy.UC.Controls
{
    partial class UTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UTasks));
            this.btnCancelTask = new Scalable.Win.Controls.iCommandButton();
            this.btnTaskComment = new Scalable.Win.Controls.iCommandButton();
            this.btnTaskDone = new Scalable.Win.Controls.iCommandButton();
            this.btnTaskReopen = new Scalable.Win.Controls.iCommandButton();
            this.lblProgress = new Scalable.Win.Controls.iLabel();
            this.nudCompletePct = new Scalable.Win.Controls.iNumericUpDown();
            this.btnUpdateProgress = new Scalable.Win.Controls.iCommandButton();
            this.btnShowTaskMessageBox = new Scalable.Win.Controls.iCommandButton();
            this.btnShowComments = new Scalable.Win.Controls.iCommandButton();
            this.lblComments = new Scalable.Win.Controls.iLabel();
            this.rtbComments = new Scalable.Win.Controls.iRichTextBox();
            this.btnShowDescription = new Scalable.Win.Controls.iCommandButton();
            this.lblDescription = new Scalable.Win.Controls.iLabel();
            this.rtbDescription = new Scalable.Win.Controls.iRichTextBox();
            this.splitter = new Scalable.Win.Controls.iSplitContainer();
            this.btnChecklist = new Scalable.Win.Controls.iCommandButton();
            this.toolTip = new Scalable.Win.Controls.iToolTip();
            this.btnSetCurrentTask = new Scalable.Win.Controls.iCommandButton();
            this.btnReminders = new Scalable.Win.Controls.iCommandButton();
            this.btnTaskNumber = new Scalable.Win.Controls.iCommandButton();
            this.btnFullSearch = new Scalable.Win.Controls.iCommandButton();
            this.menuStrip = new Scalable.Win.Controls.iMenuStrip();
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSubTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smsPadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentTaskInfo = new Scalable.Win.Controls.iLabel();
            this.txtTaskInfo = new Scalable.Win.Controls.iTextBox();
            this.txtTaskNumber = new Scalable.Win.Controls.iTextBox();
            this.txtFullSearch = new Scalable.Win.Controls.iTextBox();
            this.uSearch = new Synergy.UC.Controls.USearchBar();
            this.CommandBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompletePct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(539, 5);
            // 
            // btnOpen
            // 
            this.btnOpen.Action = Scalable.Win.Enums.CommandBarAction.Open;
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(460, 5);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(117, 100);
            this.txt.Size = new System.Drawing.Size(351, 20);
            // 
            // lvw
            // 
            this.lvw.Location = new System.Drawing.Point(2, 122);
            this.lvw.Size = new System.Drawing.Size(616, 42);
            this.lvw.TabIndex = 5;
            // 
            // CommandBar
            // 
            this.CommandBar.Controls.Add(this.btnSetCurrentTask);
            this.CommandBar.Controls.Add(this.btnReminders);
            this.CommandBar.Controls.Add(this.btnChecklist);
            this.CommandBar.Controls.Add(this.btnShowTaskMessageBox);
            this.CommandBar.Controls.Add(this.nudCompletePct);
            this.CommandBar.Controls.Add(this.btnTaskReopen);
            this.CommandBar.Controls.Add(this.lblProgress);
            this.CommandBar.Controls.Add(this.btnTaskComment);
            this.CommandBar.Controls.Add(this.btnUpdateProgress);
            this.CommandBar.Controls.Add(this.btnTaskDone);
            this.CommandBar.Controls.Add(this.btnCancelTask);
            this.CommandBar.Location = new System.Drawing.Point(-1, 290);
            this.CommandBar.Size = new System.Drawing.Size(622, 35);
            this.CommandBar.TabIndex = 8;
            this.CommandBar.Controls.SetChildIndex(this.btnOpen, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnOK, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnCancelTask, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnTaskDone, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnUpdateProgress, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnTaskComment, 0);
            this.CommandBar.Controls.SetChildIndex(this.lblProgress, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnTaskReopen, 0);
            this.CommandBar.Controls.SetChildIndex(this.nudCompletePct, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnShowTaskMessageBox, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnChecklist, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnReminders, 0);
            this.CommandBar.Controls.SetChildIndex(this.btnSetCurrentTask, 0);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelTask.Enabled = false;
            this.btnCancelTask.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelTask.ForeColor = System.Drawing.Color.Red;
            this.btnCancelTask.Location = new System.Drawing.Point(6, 5);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(23, 23);
            this.btnCancelTask.TabIndex = 8;
            this.btnCancelTask.Text = "X";
            this.toolTip.SetToolTip(this.btnCancelTask, "Cancel task");
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // btnTaskComment
            // 
            this.btnTaskComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaskComment.Enabled = false;
            this.btnTaskComment.Location = new System.Drawing.Point(381, 5);
            this.btnTaskComment.Name = "btnTaskComment";
            this.btnTaskComment.Size = new System.Drawing.Size(75, 23);
            this.btnTaskComment.TabIndex = 2;
            this.btnTaskComment.Text = "&Comment";
            this.btnTaskComment.UseVisualStyleBackColor = true;
            this.btnTaskComment.Click += new System.EventHandler(this.btnTaskComment_Click);
            // 
            // btnTaskDone
            // 
            this.btnTaskDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTaskDone.Enabled = false;
            this.btnTaskDone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskDone.ForeColor = System.Drawing.Color.Green;
            this.btnTaskDone.Location = new System.Drawing.Point(33, 5);
            this.btnTaskDone.Name = "btnTaskDone";
            this.btnTaskDone.Size = new System.Drawing.Size(23, 23);
            this.btnTaskDone.TabIndex = 7;
            this.btnTaskDone.Text = "√";
            this.toolTip.SetToolTip(this.btnTaskDone, "Complete task");
            this.btnTaskDone.UseVisualStyleBackColor = true;
            this.btnTaskDone.Click += new System.EventHandler(this.btnTaskDone_Click);
            // 
            // btnTaskReopen
            // 
            this.btnTaskReopen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTaskReopen.Enabled = false;
            this.btnTaskReopen.Location = new System.Drawing.Point(60, 5);
            this.btnTaskReopen.Name = "btnTaskReopen";
            this.btnTaskReopen.Size = new System.Drawing.Size(75, 23);
            this.btnTaskReopen.TabIndex = 6;
            this.btnTaskReopen.Text = "&Reopen";
            this.btnTaskReopen.UseVisualStyleBackColor = true;
            this.btnTaskReopen.Click += new System.EventHandler(this.btnTaskReopen_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(138, 10);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "&Progress:";
            // 
            // nudCompletePct
            // 
            this.nudCompletePct.Enabled = false;
            this.nudCompletePct.Location = new System.Drawing.Point(190, 6);
            this.nudCompletePct.Name = "nudCompletePct";
            this.nudCompletePct.Size = new System.Drawing.Size(39, 20);
            this.nudCompletePct.TabIndex = 4;
            // 
            // btnUpdateProgress
            // 
            this.btnUpdateProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateProgress.Enabled = false;
            this.btnUpdateProgress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProgress.ForeColor = System.Drawing.Color.Blue;
            this.btnUpdateProgress.Location = new System.Drawing.Point(230, 5);
            this.btnUpdateProgress.Name = "btnUpdateProgress";
            this.btnUpdateProgress.Size = new System.Drawing.Size(23, 23);
            this.btnUpdateProgress.TabIndex = 5;
            this.btnUpdateProgress.Text = "√";
            this.toolTip.SetToolTip(this.btnUpdateProgress, "Update progress");
            this.btnUpdateProgress.UseVisualStyleBackColor = true;
            this.btnUpdateProgress.Click += new System.EventHandler(this.btnUpdateProgress_Click);
            // 
            // btnShowTaskMessageBox
            // 
            this.btnShowTaskMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowTaskMessageBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowTaskMessageBox.BackgroundImage")));
            this.btnShowTaskMessageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowTaskMessageBox.Location = new System.Drawing.Point(351, 5);
            this.btnShowTaskMessageBox.Name = "btnShowTaskMessageBox";
            this.btnShowTaskMessageBox.Size = new System.Drawing.Size(23, 23);
            this.btnShowTaskMessageBox.TabIndex = 10;
            this.toolTip.SetToolTip(this.btnShowTaskMessageBox, "View messages");
            this.btnShowTaskMessageBox.UseVisualStyleBackColor = true;
            this.btnShowTaskMessageBox.Visible = false;
            this.btnShowTaskMessageBox.Click += new System.EventHandler(this.btnShowTaskMessageBox_Click);
            // 
            // btnShowComments
            // 
            this.btnShowComments.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowComments.BackgroundImage")));
            this.btnShowComments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowComments.Location = new System.Drawing.Point(287, -2);
            this.btnShowComments.Name = "btnShowComments";
            this.btnShowComments.Size = new System.Drawing.Size(21, 21);
            this.btnShowComments.TabIndex = 2;
            this.btnShowComments.UseVisualStyleBackColor = true;
            this.btnShowComments.Click += new System.EventHandler(this.btnShowComments_Click);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(0, 1);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(59, 13);
            this.lblComments.TabIndex = 0;
            this.lblComments.Text = "Co&mments:";
            // 
            // rtbComments
            // 
            this.rtbComments.BackColor = System.Drawing.Color.White;
            this.rtbComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbComments.Location = new System.Drawing.Point(2, 17);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.ReadOnly = true;
            this.rtbComments.ShowSelectionMargin = true;
            this.rtbComments.Size = new System.Drawing.Size(303, 80);
            this.rtbComments.TabIndex = 1;
            this.rtbComments.Text = "";
            // 
            // btnShowDescription
            // 
            this.btnShowDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDescription.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowDescription.BackgroundImage")));
            this.btnShowDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowDescription.Location = new System.Drawing.Point(285, -2);
            this.btnShowDescription.Name = "btnShowDescription";
            this.btnShowDescription.Size = new System.Drawing.Size(21, 21);
            this.btnShowDescription.TabIndex = 2;
            this.btnShowDescription.UseVisualStyleBackColor = true;
            this.btnShowDescription.Click += new System.EventHandler(this.btnShowDescription_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(0, 1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "D&escription:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDescription.BackColor = System.Drawing.Color.White;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.Location = new System.Drawing.Point(2, 17);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.ShowSelectionMargin = true;
            this.rtbDescription.Size = new System.Drawing.Size(301, 80);
            this.rtbDescription.TabIndex = 1;
            this.rtbDescription.Text = "";
            // 
            // splitter
            // 
            this.splitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter.Location = new System.Drawing.Point(2, 166);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.rtbDescription);
            this.splitter.Panel1.Controls.Add(this.lblDescription);
            this.splitter.Panel1.Controls.Add(this.btnShowDescription);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.rtbComments);
            this.splitter.Panel2.Controls.Add(this.lblComments);
            this.splitter.Panel2.Controls.Add(this.btnShowComments);
            this.splitter.Size = new System.Drawing.Size(616, 100);
            this.splitter.SplitterDistance = 306;
            this.splitter.SplitterWidth = 2;
            this.splitter.TabIndex = 10;
            // 
            // btnChecklist
            // 
            this.btnChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecklist.ForeColor = System.Drawing.Color.Maroon;
            this.btnChecklist.Location = new System.Drawing.Point(257, 5);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(23, 23);
            this.btnChecklist.TabIndex = 9;
            this.btnChecklist.Text = "√";
            this.toolTip.SetToolTip(this.btnChecklist, "Checklist");
            this.btnChecklist.UseVisualStyleBackColor = true;
            this.btnChecklist.Click += new System.EventHandler(this.btnChecklist_Click);
            // 
            // btnSetCurrentTask
            // 
            this.btnSetCurrentTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetCurrentTask.Image = global::Synergy.UC.Properties.Resources.UnPinned;
            this.btnSetCurrentTask.Location = new System.Drawing.Point(297, 5);
            this.btnSetCurrentTask.Name = "btnSetCurrentTask";
            this.btnSetCurrentTask.Size = new System.Drawing.Size(23, 23);
            this.btnSetCurrentTask.TabIndex = 12;
            this.toolTip.SetToolTip(this.btnSetCurrentTask, "Set current task");
            this.btnSetCurrentTask.UseVisualStyleBackColor = true;
            this.btnSetCurrentTask.Click += new System.EventHandler(this.btnSetCurrentTask_Click);
            // 
            // btnReminders
            // 
            this.btnReminders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReminders.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReminders.BackgroundImage")));
            this.btnReminders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReminders.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReminders.ForeColor = System.Drawing.Color.Maroon;
            this.btnReminders.Location = new System.Drawing.Point(324, 5);
            this.btnReminders.Name = "btnReminders";
            this.btnReminders.Size = new System.Drawing.Size(23, 23);
            this.btnReminders.TabIndex = 11;
            this.toolTip.SetToolTip(this.btnReminders, "Reminders");
            this.btnReminders.UseVisualStyleBackColor = true;
            this.btnReminders.Click += new System.EventHandler(this.btnReminders_Click);
            // 
            // btnTaskNumber
            // 
            this.btnTaskNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskNumber.ForeColor = System.Drawing.Color.Blue;
            this.btnTaskNumber.Location = new System.Drawing.Point(99, 99);
            this.btnTaskNumber.Name = "btnTaskNumber";
            this.btnTaskNumber.Size = new System.Drawing.Size(22, 22);
            this.btnTaskNumber.TabIndex = 2;
            this.btnTaskNumber.Text = "#";
            this.toolTip.SetToolTip(this.btnTaskNumber, "Search by task number");
            this.btnTaskNumber.UseVisualStyleBackColor = true;
            this.btnTaskNumber.Click += new System.EventHandler(this.btnTaskNumber_Click);
            // 
            // btnFullSearch
            // 
            this.btnFullSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFullSearch.BackgroundImage")));
            this.btnFullSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFullSearch.Location = new System.Drawing.Point(597, 99);
            this.btnFullSearch.Name = "btnFullSearch";
            this.btnFullSearch.Size = new System.Drawing.Size(22, 22);
            this.btnFullSearch.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnFullSearch, "Full search on tasks");
            this.btnFullSearch.UseVisualStyleBackColor = true;
            this.btnFullSearch.Click += new System.EventHandler(this.btnFullSearch_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem,
            this.newSubTaskToolStripMenuItem,
            this.previewToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.smsPadToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(620, 24);
            this.menuStrip.TabIndex = 6;
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTaskToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.newTaskToolStripMenuItem.Text = "&New Task";
            this.newTaskToolStripMenuItem.Click += new System.EventHandler(this.newTaskToolStripMenuItem_Click);
            // 
            // newSubTaskToolStripMenuItem
            // 
            this.newSubTaskToolStripMenuItem.Enabled = false;
            this.newSubTaskToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newSubTaskToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.newSubTaskToolStripMenuItem.Name = "newSubTaskToolStripMenuItem";
            this.newSubTaskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.newSubTaskToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.newSubTaskToolStripMenuItem.Text = "New Su&b Task";
            this.newSubTaskToolStripMenuItem.Click += new System.EventHandler(this.newSubTaskToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.previewToolStripMenuItem.Text = "Hide Previe&w";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.searchToolStripMenuItem.Text = "Hide Searc&h";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // smsPadToolStripMenuItem
            // 
            this.smsPadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.smsPadToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.smsPadToolStripMenuItem.Name = "smsPadToolStripMenuItem";
            this.smsPadToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.smsPadToolStripMenuItem.Text = "S&MS Pad";
            this.smsPadToolStripMenuItem.Click += new System.EventHandler(this.smsPadToolStripMenuItem_Click);
            this.smsPadToolStripMenuItem.Enabled = false;
            // 
            // lblCurrentTaskInfo
            // 
            this.lblCurrentTaskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTaskInfo.AutoSize = true;
            this.lblCurrentTaskInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentTaskInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrentTaskInfo.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentTaskInfo.Location = new System.Drawing.Point(535, 5);
            this.lblCurrentTaskInfo.Name = "lblCurrentTaskInfo";
            this.lblCurrentTaskInfo.Size = new System.Drawing.Size(80, 13);
            this.lblCurrentTaskInfo.TabIndex = 7;
            this.lblCurrentTaskInfo.Text = "No current task";
            this.lblCurrentTaskInfo.Click += new System.EventHandler(this.lblCurrentTaskInfo_Click);
            // 
            // txtTaskInfo
            // 
            this.txtTaskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskInfo.BackColor = System.Drawing.Color.White;
            this.txtTaskInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskInfo.Location = new System.Drawing.Point(2, 268);
            this.txtTaskInfo.Name = "txtTaskInfo";
            this.txtTaskInfo.ReadOnly = true;
            this.txtTaskInfo.Size = new System.Drawing.Size(616, 20);
            this.txtTaskInfo.TabIndex = 9;
            // 
            // txtTaskNumber
            // 
            this.txtTaskNumber.BackColor = System.Drawing.Color.White;
            this.txtTaskNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskNumber.InputFilterExpr = "[0-9]";
            this.txtTaskNumber.Location = new System.Drawing.Point(2, 100);
            this.txtTaskNumber.Name = "txtTaskNumber";
            this.txtTaskNumber.Size = new System.Drawing.Size(96, 20);
            this.txtTaskNumber.TabIndex = 1;
            // 
            // txtFullSearch
            // 
            this.txtFullSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFullSearch.BackColor = System.Drawing.Color.White;
            this.txtFullSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullSearch.Location = new System.Drawing.Point(122, 100);
            this.txtFullSearch.Name = "txtFullSearch";
            this.txtFullSearch.Size = new System.Drawing.Size(475, 20);
            this.txtFullSearch.TabIndex = 3;
            this.txtFullSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFullSearch_KeyUp);
            // 
            // uSearch
            // 
            this.uSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uSearch.Location = new System.Drawing.Point(2, 25);
            this.uSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uSearch.Name = "uSearch";
            this.uSearch.Size = new System.Drawing.Size(616, 73);
            this.uSearch.TabIndex = 11;
            // 
            // UTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFullSearch);
            this.Controls.Add(this.btnFullSearch);
            this.Controls.Add(this.txtTaskNumber);
            this.Controls.Add(this.btnTaskNumber);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.txtTaskInfo);
            this.Controls.Add(this.lblCurrentTaskInfo);
            this.Controls.Add(this.uSearch);
            this.Controls.Add(this.menuStrip);
            this.MinimumSize = new System.Drawing.Size(620, 324);
            this.Name = "UTasks";
            this.Size = new System.Drawing.Size(620, 324);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.uSearch, 0);
            this.Controls.SetChildIndex(this.lvw, 0);
            this.Controls.SetChildIndex(this.txt, 0);
            this.Controls.SetChildIndex(this.CommandBar, 0);
            this.Controls.SetChildIndex(this.lblCurrentTaskInfo, 0);
            this.Controls.SetChildIndex(this.txtTaskInfo, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.btnTaskNumber, 0);
            this.Controls.SetChildIndex(this.txtTaskNumber, 0);
            this.Controls.SetChildIndex(this.btnFullSearch, 0);
            this.Controls.SetChildIndex(this.txtFullSearch, 0);
            this.CommandBar.ResumeLayout(false);
            this.CommandBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompletePct)).EndInit();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel1.PerformLayout();
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Scalable.Win.Controls.iCommandButton btnCancelTask;
        private Scalable.Win.Controls.iCommandButton btnTaskComment;
        private USearchBar uSearch;
        private Scalable.Win.Controls.iCommandButton btnTaskDone;
        private Scalable.Win.Controls.iCommandButton btnTaskReopen;
        private Scalable.Win.Controls.iLabel lblProgress;
        private Scalable.Win.Controls.iNumericUpDown nudCompletePct;
        private Scalable.Win.Controls.iCommandButton btnUpdateProgress;
        private Scalable.Win.Controls.iCommandButton btnShowTaskMessageBox;
        private Scalable.Win.Controls.iCommandButton btnShowComments;
        private Scalable.Win.Controls.iLabel lblComments;
        private Scalable.Win.Controls.iRichTextBox rtbComments;
        private Scalable.Win.Controls.iCommandButton btnShowDescription;
        private Scalable.Win.Controls.iLabel lblDescription;
        private Scalable.Win.Controls.iRichTextBox rtbDescription;
        private Scalable.Win.Controls.iSplitContainer splitter;
        private Scalable.Win.Controls.iCommandButton btnChecklist;
        private Scalable.Win.Controls.iToolTip toolTip;
        private Scalable.Win.Controls.iMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private Scalable.Win.Controls.iCommandButton btnSetCurrentTask;
        private Scalable.Win.Controls.iLabel lblCurrentTaskInfo;
        private Scalable.Win.Controls.iCommandButton btnReminders;
        private Scalable.Win.Controls.iTextBox txtTaskInfo;
        private Scalable.Win.Controls.iCommandButton btnTaskNumber;
        private Scalable.Win.Controls.iTextBox txtTaskNumber;
        private Scalable.Win.Controls.iTextBox txtFullSearch;
        private Scalable.Win.Controls.iCommandButton btnFullSearch;
        private System.Windows.Forms.ToolStripMenuItem smsPadToolStripMenuItem;
    }
}
