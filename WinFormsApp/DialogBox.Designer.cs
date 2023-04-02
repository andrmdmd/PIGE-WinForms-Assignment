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
            localDrivesButton = new RadioButton();
            individualDrivesButton = new RadioButton();
            folderButton = new RadioButton();
            textBox1 = new TextBox();
            filesButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            listView = new ListView();
            nameCol = new ColumnHeader();
            totalCol = new ColumnHeader();
            freeCol = new ColumnHeader();
            usedTotalCol = new ColumnHeader();
            SuspendLayout();
            // 
            // localDrivesButton
            // 
            localDrivesButton.AutoSize = true;
            localDrivesButton.Location = new Point(12, 22);
            localDrivesButton.Name = "localDrivesButton";
            localDrivesButton.Size = new Size(102, 19);
            localDrivesButton.TabIndex = 0;
            localDrivesButton.TabStop = true;
            localDrivesButton.Text = "All local Drives";
            localDrivesButton.UseVisualStyleBackColor = true;
            localDrivesButton.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // individualDrivesButton
            // 
            individualDrivesButton.AutoSize = true;
            individualDrivesButton.Location = new Point(12, 47);
            individualDrivesButton.Name = "individualDrivesButton";
            individualDrivesButton.Size = new Size(112, 19);
            individualDrivesButton.TabIndex = 1;
            individualDrivesButton.TabStop = true;
            individualDrivesButton.Text = "Individual Drives";
            individualDrivesButton.UseVisualStyleBackColor = true;
            // 
            // folderButton
            // 
            folderButton.AutoSize = true;
            folderButton.Location = new Point(12, 172);
            folderButton.Name = "folderButton";
            folderButton.Size = new Size(69, 19);
            folderButton.TabIndex = 2;
            folderButton.TabStop = true;
            folderButton.Text = "A Folder";
            folderButton.UseVisualStyleBackColor = true;
            folderButton.CheckedChanged += folderButton_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            textBox1.Location = new Point(13, 199);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(379, 23);
            textBox1.TabIndex = 4;
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.Leave += textBox1_Leave;
            // 
            // filesButton
            // 
            filesButton.Location = new Point(397, 197);
            filesButton.Name = "filesButton";
            filesButton.Size = new Size(75, 23);
            filesButton.TabIndex = 5;
            filesButton.Text = "...";
            filesButton.UseVisualStyleBackColor = true;
            filesButton.Click += filesButton_Click;
            // 
            // okButton
            // 
            okButton.Location = new Point(316, 226);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 6;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(397, 226);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { nameCol, totalCol, freeCol, usedTotalCol });
            listView.FullRowSelect = true;
            listView.Location = new Point(12, 69);
            listView.Name = "listView";
            listView.ShowGroups = false;
            listView.Size = new Size(460, 97);
            listView.TabIndex = 8;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SelectedIndexChanged += listView_SelectedIndexChanged;
            listView.Click += listView_Click;
            // 
            // nameCol
            // 
            nameCol.Text = "Name";
            nameCol.Width = 59;
            // 
            // totalCol
            // 
            totalCol.Text = "Total";
            totalCol.Width = 51;
            // 
            // freeCol
            // 
            freeCol.Text = "Free";
            freeCol.Width = 45;
            // 
            // usedTotalCol
            // 
            usedTotalCol.Text = "Used/total";
            usedTotalCol.Width = 340;
            // 
            // DialogBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(listView);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(filesButton);
            Controls.Add(textBox1);
            Controls.Add(folderButton);
            Controls.Add(individualDrivesButton);
            Controls.Add(localDrivesButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Disc or Folder";
            Load += DialogBox_Load;
            KeyDown += DialogBox_KeyDown;
            ResumeLayout(false);
            PerformLayout();
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