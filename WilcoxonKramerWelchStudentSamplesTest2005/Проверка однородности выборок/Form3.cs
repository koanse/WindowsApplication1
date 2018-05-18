using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Проверка_однородности_выборок
{
    public partial class Form3 : Form
    {
        public Form3(string[] criticalAreaType)
        {
            InitializeComponent();
            comboBox1.Items.AddRange(criticalAreaType);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}