using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp
{
    public partial class DialogBox : Form
    {
        public string folderpath { get; set; }


        public DialogBox()
        {
            InitializeComponent();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void folderButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            folderpath = textBox1.Text;
            textBox1.ForeColor = SystemColors.WindowText;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filesButton_Click(object sender, EventArgs e)
        {
            folderButton.Checked = true;
            FolderBrowserDialog fDialog = new FolderBrowserDialog();
            

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fDialog.SelectedPath;
                folderpath = fDialog.SelectedPath;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            folderButton.Checked = true;
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                
                if (d.IsReady == true)
                {
                    double totalSize = (double)d.TotalSize / (1024 * 1024 * 1024);
                    double aviableSpace = (double)d.AvailableFreeSpace / (1024 * 1024 * 1024);
                    double usedTotal = (100.0 * (d.TotalSize - d.AvailableFreeSpace) / d.TotalSize);
                    ListViewItem newItem = new ListViewItem(new[] { d.Name, totalSize.ToString("N1") + " GB", aviableSpace.ToString("N1") + " GB", usedTotal.ToString("N2") + "%"});
                    listView.Items.Add(newItem);


                }
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView_Click(object sender, EventArgs e)
        {
            individualDrivesButton.Checked = true;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            individualDrivesButton.Checked = true;
            if(listView.SelectedItems.Count > 0) 
                folderpath = listView.SelectedItems[0].SubItems[0].Text;
            
        }

        private void DialogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if(e.KeyCode == Keys.I)
                {
                    individualDrivesButton.Checked = true;
                }
                else if(e.KeyCode == Keys.F)
                {
                    folderButton.Checked = true;
                }
                else if(e.KeyCode == Keys.A)
                {
                    localDrivesButton.Checked = true;   
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textValidation();
        }

        private void textValidation()
        {
            string path = textBox1.Text;
            if (!Path.IsPathRooted(path) || !Directory.Exists(path))
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
                textValidation();
               
            }
        }
    }
}
