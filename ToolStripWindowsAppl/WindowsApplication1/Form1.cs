using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            //backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            //backgroundWorker1.RunWorkerAsync();
        }

        /*void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i * 100 / 20);
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }*/

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

      }
}