namespace WinFormsApp
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.detailsPage = new System.Windows.Forms.TabPage();
            this.detailLabel2 = new System.Windows.Forms.Label();
            this.detailLabel1 = new System.Windows.Forms.Label();
            this.chartsPage = new System.Windows.Forms.TabPage();
            this.chartPanel2 = new System.Windows.Forms.Panel();
            this.chartPanel1 = new System.Windows.Forms.Panel();
            this.chartBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.detailsPage.SuspendLayout();
            this.chartsPage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Enabled = false;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(225, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1406, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelect);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1406, 715);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Location = new System.Drawing.Point(266, 20);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(107, 38);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(17, 68);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(354, 602);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.detailsPage);
            this.tabControl1.Controls.Add(this.chartsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1019, 715);
            this.tabControl1.TabIndex = 0;
            // 
            // detailsPage
            // 
            this.detailsPage.Controls.Add(this.detailLabel2);
            this.detailsPage.Controls.Add(this.detailLabel1);
            this.detailsPage.Location = new System.Drawing.Point(4, 34);
            this.detailsPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detailsPage.Name = "detailsPage";
            this.detailsPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detailsPage.Size = new System.Drawing.Size(1011, 677);
            this.detailsPage.TabIndex = 0;
            this.detailsPage.Text = "Details";
            this.detailsPage.UseVisualStyleBackColor = true;
            // 
            // detailLabel2
            // 
            this.detailLabel2.AutoSize = true;
            this.detailLabel2.Location = new System.Drawing.Point(161, 33);
            this.detailLabel2.Name = "detailLabel2";
            this.detailLabel2.Size = new System.Drawing.Size(0, 25);
            this.detailLabel2.TabIndex = 5;
            // 
            // detailLabel1
            // 
            this.detailLabel1.AutoSize = true;
            this.detailLabel1.Location = new System.Drawing.Point(35, 33);
            this.detailLabel1.Name = "detailLabel1";
            this.detailLabel1.Size = new System.Drawing.Size(109, 150);
            this.detailLabel1.TabIndex = 0;
            this.detailLabel1.Text = "Full path:\r\nSize:\r\nItems:\r\nFiles:\r\nSubdirs:\r\nLast change:\r\n";
            // 
            // chartsPage
            // 
            this.chartsPage.AutoScroll = true;
            this.chartsPage.BackColor = System.Drawing.Color.White;
            this.chartsPage.Controls.Add(this.chartPanel2);
            this.chartsPage.Controls.Add(this.chartPanel1);
            this.chartsPage.Controls.Add(this.chartBox);
            this.chartsPage.Controls.Add(this.label1);
            this.chartsPage.Location = new System.Drawing.Point(4, 34);
            this.chartsPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartsPage.Name = "chartsPage";
            this.chartsPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartsPage.Size = new System.Drawing.Size(1011, 677);
            this.chartsPage.TabIndex = 1;
            this.chartsPage.Text = "Charts";
            this.chartsPage.SizeChanged += new System.EventHandler(this.chartsPage_SizeChanged);
            // 
            // chartPanel2
            // 
            this.chartPanel2.Location = new System.Drawing.Point(502, 77);
            this.chartPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartPanel2.Name = "chartPanel2";
            this.chartPanel2.Size = new System.Drawing.Size(500, 530);
            this.chartPanel2.TabIndex = 3;
            // 
            // chartPanel1
            // 
            this.chartPanel1.Location = new System.Drawing.Point(8, 77);
            this.chartPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Size = new System.Drawing.Size(489, 530);
            this.chartPanel1.TabIndex = 2;
            // 
            // chartBox
            // 
            this.chartBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chartBox.FormattingEnabled = true;
            this.chartBox.Location = new System.Drawing.Point(127, 23);
            this.chartBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartBox.Name = "chartBox";
            this.chartBox.Size = new System.Drawing.Size(168, 33);
            this.chartBox.TabIndex = 1;
            this.chartBox.SelectedValueChanged += new System.EventHandler(this.chartBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart type:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 717);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1406, 33);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(380, 25);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 750);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1133, 713);
            this.Name = "MainWindow";
            this.Text = "Disk Space Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.detailsPage.ResumeLayout(false);
            this.detailsPage.PerformLayout();
            this.chartsPage.ResumeLayout(false);
            this.chartsPage.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private MenuStrip menuStrip1;
        private SplitContainer splitContainer1;
        private Button buttonSelect;
        private TreeView treeView1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage detailsPage;
        private TabPage chartsPage;
        private ComboBox chartBox;
        private Label label1;
        private Panel chartPanel2;
        private Panel chartPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripProgressBar toolStripProgressBar1;
        private Label detailLabel1;
        private Label detailLabel2;
        private Label label5;
    }
}