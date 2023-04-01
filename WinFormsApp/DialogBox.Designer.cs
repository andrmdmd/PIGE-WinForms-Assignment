namespace WinFormsApp
{
    partial class DialogBox
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
            this.localDrivesButton = new System.Windows.Forms.RadioButton();
            this.individualDrivesButton = new System.Windows.Forms.RadioButton();
            this.folderButton = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filesButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.nameCol = new System.Windows.Forms.ColumnHeader();
            this.totalCol = new System.Windows.Forms.ColumnHeader();
            this.freeCol = new System.Windows.Forms.ColumnHeader();
            this.usedTotalCol = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // localDrivesButton
            // 
            this.localDrivesButton.AutoSize = true;
            this.localDrivesButton.Location = new System.Drawing.Point(17, 37);
            this.localDrivesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.localDrivesButton.Name = "localDrivesButton";
            this.localDrivesButton.Size = new System.Drawing.Size(152, 29);
            this.localDrivesButton.TabIndex = 0;
            this.localDrivesButton.TabStop = true;
            this.localDrivesButton.Text = "All local Drives";
            this.localDrivesButton.UseVisualStyleBackColor = true;
            this.localDrivesButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // individualDrivesButton
            // 
            this.individualDrivesButton.AutoSize = true;
            this.individualDrivesButton.Location = new System.Drawing.Point(17, 78);
            this.individualDrivesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.individualDrivesButton.Name = "individualDrivesButton";
            this.individualDrivesButton.Size = new System.Drawing.Size(168, 29);
            this.individualDrivesButton.TabIndex = 1;
            this.individualDrivesButton.TabStop = true;
            this.individualDrivesButton.Text = "Individual Drives";
            this.individualDrivesButton.UseVisualStyleBackColor = true;
            // 
            // folderButton
            // 
            this.folderButton.AutoSize = true;
            this.folderButton.Location = new System.Drawing.Point(17, 287);
            this.folderButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(104, 29);
            this.folderButton.TabIndex = 2;
            this.folderButton.TabStop = true;
            this.folderButton.Text = "A Folder";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.CheckedChanged += new System.EventHandler(this.folderButton_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox1.Location = new System.Drawing.Point(18, 332);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(540, 31);
            this.textBox1.TabIndex = 4;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // filesButton
            // 
            this.filesButton.Location = new System.Drawing.Point(567, 328);
            this.filesButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filesButton.Name = "filesButton";
            this.filesButton.Size = new System.Drawing.Size(107, 38);
            this.filesButton.TabIndex = 5;
            this.filesButton.Text = "...";
            this.filesButton.UseVisualStyleBackColor = true;
            this.filesButton.Click += new System.EventHandler(this.filesButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(451, 377);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(107, 38);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(567, 377);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(107, 38);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.totalCol,
            this.freeCol,
            this.usedTotalCol});
            this.listView.FullRowSelect = true;
            this.listView.Location = new System.Drawing.Point(17, 115);
            this.listView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(655, 159);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // nameCol
            // 
            this.nameCol.Text = "Name";
            this.nameCol.Width = 59;
            // 
            // totalCol
            // 
            this.totalCol.Text = "Total";
            this.totalCol.Width = 51;
            // 
            // freeCol
            // 
            this.freeCol.Text = "Free";
            this.freeCol.Width = 45;
            // 
            // usedTotalCol
            // 
            this.usedTotalCol.Text = "Used/total";
            this.usedTotalCol.Width = 340;
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 435);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.filesButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.individualDrivesButton);
            this.Controls.Add(this.localDrivesButton);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Disc or Folder";
            this.Load += new System.EventHandler(this.DialogBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton localDrivesButton;
        private RadioButton individualDrivesButton;
        private RadioButton folderButton;
        private TextBox textBox1;
        private Button filesButton;
        private Button okButton;
        private Button cancelButton;
        private ListView listView;
        private ColumnHeader nameCol;
        private ColumnHeader totalCol;
        private ColumnHeader freeCol;
        private ColumnHeader usedTotalCol;
    }
}