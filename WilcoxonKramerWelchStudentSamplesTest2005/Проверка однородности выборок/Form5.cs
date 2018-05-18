using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Проверка_однородности_выборок
{
    public partial class Form5 : Form
    {
        Criterions criterions;
        public Form5(Criterions cr, string[] alphaValues)
        {
            InitializeComponent();
            criterions = cr;
            comboBox1.Items.AddRange(alphaValues);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(textBox1.Text);
                float alpha = float.Parse(comboBox1.Text);
                float res = criterions.StudentDistribution(n, alpha);
                textBox2.Text = res.ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка вычисления", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}