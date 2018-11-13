using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGroup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void salva()
        {


        }
        private void indenta()
        {

        }
        private void Apri()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\studente\\Desktop";
                openFileDialog.Filter = "Text files (*.txt)|*.txt";

                int size = -1;
                DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    
                    
                    try
                    {

                        richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Apri();
        }

        private void salvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            salva();
        }

        private void indentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indenta();
        }
    }
}
