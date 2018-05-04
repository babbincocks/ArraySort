namespace ArraySort
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbNameList = new System.Windows.Forms.ListBox();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimeRecords = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSearchMatches = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(553, 324);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbNameList
            // 
            this.lbNameList.FormattingEnabled = true;
            this.lbNameList.Location = new System.Drawing.Point(17, 36);
            this.lbNameList.Name = "lbNameList";
            this.lbNameList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbNameList.Size = new System.Drawing.Size(317, 316);
            this.lbNameList.TabIndex = 1;
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(382, 324);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(154, 20);
            this.txtNameSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(379, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Term \r\n(i.e. \"John Smith\", \"Smith\", \"J\", etc.)";
            // 
            // lbTimeRecords
            // 
            this.lbTimeRecords.FormattingEnabled = true;
            this.lbTimeRecords.Location = new System.Drawing.Point(358, 36);
            this.lbTimeRecords.Name = "lbTimeRecords";
            this.lbTimeRecords.Size = new System.Drawing.Size(287, 82);
            this.lbTimeRecords.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.sortToolStripMenuItem.Text = "S&ort";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchMatchesToolStripMenuItem,
            this.timeRecordsToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.clearToolStripMenuItem.Text = "&Clear";
            // 
            // searchMatchesToolStripMenuItem
            // 
            this.searchMatchesToolStripMenuItem.Name = "searchMatchesToolStripMenuItem";
            this.searchMatchesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.searchMatchesToolStripMenuItem.Text = "...Search Matches";
            this.searchMatchesToolStripMenuItem.Click += new System.EventHandler(this.searchMatchesToolStripMenuItem_Click);
            // 
            // timeRecordsToolStripMenuItem
            // 
            this.timeRecordsToolStripMenuItem.Name = "timeRecordsToolStripMenuItem";
            this.timeRecordsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.timeRecordsToolStripMenuItem.Text = "...Time Records";
            this.timeRecordsToolStripMenuItem.Click += new System.EventHandler(this.timeRecordsToolStripMenuItem_Click);
            // 
            // lbSearchMatches
            // 
            this.lbSearchMatches.FormattingEnabled = true;
            this.lbSearchMatches.Location = new System.Drawing.Point(359, 141);
            this.lbSearchMatches.Name = "lbSearchMatches";
            this.lbSearchMatches.Size = new System.Drawing.Size(285, 134);
            this.lbSearchMatches.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 377);
            this.Controls.Add(this.lbSearchMatches);
            this.Controls.Add(this.lbTimeRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameSearch);
            this.Controls.Add(this.lbNameList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Name Search";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbNameList;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTimeRecords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ListBox lbSearchMatches;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMatchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeRecordsToolStripMenuItem;
    }
}

