using System;
using System.IO;
using System.Windows.Forms;

namespace MyNotepad
{
    public partial class Notepad : Form
    {
        public string[] OpenedFile;
        public string[] SavedFile;
        
        public Notepad()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTextFile.Filter = "Text files (*.txt)|*.txt";
            DialogResult result = OpenTextFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                OpenedFile = File.ReadAllLines(OpenTextFile.FileName);
                foreach (string lines in OpenedFile)
                {
                    rctxbx_MainText.Text += $"{lines}\n";
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(OpenTextFile.FileName, rctxbx_MainText.Text);
            MessageBox.Show("Saved");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            switch (MessageBox.Show("Do you want to save your changes?",
         "Exit",
         MessageBoxButtons.YesNoCancel,
         MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // "OK" processing
                    saveToolStripMenuItem.PerformClick();
                    this.Close();
                    this.Dispose();
                    break;
                case DialogResult.No:
                    this.Close();
                    this.Dispose();
                    break;
               
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs.Filter = "Text files (*.txt)|*.txt";
            DialogResult result = SaveAs.ShowDialog();
            if (result == DialogResult.OK)
            {

                if (!File.Exists(SaveAs.FileName))
                {
                    using (File.Create($"{SaveAs.FileName}"));
                }
                using (StreamWriter sr = new StreamWriter(SaveAs.FileName))
                    foreach (string lines in rctxbx_MainText.Lines)
                {
                        sr.WriteLine(lines);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
