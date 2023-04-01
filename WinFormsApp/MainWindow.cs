namespace WinFormsApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            NewTree(".");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void NewTree(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                BuildTree(directoryInfo, treeView1.Nodes);
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe) // https://stackoverflow.com/questions/16315042/how-to-display-directories-in-a-treeview
        {
            try
            {
                TreeNode curNode = addInMe.Add(directoryInfo.Name);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    try
                    {
                        curNode.Nodes.Add(file.FullName, file.Name);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Skip over files that can't be accessed
                    }
                }

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
            catch (UnauthorizedAccessException)
            {
                // Skip over the root directory if it can't be accessed
            }
        }



        private void splitContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogBox testDialog = new DialogBox();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if( testDialog.ShowDialog(this) == DialogResult.OK )
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
    }
}