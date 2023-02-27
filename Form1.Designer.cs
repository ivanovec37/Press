namespace Press
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Name_PUBL_ComboBox = new System.Windows.Forms.ComboBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Sale_DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.Circulation_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Price_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.Demand_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Country_ComboBox = new System.Windows.Forms.ComboBox();
            this.Type_Press_ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Product_Name_TextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Print_Select_Button = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Circulation_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Demand_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1211, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Name_PUBL_ComboBox);
            this.tabPage1.Controls.Add(this.Save_Button);
            this.tabPage1.Controls.Add(this.Add_Button);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.Sale_DateTimePicker1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.Circulation_NumericUpDown);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Price_NumericUpDown);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.Demand_NumericUpDown);
            this.tabPage1.Controls.Add(this.Country_ComboBox);
            this.tabPage1.Controls.Add(this.Type_Press_ComboBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Product_Name_TextBox);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1203, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основная таблица";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Name_PUBL_ComboBox
            // 
            this.Name_PUBL_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Name_PUBL_ComboBox.FormattingEnabled = true;
            this.Name_PUBL_ComboBox.Location = new System.Drawing.Point(199, 337);
            this.Name_PUBL_ComboBox.Name = "Name_PUBL_ComboBox";
            this.Name_PUBL_ComboBox.Size = new System.Drawing.Size(150, 24);
            this.Name_PUBL_ComboBox.TabIndex = 21;
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(1071, 282);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(115, 23);
            this.Save_Button.TabIndex = 20;
            this.Save_Button.Text = "Сохранить";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(578, 439);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(115, 23);
            this.Add_Button.TabIndex = 19;
            this.Add_Button.Text = "Добавить ";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(537, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "Дата продажи";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Sale_DateTimePicker1
            // 
            this.Sale_DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Sale_DateTimePicker1.Location = new System.Drawing.Point(537, 411);
            this.Sale_DateTimePicker1.Name = "Sale_DateTimePicker1";
            this.Sale_DateTimePicker1.Size = new System.Drawing.Size(156, 22);
            this.Sale_DateTimePicker1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(30, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Тираж";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Circulation_NumericUpDown
            // 
            this.Circulation_NumericUpDown.Location = new System.Drawing.Point(30, 411);
            this.Circulation_NumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Circulation_NumericUpDown.Name = "Circulation_NumericUpDown";
            this.Circulation_NumericUpDown.Size = new System.Drawing.Size(150, 22);
            this.Circulation_NumericUpDown.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(368, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Цена";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Price_NumericUpDown
            // 
            this.Price_NumericUpDown.DecimalPlaces = 2;
            this.Price_NumericUpDown.Location = new System.Drawing.Point(368, 409);
            this.Price_NumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Price_NumericUpDown.Name = "Price_NumericUpDown";
            this.Price_NumericUpDown.Size = new System.Drawing.Size(150, 22);
            this.Price_NumericUpDown.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(201, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Спрос";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Demand_NumericUpDown
            // 
            this.Demand_NumericUpDown.Location = new System.Drawing.Point(199, 411);
            this.Demand_NumericUpDown.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Demand_NumericUpDown.Name = "Demand_NumericUpDown";
            this.Demand_NumericUpDown.Size = new System.Drawing.Size(150, 22);
            this.Demand_NumericUpDown.TabIndex = 11;
            // 
            // Country_ComboBox
            // 
            this.Country_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Country_ComboBox.FormattingEnabled = true;
            this.Country_ComboBox.Location = new System.Drawing.Point(537, 335);
            this.Country_ComboBox.Name = "Country_ComboBox";
            this.Country_ComboBox.Size = new System.Drawing.Size(150, 24);
            this.Country_ComboBox.TabIndex = 10;
            // 
            // Type_Press_ComboBox
            // 
            this.Type_Press_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type_Press_ComboBox.FormattingEnabled = true;
            this.Type_Press_ComboBox.Location = new System.Drawing.Point(368, 333);
            this.Type_Press_ComboBox.Name = "Type_Press_ComboBox";
            this.Type_Press_ComboBox.Size = new System.Drawing.Size(150, 24);
            this.Type_Press_ComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(537, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Страна";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(368, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тип прессы";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(201, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Издательство";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(30, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название прессы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Product_Name_TextBox
            // 
            this.Product_Name_TextBox.Location = new System.Drawing.Point(30, 335);
            this.Product_Name_TextBox.Multiline = true;
            this.Product_Name_TextBox.Name = "Product_Name_TextBox";
            this.Product_Name_TextBox.Size = new System.Drawing.Size(150, 20);
            this.Product_Name_TextBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1164, 263);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Print_Select_Button);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1203, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Запросы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Print_Select_Button
            // 
            this.Print_Select_Button.BackColor = System.Drawing.Color.ForestGreen;
            this.Print_Select_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Print_Select_Button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Print_Select_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Print_Select_Button.Location = new System.Drawing.Point(783, 11);
            this.Print_Select_Button.Name = "Print_Select_Button";
            this.Print_Select_Button.Size = new System.Drawing.Size(223, 23);
            this.Print_Select_Button.TabIndex = 3;
            this.Print_Select_Button.Text = "Вывести запрос";
            this.Print_Select_Button.UseVisualStyleBackColor = false;
            this.Print_Select_Button.Click += new System.EventHandler(this.Print_Select_Button_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 156);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(943, 345);
            this.dataGridView2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(756, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 554);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Circulation_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Price_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Demand_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Demand_NumericUpDown;
        private System.Windows.Forms.ComboBox Country_ComboBox;
        private System.Windows.Forms.ComboBox Type_Press_ComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Product_Name_TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Circulation_NumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Price_NumericUpDown;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker Sale_DateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox Name_PUBL_ComboBox;
        private System.Windows.Forms.Button Print_Select_Button;
    }
}

