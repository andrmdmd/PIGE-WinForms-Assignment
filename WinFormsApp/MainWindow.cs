using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainWindow : Form
    {
        Color[] chartColors = {
                Color.FromArgb(255, 110, 110),   // red
                Color.FromArgb(255, 174, 98),    // orange
                Color.FromArgb(255, 238, 88),    // yellow
                Color.FromArgb(146, 229, 98),    // green
                Color.FromArgb(98, 229, 171),    // green-blue
                Color.FromArgb(98, 210, 229),    // turquoise
                Color.FromArgb(98, 146, 229),    // blue
                Color.FromArgb(146, 98, 229),    // blue-purple
                Color.FromArgb(210, 98, 229),    // purple
                Color.FromArgb(229, 98, 180),    // magenta
                Color.FromArgb(229, 98, 130)     // pink
                };

        public MainWindow()
        {
            InitializeComponent();
            //StartTree();
            NewTree(@"C:\Users\4NDR0M3D4");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartBox.Items.Clear();
            chartBox.Items.Add("Pie chart");
            chartBox.Items.Add("Log chart");
        }
        private void NewTree(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                BuildTree(directoryInfo, treeView1.Nodes);
            }
        }

        private void StartTree()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {

                if (d.IsReady == true)
                {
                    TreeNode curNode = treeView1.Nodes.Add(d.Name);

                    DirectoryInfo directoryInfo = new DirectoryInfo(d.Name);

                    if ((directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        // The directory is hidden
                        continue;
                    }
                    if (directoryInfo.Exists)
                    {

                        foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                        {
                            try
                            {
                                BuildTree(subdir, curNode.Nodes);
                            }
                            catch (UnauthorizedAccessException)
                            {
                                // Skip over directories that can't be accessed
                            }
                        }
                    }
                }
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe) // https://stackoverflow.com/questions/16315042/how-to-display-directories-in-a-treeview
        {

            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            if ((directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                // The directory is hidden
                Console.WriteLine("The directory is hidden.");
                return;
            }



            //foreach (FileInfo file in directoryInfo.GetFiles())
            //{
            //    try
            //    {
            //        curNode.Nodes.Add(file.FullName, file.Name);
            //    }
            //    catch (UnauthorizedAccessException)
            //    {
            //        // Skip over files that can't be accessed
            //    }
            //}

            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                try
                {
                    BuildTree(subdir, curNode.Nodes);
                }
                catch (UnauthorizedAccessException)
                {
                    // Skip over directories that can't be accessed
                }
            }


        }



        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogBox testDialog = new DialogBox();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = testDialog.folderpath;
                treeView1.Nodes.Clear();
                NewTree(path);
            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSelect_Click(sender, e);
        }
        private void chartPanel1_Paint(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\4NDR0M3D4\OneDrive\studia\internship";
            
            Dictionary<string, int> fileTypeCounts = new Dictionary<string, int>();
            foreach (string filePath in Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)) // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-group-files-by-extension-linq
            {
                try
                {
                    string fileType = Path.GetExtension(filePath).ToLower();
                    if (!fileTypeCounts.ContainsKey(fileType))
                    {
                        fileTypeCounts.Add(fileType, 1);
                    }
                    else
                    {
                        fileTypeCounts[fileType]++;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }

            
            var sortedFileTypes = fileTypeCounts.OrderByDescending(pair => pair.Value); 
            List<KeyValuePair<string, int>> topFileTypes = sortedFileTypes.Take(10).ToList();
            int otherFilesCount = sortedFileTypes.Skip(10).Sum(pair => pair.Value);
            topFileTypes.Add(new KeyValuePair<string, int>("Others", otherFilesCount));
            int i = 0;


            int totalCount = fileTypeCounts.Values.Sum();

            // Draw the pie chart
            Graphics g = chartPanel1.CreateGraphics();
            g.Clear(Color.White);
            int size = Math.Min(60 * chartPanel1.Width / 100, chartPanel1.Height);
            Rectangle rect = new Rectangle(0, 0, size, size);
            float startAngle = 0;
            i = 0;
            foreach (KeyValuePair<string, int> pair in topFileTypes)
            {
                float sweepAngle = (float)pair.Value / totalCount * 360;
                g.FillPie(new SolidBrush(chartColors[i]), rect, startAngle, sweepAngle);
                g.DrawPie(new Pen(Color.Black), rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
                i++;
            }

            // Draw the legend
            int legendLeft = size + 10;
            int legendTop = 0;
            int legendWidth = 100;
            int legendHeight = topFileTypes.Count * 20 + 10;

            //g.FillRectangle(Brushes.White, legendLeft, legendTop, legendWidth, legendHeight);
            //g.DrawRectangle(Pens.Black, legendLeft, legendTop, legendWidth, legendHeight);
            for (i = 0; i < topFileTypes.Count; i++)
            {
                g.FillRectangle(new SolidBrush(chartColors[i]), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                g.DrawRectangle(new Pen(Color.Black), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                g.DrawString(topFileTypes[i].Key + " - " + topFileTypes[i].Value, Font, Brushes.Black, legendLeft + 30, legendTop + i * 20);
            }
        }

        private void chartPanel2_Paint(object sender, PaintEventArgs e)
        {

            string folderPath = @"C:\Users\4NDR0M3D4\OneDrive\studia";
            // Get a list of all the file types in the folder
            Dictionary<string, long> fileTypeSizes = new Dictionary<string, long>();
            foreach (string filePath in Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string fileType = Path.GetExtension(filePath).ToLower();

                    if (!fileTypeSizes.ContainsKey(fileType))
                    {
                        fileTypeSizes.Add(fileType, 1);
                    }
                    else
                    {

                        fileTypeSizes[fileType] += fileInfo.Length;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }

            // Sort the file types by count, and group the rest as "Others"
            var sortedFileTypes = fileTypeSizes.OrderByDescending(pair => pair.Value);
            List<KeyValuePair<string, long>> topFileTypes = sortedFileTypes.Take(10).ToList();
            long otherFilesCount = sortedFileTypes.Skip(10).Sum(pair => pair.Value);
            topFileTypes.Add(new KeyValuePair<string, long>("Others", otherFilesCount));
            int i = 0;
            // Define the colors to use for each slice


            // Calculate the total count of files
            long totalCount = fileTypeSizes.Values.Sum();

            // Draw the pie chart
            Graphics g = chartPanel2.CreateGraphics();
            g.Clear(Color.White);
            int size = Math.Min(60 * chartPanel1.Width / 100, chartPanel2.Height);
            Rectangle rect = new Rectangle(0, 0, size, size);
            float startAngle = 0;
            i = 0;
            foreach (KeyValuePair<string, long> pair in topFileTypes)
            {
                float sweepAngle = (float)pair.Value / totalCount * 360;
                g.FillPie(new SolidBrush(chartColors[i]), rect, startAngle, sweepAngle);
                g.DrawPie(new Pen(Color.Black), rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
                i++;
            }

            // Draw the legend
            int legendLeft = size + 10;
            int legendTop = 0;
            int legendWidth = 100;
            int legendHeight = topFileTypes.Count * 20 + 10;

            //g.FillRectangle(Brushes.White, legendLeft, legendTop, legendWidth, legendHeight);
            //g.DrawRectangle(Pens.Black, legendLeft, legendTop, legendWidth, legendHeight);
            for (i = 0; i < topFileTypes.Count; i++)
            {
                string sizeString;
                if (topFileTypes[i].Value < 1024)
                {
                    sizeString = topFileTypes[i].Value + " bytes";
                }
                else if (topFileTypes[i].Value < 1048576)
                {
                    sizeString = Math.Round((double)topFileTypes[i].Value / 1024, 2) + " KB";
                }
                else
                {
                    sizeString = Math.Round((double)topFileTypes[i].Value / 1048576, 2) + " MB";
                }

                g.FillRectangle(new SolidBrush(chartColors[i]), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                g.DrawRectangle(new Pen(Color.Black), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                g.DrawString(topFileTypes[i].Key + " - " + sizeString, Font, Brushes.Black, legendLeft + 30, legendTop + i * 20);
            }
        }
    }


}