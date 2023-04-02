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
            fileToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            splitContainer1 = new SplitContainer();
            buttonSelect = new Button();
            treeView1 = new TreeView();
            tabControl1 = new TabControl();
            detailsPage = new TabPage();
            listView1 = new ListView();
            chartsPage = new TabPage();
            chartPanel2 = new Panel();
            chartPanel1 = new Panel();
            chartBox = new ComboBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            detailsPage.SuspendLayout();
            chartsPage.SuspendLayout();
            SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectToolStripMenuItem, cancelToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            selectToolStripMenuItem.Size = new Size(150, 22);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            cancelToolStripMenuItem.Size = new Size(150, 22);
            cancelToolStripMenuItem.Text = "Cancel";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(150, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(99, 22);
            helpToolStripMenuItem.Text = "Help";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonSelect);
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(984, 426);
            splitContainer1.SplitterDistance = 267;
            splitContainer1.TabIndex = 1;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelect.Location = new Point(186, 12);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 1;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(12, 41);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(249, 360);
            treeView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(detailsPage);
            tabControl1.Controls.Add(chartsPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(713, 426);
            tabControl1.TabIndex = 0;
            // 
            // detailsPage
            // 
            detailsPage.Controls.Add(listView1);
            detailsPage.Location = new Point(4, 24);
            detailsPage.Name = "detailsPage";
            detailsPage.Padding = new Padding(3);
            detailsPage.Size = new Size(705, 398);
            detailsPage.TabIndex = 0;
            detailsPage.Text = "Details";
            detailsPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(699, 392);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // chartsPage
            // 
            chartsPage.AutoScroll = true;
            chartsPage.Controls.Add(chartPanel2);
            chartsPage.Controls.Add(chartPanel1);
            chartsPage.Controls.Add(chartBox);
            chartsPage.Controls.Add(label1);
            chartsPage.Location = new Point(4, 24);
            chartsPage.Name = "chartsPage";
            chartsPage.Padding = new Padding(3);
            chartsPage.Size = new Size(705, 398);
            chartsPage.TabIndex = 1;
            chartsPage.Text = "Charts";
            chartsPage.UseVisualStyleBackColor = true;
            // 
            // chartPanel2
            // 
            chartPanel2.Location = new Point(348, 59);
            chartPanel2.Name = "chartPanel2";
            chartPanel2.Size = new Size(349, 318);
            chartPanel2.TabIndex = 3;
            chartPanel2.Paint += chartPanel2_Paint;
            // 
            // chartPanel1
            // 
            chartPanel1.Location = new Point(18, 59);
            chartPanel1.Name = "chartPanel1";
            chartPanel1.Size = new Size(324, 318);
            chartPanel1.TabIndex = 2;
            chartPanel1.Paint += chartPanel1_Paint;
            // 
            // chartBox
            // 
            chartBox.DropDownStyle = ComboBoxStyle.DropDownList;
            chartBox.FormattingEnabled = true;
            chartBox.Location = new Point(89, 14);
            chartBox.Name = "chartBox";
            chartBox.Size = new Size(119, 23);
            chartBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 17);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Chart type:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 450);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 450);
            Name = "MainWindow";
            Text = "Disk Space Analyzer";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            detailsPage.ResumeLayout(false);
            chartsPage.ResumeLayout(false);
            chartsPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ListView listView1;
        private Panel chartPanel2;
        private Panel chartPanel1;
    }
}