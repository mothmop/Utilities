using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameCytocam
{
    /// <summary>
    /// Summary description for Form1
    /// </summary>
    //public class Form1 : System.Windows.Forms.Form
    //{
    //    internal System.Windows.Forms.Button btnSearch;
    //    internal System.Windows.Forms.TextBox txtFile;
    //    internal System.Windows.Forms.Label lblFile;
    //    internal System.Windows.Forms.Label lblDirectory;
    //    internal System.Windows.Forms.ListBox lstFilesFound;
    //    internal System.Windows.Forms.ComboBox cboDirectory;
    //    /// <summary>
    //    /// Required designer variable
    //    /// </summary>
    //    private System.ComponentModel.Container components = null;

    //    public Form1()
    //    {
    //        // 
    //        // Required for Windows Form Designer support
    //        // 
    //        InitializeComponent();

    //        // 
    //        // TODO: Add any constructor code after InitializeComponent call.
    //        // 
    //    }

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (components != null)
    //            {
    //                components.Dispose();
    //            }
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code
    //    /// <summary>
    //    /// Required method for Designer support: do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.btnSearch = new System.Windows.Forms.Button();
    //        this.txtFile = new System.Windows.Forms.TextBox();
    //        this.lblFile = new System.Windows.Forms.Label();
    //        this.lblDirectory = new System.Windows.Forms.Label();
    //        this.lstFilesFound = new System.Windows.Forms.ListBox();
    //        this.cboDirectory = new System.Windows.Forms.ComboBox();
    //        this.SuspendLayout();
    //        // 
    //        // btnSearch
    //        // 
    //        this.btnSearch.Location = new System.Drawing.Point(608, 248);
    //        this.btnSearch.Name = "btnSearch";
    //        this.btnSearch.TabIndex = 0;
    //        this.btnSearch.Text = "Search";
    //        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
    //        // 
    //        // txtFile
    //        // 
    //        this.txtFile.Location = new System.Drawing.Point(8, 40);
    //        this.txtFile.Name = "txtFile";
    //        this.txtFile.Size = new System.Drawing.Size(120, 20);
    //        this.txtFile.TabIndex = 4;
    //        this.txtFile.Text = "*.dll";
    //        // 
    //        // lblFile
    //        // 
    //        this.lblFile.Location = new System.Drawing.Point(8, 16);
    //        this.lblFile.Name = "lblFile";
    //        this.lblFile.Size = new System.Drawing.Size(144, 16);
    //        this.lblFile.TabIndex = 5;
    //        this.lblFile.Text = "Search for files containing:";
    //        // 
    //        // lblDirectory
    //        // 
    //        this.lblDirectory.Location = new System.Drawing.Point(8, 96);
    //        this.lblDirectory.Name = "lblDirectory";
    //        this.lblDirectory.Size = new System.Drawing.Size(120, 23);
    //        this.lblDirectory.TabIndex = 3;
    //        this.lblDirectory.Text = "Look In:";
    //        // 
    //        // lstFilesFound
    //        // 
    //        this.lstFilesFound.Location = new System.Drawing.Point(152, 8);
    //        this.lstFilesFound.Name = "lstFilesFound";
    //        this.lstFilesFound.Size = new System.Drawing.Size(528, 225);
    //        this.lstFilesFound.TabIndex = 1;
    //        // 
    //        // cboDirectory
    //        // 
    //        this.cboDirectory.DropDownWidth = 112;
    //        this.cboDirectory.Location = new System.Drawing.Point(8, 128);
    //        this.cboDirectory.Name = "cboDirectory";
    //        this.cboDirectory.Size = new System.Drawing.Size(120, 21);
    //        this.cboDirectory.TabIndex = 2;
    //        this.cboDirectory.Text = "ComboBox1";
    //        // 
    //        // Form1
    //        // 
    //        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    //        this.ClientSize = new System.Drawing.Size(688, 277);
    //        this.Controls.AddRange(new System.Windows.Forms.Control[] {

    //        this.btnSearch,
    //        this.txtFile,
    //        this.lblFile,
    //        this.lblDirectory,
    //        this.lstFilesFound,
    //        this.cboDirectory});

    //        this.Name = "Form1";
    //        this.Text = "Form1";
    //        this.Load += new System.EventHandler(this.Form1_Load);
    //        this.ResumeLayout(false);

    //    }
    //    #endregion

    //    /// <summary>
    //    /// The main entry point for the application
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.Run(new Form1());
    //    }

    //    private void btnSearch_Click(object sender, System.EventArgs e)
    //    {
    //        lstFilesFound.Items.Clear();
    //        txtFile.Enabled = false;
    //        cboDirectory.Enabled = false;
    //        btnSearch.Text = "Searching...";
    //        this.Cursor = Cursors.WaitCursor;
    //        Application.DoEvents();
    //        DirSearch(cboDirectory.Text);
    //        btnSearch.Text = "Search";
    //        this.Cursor = Cursors.Default;
    //        txtFile.Enabled = true;
    //        cboDirectory.Enabled = true;
    //    }

    //    private void Form1_Load(object sender, System.EventArgs e)
    //    {
    //        cboDirectory.Items.Clear();
    //        foreach (string s in Directory.GetLogicalDrives())
    //        {
    //            cboDirectory.Items.Add(s);
    //        }
    //        cboDirectory.Text = "C:\\";
    //    }

    //    void DirSearch(string sDir)
    //    {
    //        try
    //        {
    //            foreach (string d in Directory.GetDirectories(sDir))
    //            {
    //                foreach (string f in Directory.GetFiles(d, txtFile.Text))
    //                {
    //                    lstFilesFound.Items.Add(f);
    //                }
    //                DirSearch(d);
    //            }
    //        }
    //        catch (System.Exception excpt)
    //        {
    //            Console.WriteLine(excpt.Message);
    //        }
    //    }
    //}

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] hyphen = { '-' };
            ofd.Filter = "MHA|*.mha";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                string[] fileParts = Path.GetFileNameWithoutExtension(ofd.FileName).Split(hyphen);
                string baseFolder = string.Join("-", fileParts[0], fileParts[1], fileParts[2], fileParts[3], fileParts[4]);
                textBox2.Text = baseFolder;
                textBox3.Text = textBox2.Text;
            };

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = textBox1.Text;
            string newBase = textBox3.Text;
            //string directoryName;
            //int i = 0;
            checkBox1.Checked = false;
            if (filePath != null)
            {
                string inwild = textBox2.Text + "*";
                string inbase = Path.GetDirectoryName(Path.GetDirectoryName(filePath));
                string[] directories = Directory.GetDirectories(inbase);
                string foobar = Path.GetFullPath(inbase);
                //string[] files; // = Directory.GetFiles(inwild, inbase, SearchOption.AllDirectories);

                foreach (string dir in directories)
                {
                    string newDir = dir.Replace(textBox2.Text, textBox3.Text);
                    try
                    {
                        Directory.CreateDirectory(newDir);
                    }
                    catch
                    {
                        Console.WriteLine("\tError: Could not create " + newDir);
                    }

                    string[] files = Directory.GetFiles(dir);
                    foreach (string file in files)
                    {
                        string newFile = file.Replace(textBox2.Text, textBox3.Text);
                        if (File.Exists(file))
                        {
                            File.Copy(file, newFile, true);
                            Console.WriteLine("\tCopied " + file + " to " + newFile);
                        }
                        else
                        {
                            Console.WriteLine("\tError: FileNotFound " + file);
                        }
                    }
                }
                if (!checkBox1.Checked)
                {
                    checkBox1.Checked = true;
                }
                //directoryName = Path.GetDirectoryName(filePath);
                //Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
                //    filePath, directoryName);
                //filePath = directoryName;
                //if (i == 1)
                //{
                //    filePath = directoryName + @"\";  // this will preserve the previous path
                //}
                //i++;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
