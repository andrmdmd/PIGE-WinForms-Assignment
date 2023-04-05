using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

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
        string currPath = "C:\\";
        bool dataReady = false, runOnFinish = false, workerCancelled = false;
        string chartType;
        List<KeyValuePair<string, long>> topCountFileTypes;
        List<KeyValuePair<string, long>> topSizeFileTypes;

        Dictionary<string, long> CountFileTypes;
        Dictionary<string, long> SizeFileTypes;

        long totalCount;
        long totalSize;
        int progr = 0;
        int subfoldersNum = 1;
        int subdirs = 0;
        int files = 0;


        public MainWindow()
        {
            InitializeComponent();
            //StartTree();
           
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            chartBox.Items.Clear();
            chartBox.Items.Add("Pie chart");
            chartBox.Items.Add("Bar chart");
            chartBox.Items.Add("Log bar chart");

            chartPanel1.Width = chartsPage.Width / 2;
            chartPanel2.Width = chartsPage.Width / 2;
            chartPanel1.Height = 80 * chartsPage.Height/100;
            chartPanel2.Height = 80 * chartsPage.Height/100;
            chartPanel2.SetBounds(chartPanel1.Location.X + chartsPage.Width / 2, chartPanel2.Location.Y, chartPanel2.Width, chartPanel2.Height);

            LoadDrivesTree(DriveInfo.GetDrives());
            backgroundWorker1.RunWorkerAsync();
            cancelToolStripMenuItem.Enabled = true;


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CreateFilesNode(string dirName, TreeNode curNode)
        {
            List<string> files = new List<string>();
            foreach (var dir in Directory.GetFiles(currPath))
            {
                string[] name = dir.Split(@"\");
                files.Add(name[name.Length - 1]);
            }
            if(files.Count > 3)
            {
                TreeNode fileNode = new TreeNode("Files");
                
                foreach(var f in files)
                    fileNode.Nodes.Add(f);

                curNode.Nodes.Add(fileNode);
            }
            else
            {
                foreach (var f in files)
                    curNode.Nodes.Add(f);
            }
        }
        private void LoadDrivesTree(DriveInfo[] drives)
        {
            treeView1.Nodes.Clear();

            foreach (DriveInfo d in drives)
            {
                if (d.IsReady == true)
                {
                    
                    TreeNode curNode = new TreeNode(d.Name);
                    curNode.Tag = d.Name;

                    foreach (var dir in Directory.GetDirectories(d.Name)) {
                        curNode.Nodes.Add(dir.Split(@"\")[1]);
                       
                    }
                    treeView1.Nodes.Add(curNode);
                    CreateFilesNode(d.Name, curNode);
                    
                }
            }
            treeView1.Update();
        }


        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogBox selectDialog = new DialogBox();

            if (selectDialog.ShowDialog(this) == DialogResult.OK)
            {

                string oldPath = currPath;
                if (selectDialog.folderpaths.Count == 1)
                {
                    currPath = (string)selectDialog.folderpaths[0];

                    if (oldPath != currPath)
                    {
                        treeView1.Nodes.Clear();

                        TreeNode curNode = new TreeNode(currPath);
                        curNode.Tag = currPath;
                        
                        string[] pathname = currPath.Split(@"\");
                        curNode.Text = pathname[pathname.Length - 1];
                        foreach (var dir in Directory.GetDirectories(currPath))
                        {
                            string[] name = dir.Split(@"\");
                            curNode.Nodes.Add(name[name.Length - 1]);

                        }
                        treeView1.Nodes.Add(curNode);

                        if (backgroundWorker1.IsBusy == true)
                        {
                            backgroundWorker1.CancelAsync();
                            workerCancelled = true;
                        }

                        while (backgroundWorker1.IsBusy)
                            Application.DoEvents();

                        if (chartBox.SelectedItem != null)
                            runOnFinish = true;
                        workerCancelled = false;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    DriveInfo[] drivesInfo = selectDialog.folderpaths.Select(x => new DriveInfo(x)).ToArray();
                    LoadDrivesTree(drivesInfo);
                }
            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSelect_Click(sender, e);
        }
        private void DSearch(string folderPath, int layer)
        {
            
            if (backgroundWorker1.CancellationPending)
            {
                dataReady = false;
                workerCancelled = true;
                return;
            }
            try
            {
                foreach (string filePath in Directory.GetFiles(folderPath)) // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-group-files-by-extension-linq
                {
                    files++;
                    try
                    {
                        string fileType = Path.GetExtension(filePath).ToLower();
                        FileInfo fileInfo = new FileInfo(filePath);

                        if (!CountFileTypes.ContainsKey(fileType))
                        {
                            CountFileTypes.Add(fileType, 1);
                        }
                        else
                        {
                            CountFileTypes[fileType]++;
                        }

                        if (!SizeFileTypes.ContainsKey(fileType))
                        {
                            SizeFileTypes.Add(fileType, fileInfo.Length);
                        }
                        else
                        {
                            SizeFileTypes[fileType] += fileInfo.Length;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {

                    }
                }
                foreach (var dir in Directory.GetDirectories(folderPath))
                {
                    subdirs++;
                    DSearch(dir, layer+1);
                }
            }
            catch (UnauthorizedAccessException)
            {

            }

            if (layer == 1)
            {
                progr++;
                backgroundWorker1.ReportProgress(progr * 100 / subfoldersNum);
            }

        }
        private void getFolderData()
        {
            dataReady = false; 
            string folderPath = currPath;
            CountFileTypes = new();
            SizeFileTypes= new();

            topCountFileTypes = new();
            topSizeFileTypes = new();


            backgroundWorker1.ReportProgress(0);

            workerCancelled = false;
            progr = 0;
            subfoldersNum = 0;
            subdirs = 0;
            files = 0;

            try
            {
                string[] subdirectories = Directory.GetDirectories(currPath);


            
                foreach (string subdirectory in subdirectories)
                {
                    try
                    {
                        if(Directory.Exists(subdirectory)) {
                            subfoldersNum++;
                        }
                        
                    }
                    catch (UnauthorizedAccessException)
                    {
                        
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }

            subfoldersNum = Math.Max(1, subfoldersNum);
            DSearch(folderPath, 0);

            if(backgroundWorker1.CancellationPending == true)
            {
                return;
            }
            backgroundWorker1.ReportProgress(100);


            var sortedFileTypes = CountFileTypes.OrderByDescending(pair => pair.Value);
            topCountFileTypes = sortedFileTypes.Take(10).ToList();

            var otherFilesCount = sortedFileTypes.Skip(10).Sum(pair => pair.Value);
            if(otherFilesCount > 0) topCountFileTypes.Add(new KeyValuePair<string, long>("Others", otherFilesCount));

            sortedFileTypes = SizeFileTypes.OrderByDescending(pair => pair.Value);
            topSizeFileTypes = sortedFileTypes.Take(10).ToList();

            otherFilesCount = sortedFileTypes.Skip(10).Sum(pair => pair.Value);
            if (otherFilesCount > 0) topSizeFileTypes.Add(new KeyValuePair<string, long>("Others", otherFilesCount));


            totalCount = CountFileTypes.Values.Sum();
            totalSize = SizeFileTypes.Values.Sum();
        }
        private int DrawPie(Graphics g, Panel panel, List<KeyValuePair<string, long>> topTypes, long total)
        {
            g.Clear(Color.White);
            int size = Math.Min(55 * chartPanel1.Width / 100, panel.Height);
            Rectangle rect = new Rectangle(0, 0, size, size);
            float startAngle = 0;
            int i = 0;

            foreach (KeyValuePair<string, long> pair in topTypes)
            {
                float sweepAngle = (float)pair.Value / total * 360;
                g.FillPie(new SolidBrush(chartColors[i]), rect, startAngle, sweepAngle);
                g.DrawPie(new Pen(Color.Black), rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
                i++;
            }
            return size;

        }
        private void DrawPieChart()
        {
            if (topCountFileTypes.Count == 0 || topSizeFileTypes.Count == 0)
                return;
            
            using (Graphics g = chartPanel1.CreateGraphics()){
                g.Clear(Color.White);
                int size = DrawPie(g, chartPanel1, topCountFileTypes, totalCount);
                int legendLeft = size + 10 * chartPanel1.Width / 505;
                int legendTop = 0;
                int legendWidth = 100;
                int legendHeight = topCountFileTypes.Count * 20 + 10;
                for (int i = 0; i < topCountFileTypes.Count; i++)
                {
                    g.FillRectangle(new SolidBrush(chartColors[i]), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawRectangle(new Pen(Color.Black), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawString(topCountFileTypes[i].Key + " - " + topCountFileTypes[i].Value, Font, Brushes.Black, legendLeft + 30, legendTop + i * 20);
                }
            }

            using(Graphics g = chartPanel2.CreateGraphics()) {
                g.Clear(Color.White);
                int size = DrawPie(g, chartPanel2, topSizeFileTypes, totalSize);
                int legendLeft = size + 10 * chartPanel2.Width / 505;
                int legendTop = 0;
                int legendWidth = 100;
                int legendHeight = topSizeFileTypes.Count * 20 + 10;
                for (int i = 0; i < topSizeFileTypes.Count; i++)
                {
                    string sizeString;

                    if (topSizeFileTypes[i].Value < 1024)
                    {
                        sizeString = topSizeFileTypes[i].Value + " bytes";
                    }
                    else if (topSizeFileTypes[i].Value < 1024 * 1024)
                    {
                        sizeString = Math.Round((double)topSizeFileTypes[i].Value / 1024, 2) + " KB";
                    }
                    else if (topSizeFileTypes[i].Value < 1024 * 1024 * 1024)
                    {
                        sizeString = Math.Round((double)topSizeFileTypes[i].Value / (1024 * 1024), 2) + " MB";
                    }
                    else
                    {
                        sizeString = Math.Round((double)topSizeFileTypes[i].Value / (1024 * 1024 * 1024), 2) + " MB";
                    }
                    g.FillRectangle(new SolidBrush(chartColors[i]), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawRectangle(new Pen(Color.Black), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawString(topSizeFileTypes[i].Key + " - " + sizeString, Font, Brushes.Black, legendLeft + 30, legendTop + i * 20);
                }
            }   
        }


        private void DrawBarChart()
        {
            if (topCountFileTypes.Count == 0 || topSizeFileTypes.Count == 0)
                return;
            int barWidth = 20 * chartPanel1.Width / 505;
            int barHeight = chartPanel1.Height - 100;
            long max = topCountFileTypes.Max(x => x.Value);
            Font sFont = new Font(Font.FontFamily, Font.Size - 2, Font.Style);
            Font ssFont = new Font(Font.FontFamily, Font.Size - 4, Font.Style);

            int x = 60 * chartPanel1.Width / 505;
            int y = 30;
            
            long interval = max / 10;
            double log = Math.Ceiling(Math.Log10(interval));
            long roundedInterval = (long)Math.Pow(10, log);
            int yline = y + barHeight;
            int chartSpace = (int)Math.Round((double)roundedInterval * 10 / max * barHeight);
            int space = chartSpace / 10;

            using (Graphics g = chartPanel1.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width - 20 * chartPanel1.Width / 505, barHeight + 50);
                for (int j = 0; j <= 10; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50 * chartPanel1.Width / 505, yline, chartPanel1.Width - 30 * chartPanel1.Width / 505, yline);
                    g.DrawString($"{j}*10^{log}", ssFont, Brushes.Black, 5, yline - 10);
                    yline -= space;
                    if (yline < 10) break;
                }
                for (int i = 0; i < topCountFileTypes.Count; i++)
                {
                    var k = topCountFileTypes[i];

                    int height  = (int)Math.Round((double)k.Value / max * barHeight);
                    g.FillRectangle(new SolidBrush(chartColors[i]), x, y + barHeight - height, barWidth,height);
                    g.DrawRectangle(new Pen(Color.Black), x, y + barHeight - height, barWidth, height);
                    
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 * chartPanel1.Width / 505 + Math.Max(0, (60 * chartPanel1.Width / 505 - 4*k.Key.Length) / 2), y + barHeight);

                    x += barWidth + 18 * chartPanel1.Width / 505;
                }
            }

            x = 60 * chartPanel2.Width / 505;
            max = topSizeFileTypes.Max(x => x.Value);
            yline = y + barHeight;
            interval = max / 10;
            log = Math.Ceiling(Math.Log10(interval));
            roundedInterval = (long)Math.Pow(10, log);
            yline = y + barHeight;
            chartSpace = (int)Math.Round((double)roundedInterval * 10 / max * barHeight);
            space = chartSpace / 10;

            using (Graphics g = chartPanel2.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel2.Width - 10 * chartPanel2.Width / 505, barHeight + 50);
                for (int j = 0; j <= 10; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50 * chartPanel2.Width / 505, yline, chartPanel2.Width - 30 * chartPanel2.Width / 505, yline);
                    g.DrawString($"{j}*10^{log}", ssFont, Brushes.Black, 5, yline-10);
                    yline -= space;
                    if (yline < 10) break;
                }
                for (int i = 0; i < topSizeFileTypes.Count; i++)
                {
                    var k = topSizeFileTypes[i];

                    int height = (int)Math.Round((double)k.Value / max * barHeight);
                    g.FillRectangle(new SolidBrush(chartColors[i]), x, y + barHeight - height, barWidth, height);
                    g.DrawRectangle(new Pen(Color.Black), x, y + barHeight - height, barWidth, height);
                    
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 * chartPanel2.Width / 505  + Math.Max(0, (60 * chartPanel2.Width / 505 - 4*k.Key.Length)/2), y + barHeight);

                    x += barWidth + 18 * chartPanel2.Width / 505;
                }
            }
        }

        private void chartPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode currNode in e.Node.Nodes)
            {
                currNode.Tag = currNode.Parent.Tag + currNode.Text + @"\";

                if (Directory.Exists((string)currNode.Tag))
                {
                    try
                    {
                        foreach (var d in Directory.GetDirectories((string)currNode.Tag))
                        {
                            string[] name = d.Split(@"\");
                            currNode.Nodes.Add(name[name.Length-1]);
                        }
                        CreateFilesNode((string)currNode.Tag, currNode);
                    }
                    catch (Exception ex)
                    { 
                    }
                }
            }
            treeView1.Update();
        }

        private void DrawLogBarChart()
        {
            if (topCountFileTypes.Count == 0 || topSizeFileTypes.Count == 0)
                return;
            int barWidth = 4 * chartPanel1.Width / 100;
            int barHeight = chartPanel1.Height - 100;
            long max = topCountFileTypes.Max(x => x.Value);
            Font sFont = new Font(Font.FontFamily, Font.Size - 2, Font.Style);
            Font ssFont = new Font(Font.FontFamily, Font.Size - 4, Font.Style);

            int x = 60 * chartPanel1.Width / 505;
            int y = 30;

            double logBase = Math.Log10(max);
            double scaleY = barHeight / logBase;
            int yline = y + barHeight;

            using (Graphics g = chartPanel1.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width - 20 * chartPanel2.Width / 505, barHeight + 50);
                for (int j = 0; j <= logBase; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50 * chartPanel2.Width / 505, yline, chartPanel1.Width - 40 * chartPanel1.Width / 505, yline);
                    g.DrawString($"10^{j}", ssFont, Brushes.Black, 5, yline - 10);
                    yline -= (int)scaleY;
                    if (yline < 10) break;
                }
                for (int i = 0; i < topCountFileTypes.Count; i++)
                {
                    var k = topCountFileTypes[i];

                    double logValue = Math.Log10(topCountFileTypes[i].Value);
                    int height = (int)(logValue * scaleY);

                    g.FillRectangle(new SolidBrush(chartColors[i]), x, y + barHeight - height, barWidth, height);
                    g.DrawRectangle(new Pen(Color.Black), x, y + barHeight - height, barWidth, height);

                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 * chartPanel1.Width / 505 + Math.Max(0, (60 * chartPanel1.Width / 505 - 4 * k.Key.Length) / 2), y + barHeight);

                    x += barWidth + 18 * chartPanel1.Width / 505;
                }
            }

            x = 60 * chartPanel1.Width / 505;
            max = topSizeFileTypes.Max(x => x.Value);
            yline = y + barHeight;

            logBase = Math.Log10(max);
            scaleY = barHeight / logBase;
            yline = y + barHeight;

            using (Graphics g = chartPanel2.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel2.Width - 20 * chartPanel2.Width / 505, barHeight + 50);
                for (int j = 0; j <= logBase; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50 * chartPanel2.Width / 505, yline, chartPanel2.Width - 40 * chartPanel1.Width / 505, yline);
                    g.DrawString($"10^{j}", ssFont, Brushes.Black, 5, yline - 10);
                    yline -= (int)scaleY;
                    if (yline < 10) break;
                }
                for (int i = 0; i < topSizeFileTypes.Count; i++)
                {
                    var k = topSizeFileTypes[i];

                    double logValue = Math.Log10(topSizeFileTypes[i].Value);
                    int height = (int)(logValue * scaleY);

                    g.FillRectangle(new SolidBrush(chartColors[i]), x, y + barHeight - height, barWidth, height);
                    g.DrawRectangle(new Pen(Color.Black), x, y + barHeight - height, barWidth, height);
                    
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 * chartPanel1.Width / 505 + Math.Max(0, (60 * chartPanel2.Width / 505 - 4 * k.Key.Length) / 2), y + barHeight);

                    x += barWidth + 18 * chartPanel2.Width / 505;
                }
            }

        }

        private void chartBox_SelectedValueChanged(object sender, EventArgs e)
        {
            chartType = (string)chartBox.SelectedItem;
            if (dataReady)
            {
                switch ((string)chartBox.SelectedItem)
                {
                    case "Pie chart":
                        DrawPieChart();
                        break;
                    case "Bar chart":
                        DrawBarChart();
                        break;
                    case "Log bar chart":
                        DrawLogBarChart();
                        break;
                }
            }
            else
                runOnFinish = true;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            getFolderData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            cancelToolStripMenuItem.Enabled = false;

            if (workerCancelled == true)
            {
                workerCancelled = false;
                return;
            }


            string last = Directory.GetLastAccessTime(currPath).ToString();
            string sizeString;

            if (totalSize < 1024)
            {
                sizeString = totalCount + " bytes";
            }
            else if (totalSize < 1024 * 1024)
            {
                sizeString = Math.Round((double)totalSize / 1024, 2) + " KB";
            }
            else if (totalSize < 1024 * 1024 * 1024)
            {
                sizeString = Math.Round((double)totalSize / (1024 * 1024), 2) + " MB";
            }
            else
            {
                sizeString = Math.Round((double)totalSize / (1024 * 1024 * 1024), 2) + " GB";
            }
            detailLabel2.Text = $"{currPath}\n{sizeString}\n{files + subdirs}\n{files}\n{subdirs}\n{last}";


            dataReady = true;
            if (runOnFinish)
            {
                switch (chartType)
                {
                    case "Pie chart":
                        DrawPieChart();
                        break;
                    case "Bar chart":
                        DrawBarChart();
                        break;
                    case "Log bar chart":
                        DrawLogBarChart();
                        break;

                }
                runOnFinish = false;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            while (backgroundWorker1.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            
            cancelToolStripMenuItem.Enabled = false;
        }

        private void chartsPage_SizeChanged(object sender, EventArgs e)
        {
            chartPanel1.Width = chartsPage.Width / 2;
            chartPanel2.Width = chartsPage.Width / 2;
            chartPanel1.Height = 80 * chartsPage.Height / 100;
            chartPanel2.Height = 80 * chartsPage.Height / 100;
            chartPanel2.SetBounds(chartPanel1.Location.X + chartsPage.Width / 2, chartPanel2.Location.Y, chartPanel2.Width, chartPanel2.Height);
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            switch (chartType)
            {
                case "Pie chart":
                    DrawPieChart();
                    break;
                case "Bar chart":
                    DrawBarChart();
                    break;
                case "Log bar chart":
                    DrawLogBarChart();
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null)
                if(treeView1.SelectedNode.Text == "Files" || treeView1.SelectedNode.Parent.Text == "Files" || (File.GetAttributes((string)treeView1.SelectedNode.Parent.Tag + treeView1.SelectedNode.Text) & FileAttributes.Directory) != FileAttributes.Directory)
                    return;

            string oldPath = currPath;
            currPath = (string)treeView1.SelectedNode.Tag;


            if (oldPath != currPath)
            {
                if (backgroundWorker1.IsBusy == true)
                {
                    backgroundWorker1.CancelAsync();
                    workerCancelled = true;
                }

                while (backgroundWorker1.IsBusy)
                    Application.DoEvents();

                if (chartBox.SelectedItem != null)
                    runOnFinish = true;
                workerCancelled = false;
                backgroundWorker1.RunWorkerAsync();
                cancelToolStripMenuItem.Enabled = true;
            }

            

        }
    }
}