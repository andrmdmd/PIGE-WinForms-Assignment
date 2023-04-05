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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp
{
    public partial class DialogBox : Form
    {
        public List<string> folderpaths { get; set; }
        bool validPath = false;
        bool isDrive = false;
        List<NewProgressBar> progressBars = new List<NewProgressBar>();

        public DialogBox()
        {
            InitializeComponent();

        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void folderButton_CheckedChanged(object sender, EventArgs e)
        {
            if(validPath)
            {
                folderpaths = new List<string> { textBox1.Text };
                isDrive = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            validPath = false;
        }


        private void filesButton_Click(object sender, EventArgs e)
        {
            folderButton.Checked = true;
            FolderBrowserDialog fDialog = new FolderBrowserDialog();


            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fDialog.SelectedPath;
                folderpaths = new List<string> { fDialog.SelectedPath };
                validPath = true;
            }
        }

        private void localDrivesButton_Click(object sender, EventArgs e)
        {
            localDrivesButton.Checked = true;
            validPath = true;
            if (listView.Items.Count > 0)
            {
                folderpaths = new();
                foreach (ListViewItem item in listView.Items)
                {
                    folderpaths.Add(item.SubItems[0].Text);
                }
                isDrive = true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            folderButton.Checked = true;
            textBox1.ForeColor = Color.Black;
        }

        private void DialogBox_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            //listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
            //listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    double totalSize = (double)d.TotalSize / (1024 * 1024 * 1024);
                    double availableSpace = (double)d.AvailableFreeSpace / (1024 * 1024 * 1024);
                    double usedPercent = (100.0 * (d.TotalSize - d.AvailableFreeSpace) / d.TotalSize);

                    ListViewItem newItem = new ListViewItem(new[] { d.Name, totalSize.ToString("N1") + " GB", availableSpace.ToString("N1") + " GB", usedPercent.ToString("N2") + "%", "-" });
                    listView.Items.Add(newItem);

                    Rectangle r1 = newItem.SubItems[4].Bounds;

                    var p = new NewProgressBar();
                    p.SetBounds(r1.X, r1.Y, r1.Width, r1.Height);
                    p.Visible = true;
                    p.Minimum = 0;
                    p.Maximum = 100;
                    p.Value = (int)usedPercent;

                    listView.Controls.Add(p);
                    p.Name = d.Name;

                    progressBars.Add(p);

                }
            }
            localDrivesButton.Checked = true;
            validPath = true;
            if (listView.Items.Count > 0)
            {
                folderpaths = new();
                foreach (ListViewItem item in listView.Items)
                {
                    folderpaths.Add(item.SubItems[0].Text);
                }
                isDrive = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if (validPath)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The path you have selected is not valid.", "Invalid path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView_Click(object sender, EventArgs e)
        {
            individualDrivesButton.Checked = true;
            validPath = true;
            isDrive = true;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            individualDrivesButton.Checked = true;
            if (listView.SelectedItems.Count > 0)
            {
                folderpaths = new();
                foreach(ListViewItem item in listView.SelectedItems)
                {
                    folderpaths.Add(item.SubItems[0].Text);
                }
            }
            isDrive = true;

        }

        private void DialogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.I)
                {
                    if (individualDrivesButton.Checked == false)
                    {
                        individualDrivesButton.Checked = true;
                        if (listView.SelectedItems.Count > 0)
                        {
                            folderpaths = new();
                            foreach (ListViewItem item in listView.SelectedItems)
                            {
                                folderpaths.Add(item.SubItems[0].Text);
                            }
                        }
                        isDrive = true;
                    }

                }
                else if (e.KeyCode == Keys.F)
                {
                    if(folderButton.Checked == false)
                    {
                        folderButton.Checked = true;
                        if (validPath)
                        {
                            folderpaths = new List<string> { textBox1.Text };
                        }
                    }
                    
                }
                else if (e.KeyCode == Keys.A)
                {
                    if(localDrivesButton.Checked == false)
                    {
                        localDrivesButton.Checked = true;
                    }
                    isDrive = true;
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textValidation();
            if (validPath)
            {
                folderpaths = new List<string> { textBox1.Text };
                isDrive = false;
            }
        }

        private void textValidation()
        {
            string path = textBox1.Text;
            if (!Path.IsPathRooted(path) || !Directory.Exists(path))
            {
                textBox1.ForeColor = Color.Red;
                validPath = false;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
                validPath = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
                textValidation();

            }
            if(e.KeyCode == Keys.Back)
            {
                textBox1.ForeColor = Color.Black;
            }
        }

        private void listView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            foreach(var p in progressBars)
            {
                Rectangle r1 = listView.Items[0].SubItems[4].Bounds;
                p.SetBounds(r1.X, r1.Y, r1.Width, r1.Height);

            }
        }


    }
    // https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5
    public class NewProgressBar : ProgressBar
    {
        public NewProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum));
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height;
            e.Graphics.FillRectangle(Brushes.Indigo, 0, 0, rec.Width, rec.Height);
        }
    }
}
