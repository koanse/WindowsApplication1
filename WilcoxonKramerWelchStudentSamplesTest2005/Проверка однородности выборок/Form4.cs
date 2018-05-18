using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Проверка_однородности_выборок
{
    public partial class Form4 : Form
    {
        public Form4(float criterion, float leftBound, float rightBound, bool result)
        {
            InitializeComponent();
            textBox1.Text = criterion.ToString();
            textBox2.Text = leftBound.ToString();
            textBox3.Text = rightBound.ToString();
            if (result) textBox4.Text = "Выборки однородны";
            else textBox4.Text = "Выборки не однородны";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}