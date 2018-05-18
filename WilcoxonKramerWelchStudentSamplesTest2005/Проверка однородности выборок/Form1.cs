using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Проверка_однородности_выборок
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void базуДанныхMSAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                        openFileDialog1.FileName + "\"");
                    connection.Open();
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    toolStripComboBox1.Items.Clear();
                    dataSet1.Clear();
                    foreach(DataRow r in dt.Rows)
                    {
                        if (r["TABLE_TYPE"].ToString() == "TABLE")
                        {
                            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " +
                                r["TABLE_NAME"].ToString(), connection);
                            da.Fill(dataSet1, r["TABLE_NAME"].ToString());
                            toolStripComboBox1.Items.Add(r["TABLE_NAME"].ToString());
                        }
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия базы данных MS Access", "Ошибка открытия файла");
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dataSet1.Tables[toolStripComboBox1.Text];
                toolStripComboBox2.Items.Clear();
                toolStripComboBox3.Items.Clear();
                foreach(DataColumn c in dataSet1.Tables[toolStripComboBox1.Text].Columns)
                    toolStripComboBox2.Items.Add(c.ColumnName);
                toolStripComboBox2.SelectedIndex = 0;
                foreach (DataColumn c in dataSet1.Tables[toolStripComboBox1.Text].Columns)
                    toolStripComboBox3.Items.Add(c.ColumnName);
                toolStripComboBox3.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Ошибка при выборе таблицы", "Ошибка представления данных");
            }
        }

        private void критерийАнсариБредлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBox2.Text == toolStripComboBox3.Text)
                    throw new Exception("Необходимо взять разные выборки");
                Form2 form2 = new Form2(new string[] {"0,10", "0,05", "0,02", "0,01", "0,002", "0,001"});
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    ArrayList xal = new ArrayList(), yal = new ArrayList();
                    float alpha = float.Parse(form2.comboBox1.Text);
                    foreach (DataRow r in dataSet1.Tables[toolStripComboBox1.Text].Rows)
                    {
                        //float tmp1 = (float)(int)r[toolStripComboBox2.Text], tmp2 = (float)(int)r[toolStripComboBox3.Text];
                        TypeConverter tc = new TypeConverter();
                        float tmp1 = (float)r[toolStripComboBox2.Text];
                        float tmp2 = (float)r[toolStripComboBox3.Text];
                        int i = 5;
                        object o;// = i;
                        o = 15;

                        //tmp2 = (float)(int)r[toolStripComboBox3.Text];
                        xal.Add(tmp1);
                        yal.Add(tmp2);
                    }
                    float[] x = (float[])xal.ToArray(typeof(float));
                    float[] y = (float[])yal.ToArray(typeof(float));
                    Criterions c = new Criterions(x, y, alpha);
                    c.A();
                    Form4 form4 = new Form4(c.criterion, c.leftBound, c.rightBound, c.result);
                    form4.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка расчета критерия", "Критерий Ансари-Брэдли");
            }
        }

        private void критерийВилкоксонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBox2.Text == toolStripComboBox3.Text)
                    throw new Exception("Необходимо взять разные выборки");
                Form2 form2 = new Form2(new string[] { "0,10", "0,05", "0,02", "0,01", "0,002", "0,001" });
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Form3 form3 = new Form3(new string[] { "Левосторонняя", "Правосторонняя", "Двусторонняя" });
                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        ArrayList xal = new ArrayList(), yal = new ArrayList();
                        float alpha = float.Parse(form2.comboBox1.Text);
                        CriticalAreaType ca = CriticalAreaType.DoubleSided;
                        if (form3.comboBox1.Text == "Левосторонняя") ca = CriticalAreaType.OneSidedLeft;
                        if (form3.comboBox1.Text == "Правосторонняя") ca = CriticalAreaType.OneSidedRight;
                        if (form3.comboBox1.Text == "Двусторонняя") ca = CriticalAreaType.DoubleSided;
                        foreach (DataRow r in dataSet1.Tables[toolStripComboBox1.Text].Rows)
                        {
                            xal.Add((float)(int)r[toolStripComboBox2.Text]);
                            yal.Add((float)(int)r[toolStripComboBox3.Text]);
                        }
                        float[] x = (float[])xal.ToArray(typeof(float));
                        float[] y = (float[])yal.ToArray(typeof(float));
                        Criterions c = new Criterions(x, y, alpha);
                        c.W(ca, 1000);
                        Form4 form4 = new Form4(c.criterion, c.leftBound, c.rightBound, c.result);
                        form4.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка расчета критерия", "Критерий Вилкоксона");
            }
        }

        private void критерийРандомизацииКомпонентФишераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (toolStripComboBox2.Text == toolStripComboBox3.Text)
                    throw new Exception("Необходимо взять разные выборки");
                Form2 form2 = new Form2(new string[] { "0,10", "0,05", "0,02", "0,01", "0,002", "0,001" });
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Form3 form3 = new Form3(new string[] { "Левосторонняя", "Правосторонняя", "Двусторонняя" });
                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        ArrayList xal = new ArrayList(), yal = new ArrayList();
                        float alpha = float.Parse(form2.comboBox1.Text);
                        foreach (DataRow r in dataSet1.Tables[toolStripComboBox1.Text].Rows)
                        {
                            if(r[toolStripComboBox2.Text].GetType() == typeof(int))
                                xal.Add((float)(int)r[toolStripComboBox2.Text]);
                            if (r[toolStripComboBox2.Text].GetType() == typeof(float))
                                xal.Add((float)r[toolStripComboBox2.Text]);

                            if (r[toolStripComboBox3.Text].GetType() == typeof(int))
                                yal.Add((float)(int)r[toolStripComboBox3.Text]);
                            if (r[toolStripComboBox3.Text].GetType() == typeof(float))
                                yal.Add((float)r[toolStripComboBox3.Text]);
                        }
                        float[] x = (float[])xal.ToArray(typeof(float));
                        float[] y = (float[])yal.ToArray(typeof(float));
                        
                        CriticalAreaType ca = CriticalAreaType.DoubleSided;
                        Criterions c = new Criterions(x, y, alpha);
                        if (form3.comboBox1.Text == "Левосторонняя") ca = CriticalAreaType.OneSidedLeft;
                        if (form3.comboBox1.Text == "Правосторонняя") ca = CriticalAreaType.OneSidedRight;
                        if (form3.comboBox1.Text == "Двусторонняя") ca = CriticalAreaType.DoubleSided;
                        c.F(ca);
                        Form4 form4 = new Form4(c.criterion, c.leftBound, c.rightBound, c.result);
                        form4.ShowDialog();
                    }
                }
            //}
            //catch
            //{
              //  MessageBox.Show("Ошибка расчета критерия", "Критерий Фишера");
            //}
        }

        private void критерийОснованныйНаЗнакахРазностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBox2.Text == toolStripComboBox3.Text)
                    throw new Exception("Необходимо взять разные выборки");
                Form2 form2 = new Form2(new string[] { "0,10", "0,05", "0,02", "0,01", "0,002", "0,001" });
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    ArrayList xal = new ArrayList(), yal = new ArrayList();
                    float alpha = float.Parse(form2.comboBox1.Text);
                    foreach (DataRow r in dataSet1.Tables[toolStripComboBox1.Text].Rows)
                    {
                        xal.Add((float)(int)r[toolStripComboBox2.Text]);
                        yal.Add((float)(int)r[toolStripComboBox3.Text]);
                    }
                    float[] x = (float[])xal.ToArray(typeof(float));
                    float[] y = (float[])yal.ToArray(typeof(float));
                    Criterions c = new Criterions(x, y, alpha);
                    c.Q();
                    Form4 form4 = new Form4(c.criterion, c.leftBound, c.rightBound, c.result);
                    form4.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка расчета критерия", "Критерий знаков разностей");
            }
        }

        private void критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Criterions c = new Criterions();
                Form5 form5 = new Form5(c, new string[] { "0,10", "0,05", "0,02", "0,01", "0,002", "0,001" });
                form5.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка вычисления", "Ошибка");
            }
        }

        private void значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Criterions c = new Criterions();
                Form6 form6 = new Form6(c);
                form6.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка расчета", "Ошибка");
            }
        }


    }
}