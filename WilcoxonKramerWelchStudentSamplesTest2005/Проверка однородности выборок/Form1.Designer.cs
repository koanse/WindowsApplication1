namespace Проверка_однородности_выборок
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базуДанныхMSAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.проToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверкаОднородностиВыборокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерийВилкоксонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерийАнсариБредлиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.проToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(630, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базуДанныхMSAccessToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.открытьToolStripMenuItem.Text = "Открыть ";
            // 
            // базуДанныхMSAccessToolStripMenuItem
            // 
            this.базуДанныхMSAccessToolStripMenuItem.Name = "базуДанныхMSAccessToolStripMenuItem";
            this.базуДанныхMSAccessToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.базуДанныхMSAccessToolStripMenuItem.Text = "База данных MS Access...";
            this.базуДанныхMSAccessToolStripMenuItem.Click += new System.EventHandler(this.базуДанныхMSAccessToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(630, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(606, 351);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripComboBox2,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStripComboBox3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(630, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Таблица";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(91, 22);
            this.toolStripLabel2.Text = "Первая выборка";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel3.Text = "Вторая выборка";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(121, 25);
            // 
            // проToolStripMenuItem
            // 
            this.проToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проверкаОднородностиВыборокToolStripMenuItem,
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem,
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem});
            this.проToolStripMenuItem.Name = "проToolStripMenuItem";
            this.проToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.проToolStripMenuItem.Text = "Вычисления";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // проверкаОднородностиВыборокToolStripMenuItem
            // 
            this.проверкаОднородностиВыборокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.критерийАнсариБредлиToolStripMenuItem,
            this.критерийВилкоксонаToolStripMenuItem,
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem,
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem});
            this.проверкаОднородностиВыборокToolStripMenuItem.Name = "проверкаОднородностиВыборокToolStripMenuItem";
            this.проверкаОднородностиВыборокToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.проверкаОднородностиВыборокToolStripMenuItem.Text = "Проверка однородности выборок";
            // 
            // критерийРандомизацииКомпонентФишераToolStripMenuItem
            // 
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem.Name = "критерийРандомизацииКомпонентФишераToolStripMenuItem";
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem.Text = "Критерий рандомизации компонент Фишера...";
            this.критерийРандомизацииКомпонентФишераToolStripMenuItem.Click += new System.EventHandler(this.критерийРандомизацииКомпонентФишераToolStripMenuItem_Click);
            // 
            // критерийВилкоксонаToolStripMenuItem
            // 
            this.критерийВилкоксонаToolStripMenuItem.Name = "критерийВилкоксонаToolStripMenuItem";
            this.критерийВилкоксонаToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.критерийВилкоксонаToolStripMenuItem.Text = "Критерий Вилкоксона...";
            this.критерийВилкоксонаToolStripMenuItem.Click += new System.EventHandler(this.критерийВилкоксонаToolStripMenuItem_Click);
            // 
            // критерийОснованныйНаЗнакахРазностейToolStripMenuItem
            // 
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem.Name = "критерийОснованныйНаЗнакахРазностейToolStripMenuItem";
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem.Text = "Критерий, основанный на знаках разностей...";
            this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem.Click += new System.EventHandler(this.критерийОснованныйНаЗнакахРазностейToolStripMenuItem_Click);
            // 
            // критерийАнсариБредлиToolStripMenuItem
            // 
            this.критерийАнсариБредлиToolStripMenuItem.Name = "критерийАнсариБредлиToolStripMenuItem";
            this.критерийАнсариБредлиToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.критерийАнсариБредлиToolStripMenuItem.Text = "Критерий Ансари-Брэдли...";
            this.критерийАнсариБредлиToolStripMenuItem.Click += new System.EventHandler(this.критерийАнсариБредлиToolStripMenuItem_Click);
            // 
            // критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem
            // 
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem.Name = "критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem";
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem.Text = "Распределение Стьюдента...";
            this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem.Click += new System.EventHandler(this.критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem_Click);
            // 
            // значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem
            // 
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem.Name = "значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem";
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem.Text = "Стандартное нормальное распределение...";
            this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem.Click += new System.EventHandler(this.значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 428);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка однородности выборок";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базуДанныхMSAccessToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
        private System.Windows.Forms.ToolStripMenuItem проToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверкаОднородностиВыборокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерийАнсариБредлиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерийВилкоксонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерийРандомизацииКомпонентФишераToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерийОснованныйНаЗнакахРазностейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критическиеТочкиРаспределенияСтбюдентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem значенияИнтегральнойФункцииСтандартногоНормальногоРаспределенияToolStripMenuItem;
    }
}

