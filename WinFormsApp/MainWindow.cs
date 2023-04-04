using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        long pathSize;
        int progr = 0;


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

            LoadDrivesTree();
            backgroundWorker1.RunWorkerAsync();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadDrivesTree()
        {
            
            treeView1.Nodes.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    
                    TreeNode curNode = new TreeNode(d.Name);
                    curNode.Tag = d.Name;

                    foreach (var dir in Directory.GetDirectories(d.Name)) {
                        curNode.Nodes.Add(dir.Split(@"\")[1]);
                       
                    }
                    treeView1.Nodes.Add(curNode);
                    
                }
            }
            treeView1.Update();
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
                //NewTree(path);
            }

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSelect_Click(sender, e);
        }
        private void DSearch(string folderPath)
        {
            if(progr < 80) progr += 1;
            backgroundWorker1.ReportProgress(Math.Min(progr, 80));
            if (backgroundWorker1.CancellationPending == true)
            {
                dataReady = false;
                workerCancelled = true;
                return;
            }
            try
            {
                foreach (string filePath in Directory.GetFiles(folderPath)) // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-group-files-by-extension-linq
                {
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
                    DSearch(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {

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

            workerCancelled = false;
            progr = 0;
            
            DSearch(folderPath);

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
            int size = Math.Min(60 * chartPanel1.Width / 100, panel.Height);
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
            // Draw the pie chart
            using(Graphics g = chartPanel1.CreateGraphics()){
                g.Clear(Color.White);
                int size = DrawPie(g, chartPanel1, topCountFileTypes, totalCount);
                int legendLeft = size + 10;
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
                int legendLeft = size + 10;
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
                    else if (topSizeFileTypes[i].Value < 1048576)
                    {
                        sizeString = Math.Round((double)topSizeFileTypes[i].Value / 1024, 2) + " KB";
                    }
                    else
                    {
                        sizeString = Math.Round((double)topSizeFileTypes[i].Value / 1048576, 2) + " MB";
                    }
                    g.FillRectangle(new SolidBrush(chartColors[i]), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawRectangle(new Pen(Color.Black), legendLeft + 5, legendTop + 4 + i * 20, 20, 10);
                    g.DrawString(topSizeFileTypes[i].Key + " - " + sizeString, Font, Brushes.Black, legendLeft + 30, legendTop + i * 20);
                }
            }
            
        }


        private void DrawBarChart()
        {
            int barWidth = 20;
            int barHeight = chartPanel1.Height - 100;
            long max = topCountFileTypes.Max(x => x.Value);
            Font sFont = new Font(Font.FontFamily, Font.Size - 2, Font.Style);
            Font ssFont = new Font(Font.FontFamily, Font.Size - 4, Font.Style);

            int x = 60;
            int y = 30;
            
            long interval = max / 10;
            double log = Math.Ceiling(Math.Log10(interval));
            long roundedInterval = (long)Math.Pow(10, log);
            int yline = y + barHeight;
            int chartSpace = (int)Math.Round((double)roundedInterval * 10 / max * barHeight);
            int space = chartSpace / 10;

            // Create a graphics object to draw the chart.
            using (Graphics g = chartPanel1.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width-10, barHeight + 50);
                for (int j = 0; j <= 10; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50, yline, 470, yline);
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
                    // Draw the name of the extension under the bar.
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 + Math.Max(0, (60 - 4*k.Key.Length) / 2), y + barHeight);

                    // Move the x coordinate to the right for the next bar.
                    x += barWidth + 18;
                }
            }

            x = 60;
            max = topSizeFileTypes.Max(x => x.Value);
            yline = y + barHeight;
            interval = max / 10;
            log = Math.Ceiling(Math.Log10(interval));
            roundedInterval = (long)Math.Pow(10, log);
            yline = y + barHeight;
            chartSpace = (int)Math.Round((double)roundedInterval * 10 / max * barHeight);
            space = chartSpace / 10;

            // Draw each bar for the top size file types.
            using (Graphics g = chartPanel2.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width-10, barHeight + 50);
                for (int j = 0; j <= 10; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50, yline, 470, yline);
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
                    // Draw the name of the extension under the bar.
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 + Math.Max(0, (60 - 4*k.Key.Length)/2), y + barHeight);

                    // Move the x coordinate to the right for the next bar.
                    x += barWidth + 18;
                }
            }
        }

        private void chartPanel1_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChart();
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
                        foreach (var d in Directory.GetFiles((string)currNode.Tag))
                        {
                            string[] name = d.Split(@"\");
                            currNode.Nodes.Add(name[name.Length - 1]);
                        }
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
            int barWidth = 20;
            int barHeight = chartPanel1.Height - 100;
            long max = topCountFileTypes.Max(x => x.Value);
            Font sFont = new Font(Font.FontFamily, Font.Size - 2, Font.Style);
            Font ssFont = new Font(Font.FontFamily, Font.Size - 4, Font.Style);

            int x = 60;
            int y = 30;

            double logBase = Math.Log10(max);
            double scaleY = barHeight / logBase;
            int yline = y + barHeight;

            // Create a graphics object to draw the chart.
            using (Graphics g = chartPanel1.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width - 10, barHeight + 50);
                for (int j = 0; j <= logBase; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50, yline, 470, yline);
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
                    // Draw the name of the extension under the bar.
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 + Math.Max(0, (60 - 4 * k.Key.Length) / 2), y + barHeight);

                    // Move the x coordinate to the right for the next bar.
                    x += barWidth + 18;
                }
            }


            x = 60;
            max = topSizeFileTypes.Max(x => x.Value);
            yline = y + barHeight;

            logBase = Math.Log10(max);
            scaleY = barHeight / logBase;
            yline = y + barHeight;


            // Draw each bar for the top size file types.
            using (Graphics g = chartPanel2.CreateGraphics())
            {
                g.Clear(Color.White);
                g.FillRectangle(new SolidBrush(Color.Lavender), 0, 10, chartPanel1.Width - 10, barHeight + 50);
                for (int j = 0; j <= logBase; j++)
                {
                    g.DrawLine(new Pen(Color.Black), 50, yline, 470, yline);
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
                    // Draw the name of the extension under the bar.
                    g.DrawString(k.Key, sFont, Brushes.Black, x - 30 + Math.Max(0, (60 - 4 * k.Key.Length) / 2), y + barHeight);

                    // Move the x coordinate to the right for the next bar.
                    x += barWidth + 18;
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
            if(workerCancelled == true)
            {
                workerCancelled = false;
                return;
            }
            while(progr <= 100)
            {
                toolStripProgressBar1.Value = progr++;
            }
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
            if ((File.GetAttributes((string)treeView1.SelectedNode.Tag) & FileAttributes.Directory) != FileAttributes.Directory)
                return;

            string oldPath = currPath;
            currPath = (string)treeView1.SelectedNode.Tag;


            if(oldPath != currPath)
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
            }

            

        }
    }
}