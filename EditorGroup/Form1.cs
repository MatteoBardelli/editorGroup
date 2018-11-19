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
        string filename = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void salva()
        {
            if(filename != null)
            {
                File.WriteAllText(filename, richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Selezionare un file");
            }

        }
        private void indenta()
        {
            int tab = 0;
            string row = null;
            string IndentText = null;
            StreamReader lineCheck = new StreamReader(filename);

            while ((row = lineCheck.ReadLine()) != null)
            {

                if (row.Contains("{")) //tabulation edit for open parenthesis
                {
                        for (int i = 0; i < tab; i++)
                        {
                            IndentText = IndentText + " ";
                        }

                    tab += 4; //edits the current position counter (inside the parenthesis)
                    IndentText = IndentText + row.Trim() + "\r\n";
                }

                else if (row.Contains("}")) //tabulation edit for closed parenthesis
                {
                    tab -= 4; //edits the current position counter (outside of the parenthesis)

                    for (int i = 0; i < tab; i++)
                    {
                        IndentText = IndentText + " ";
                    }

                    IndentText = IndentText + row.Trim() + "\r\n";
                }

                else  //tabulation edit outside of parenthesis 
                {

                    for (int i = 0; i < tab; i++)
                    {
                        IndentText = IndentText + " ";
                    }

                    IndentText = IndentText + row.Trim() + "\r\n";
                }

                if (tab < 0)
                {
                    tab = 0; //resets tabulation
                }
            }

            lineCheck.Close();
            richTextBox1.Text = IndentText;
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
                        filename = openFileDialog.FileName;
                        richTextBox1.Text = File.ReadAllText(filename);
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            if (indentaToolStripMenuItem.Checked == true)
            {
                indenta();
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
    }
}
