using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INZINITYFILEPUMPER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Pumpexemb(decimal size, string path)
        {
            //Open the file stream
            FileStream file = File.OpenWrite(path);
            //get the end of the exe file
            long ende = file.Seek(0, SeekOrigin.End);
            //1mb = 1048576bytes, so to convert the mbyte into bytes
            decimal groesse = size * 1048576;
            //The end of the file must be lower than the size you want to pump
            while (ende < groesse)
            {
                ende++;
                //here we write null bytes at the end of the file
                file.WriteByte(0);
            }
            //Close stream
            file.Close();
        }
        void Pumpexekb(decimal size, string path)
        {
            //Open the file stream
            FileStream file = File.OpenWrite(path);
            //get the end of the exe file
            long ende = file.Seek(0, SeekOrigin.End);
            //1mb = 1048576bytes, so to convert the mbyte into bytes
            decimal groesse = size * 1048;
            //The end of the file must be lower than the size you want to pump
            while (ende < groesse)
            {
                ende++;
                //here we write null bytes at the end of the file
                file.WriteByte(0);
            }
            //Close stream
            file.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked)
            {
                bunifuCheckbox1.Checked = false;
            }
            else
            {
                if (bunifuCheckbox1.Checked == false)
                {
                    this.Size = new Size(212, 80);

                }
                else
                {
                    this.Size = new Size(212, 115);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(bunifuCheckbox1.Checked)
            {
                openFileDialog1.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Pumpexemb(numericUpDown1.Value, openFileDialog1.FileName);
                }
            }
            else
            {
                if(bunifuCheckbox2.Checked)
                {
                    openFileDialog1.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;
                    DialogResult result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Pumpexekb(numericUpDown1.Value, openFileDialog1.FileName);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                bunifuCheckbox2.Checked = false;
            }
            else
            {
                if (bunifuCheckbox2.Checked == false)
                {
                    this.Size = new Size(212, 80);

                }
                else
                {
                    this.Size = new Size(212, 115);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(212, 80);
            MessageBox.Show("FILE PUMP FOR INZINITY");
        }
    }
}
