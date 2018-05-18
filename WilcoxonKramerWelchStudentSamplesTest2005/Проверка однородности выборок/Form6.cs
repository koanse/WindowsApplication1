using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Проверка_однородности_выборок
{
    public partial class Form6 : Form
    {
        Criterions criterions;
        public Form6(Criterions cr)
        {
            InitializeComponent();
            criterions = cr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float x = float.Parse(textBox1.Text);
                textBox2.Text = criterions.NormalDistribution(x).ToString();
            }
            catch
            {
                MessageBox.Show("Ошибка расчета", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}