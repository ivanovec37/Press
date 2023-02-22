using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = MSI\SQLEXPRESS;Initial Catalog = Press;Integrated Security = true;");
        SqlDataAdapter adapter;
        SqlCommand command;
        DataSet ds = new DataSet();
        Dictionary<string, int> Name_PUBL = new Dictionary<string, int>();
        Dictionary<string, int> Type_Press = new Dictionary<string, int>();
        Dictionary<string, int> Country = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, Control>> selectControls = new Dictionary<string, Dictionary<string, Control>>();
        List<string> queryNames = new List<string>();

        public Form1()
        {
            InitializeComponent();
            FillComboBoxes();
            FillQueryNames();
            FillControls();
            comboBox1.SelectedIndex = 0;
            Name_PUBL_ComboBox.SelectedIndex = 0;
            Type_Press_ComboBox.SelectedIndex = 0;
            Country_ComboBox.SelectedIndex = 0;

            dataGridView1.DataError += (object sender, DataGridViewDataErrorEventArgs anError) =>
            {
                MessageBox.Show("Некорректный формат данных!");
                ShowTable();
            };
            ShowTable();
        }
        private void FillQueryNames()
        {
            queryNames.Add("Вывести список прессы отсортированный по наименованию");//Готово 0
            queryNames.Add("Вывести список прессы отсортированный по тиражу");//готово 1
            queryNames.Add("Вывести список прессы отсортированный по стоимости");//готово 2
            queryNames.Add("Вывести самое дорогое, дешевое, срендняя стоимость для каждого вида прессы");//готово 3
            queryNames.Add("Вывести прессу с ценой выше заданной");//готово 4
            queryNames.Add("Вывести все издания, чей тираж находится в заданных пределах");//готово 5
            queryNames.Add("Вывести все виды газетной продукции для заданного издательства");//готово 6 
            queryNames.Add("Вывести все издания, чья стоимость находится в заданных пределах");//
            queryNames.Add("Вывести долю прессы от общего числа изданий");//
            queryNames.Add("Вывести долю прессы проданной за определённый период");//готово 9
            queryNames.Add("Вывести все виды прессы со стоимостью больше заданной");//готово 10
            queryNames.Add("Вывести всю прессу, чья стоимость выше средней стоимости по стране");//готово11
            queryNames.Add("Вывести долю дешевой прессы, поступившей от заданного издательства");//       12
            queryNames.Add("Вывести среднюю стоимость прессы, проданной за определённый промежуток времени");// готово 13
            queryNames.Add("Вывести всю прессу, чья стоимость выше средней стоимости прессы заданного издательства");//готово 14
            queryNames.Add("Вывести прессу которую чаще всего покупают");//готово 15
            foreach (string name in queryNames)
            {
                comboBox1.Items.Add(name);
            }
        }


        private void FillComboBoxes()
        {
            DataSet dataSet = new DataSet();
            adapter = new SqlDataAdapter("select Publishing.Name_PUBL ,Publishing.Id from Publishing;", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Name_PUBL[row.ItemArray[0].ToString()] = (int)row.ItemArray[1];

            }
            foreach (var name in Name_PUBL.Keys)
            {
                Name_PUBL_ComboBox.Items.Add(name);
            }

            dataSet = new DataSet();
            adapter = new SqlDataAdapter(" select Type.Name_TP,Type.Id from Type;", connection);
            builder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Type_Press[row.ItemArray[0].ToString()] = (int)row.ItemArray[1];

            }
            foreach (var name in Type_Press.Keys)
            {
                Type_Press_ComboBox.Items.Add(name);
            }

            dataSet = new DataSet();
            adapter = new SqlDataAdapter(" select Country.Name_CNTR,Country.Id from Country;", connection);
            builder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Country[row.ItemArray[0].ToString()] = (int)row.ItemArray[1];

            }
            foreach (var name in Country.Keys)
            {
                Country_ComboBox.Items.Add(name);
            }



        }

        private void FillControls()
        {
            /* 1 комбобокс - тип прессы ГОТОВО
               2 комбобокс - тип прессы ГОТОВО
               3 комбобокс - тип прессы ГОТОВО
               4 комбобокс - тип прессы ГОТОВО
               5 нумерик - цена комбобоксc с издательством
               6  два нумерика для ввода интервала тиража
               7 комбобокс с издатель
               8 два нумерика для интервала стоимости + комбобокс для издательства
               9 нумерик для ограничения цены 
              10 два датапикера для интервала
              11 комбобокс для издательства и нумерик для стоимости
              12 комбобокс для издательства текстбокс для прессы комбобокс для страны
              13 нумерик для стоимости комбобокс для издательства
              14  два датапикера для интервала
              15 комбобокс для издательства
              16 нумерик цена комбобокс издательство
             */

            selectControls[queryNames[0]] = new Dictionary<string, Control>();
            ComboBox comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Type_Press.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(20, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[0]]["comboBox1"] = comboBox;

            Label label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.Text = "Тип прессы";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[0]]["label1"] = label;

            selectControls[queryNames[1]] = new Dictionary<string, Control>();
            selectControls[queryNames[1]]["comboBox1"] = comboBox;
            selectControls[queryNames[1]]["label1"] = label;

            selectControls[queryNames[2]] = new Dictionary<string, Control>();
            selectControls[queryNames[2]]["comboBox1"] = comboBox;
            selectControls[queryNames[2]]["label1"] = label;

            selectControls[queryNames[3]] = new Dictionary<string, Control>();
            selectControls[queryNames[3]]["comboBox1"] = comboBox;
            selectControls[queryNames[3]]["label1"] = label;
            // 5 нумерик - цена комбобокс
            selectControls[queryNames[4]] = new Dictionary<string, Control>();
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[4]]["numericUpDown1"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.Text = "Цена";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[4]]["labal1"] = label;

            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(160, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[4]]["comboBox1"] = comboBox;

            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[4]]["labal2"] = label;

            //6 два нумерика для ввода интервала тиража

            selectControls[queryNames[5]] = new Dictionary<string, Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[5]]["numericUpDown1"] = numericUpDown;

            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 94);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[5]]["numericUpDown2"] = numericUpDown;
            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[5]]["labal1"] = label;

            //7 комбобокс с издатель
            selectControls[queryNames[6]] = new Dictionary<string, Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(20, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[6]]["comboBox1"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[6]]["labal1"] = label;

            // 8 два нумерика для интервала стоимости + комбобокс для издательства
            selectControls[queryNames[7]] = new Dictionary<string, Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[7]]["numericUpDown1"] = numericUpDown;

            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 94);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[7]]["numericUpDown2"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала стоимости";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[7]]["label1"] = label;

            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(160, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[7]]["comboBox1"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[7]]["label2"] = label;

            //9 нумерик для ограничения цены
            selectControls[queryNames[8]] = new Dictionary<string, Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[8]]["numericUpDown1"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Ввод ограничения цены";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[8]]["label1"] = label;


            //10 - два датапикера для интервала
            selectControls[queryNames[9]] = new Dictionary<string, Control>();
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(20, 64);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[queryNames[9]]["dateTimePicker1"] = dateTimePicker;

            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(20, 94);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[queryNames[9]]["dateTimePicker2"] = dateTimePicker;


            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[9]]["label1"] = label;

            // 11 комбобокс для издательства и нумерик для стоимости
            selectControls[queryNames[10]] = new Dictionary<string, Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(20, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[10]]["comboBox1"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[10]]["label1"] = label;

            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(160, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[10]]["numericUpDown1"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[10]]["label2"] = label;

            //12 комбобокс для издательства текстбокс для прессы комбобокс для страны

            selectControls[queryNames[11]] = new Dictionary<string, Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(20, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[11]]["comboBox1"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[11]]["label1"] = label;
            //comboBox country
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Country.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(160, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[11]]["comboBox2"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Выбор страны";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[11]]["label2"] = label;
            //textbox для ввода прессы
            TextBox textBox = new TextBox();
            this.tabPage2.Controls.Add(textBox);
            textBox.Visible = false;
            textBox.Location = new System.Drawing.Point(300, 64);
            textBox.Multiline = true;
            textBox.Size = new System.Drawing.Size(150, 20);
            selectControls[queryNames[11]]["textBox1"] = textBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(300, 44);
            label.AutoSize = true;
            label.Text = "Выбор прессы";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[11]]["label3"] = label;

            // 13 нумерик для стоимости комбобокс для издательства
            selectControls[queryNames[12]] = new Dictionary<string, Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[12]]["numericUpDown1"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[12]]["label1"] = label;


            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(160, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[12]]["comboBox1"] = comboBox;
            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[12]]["label2"] = label;


            //14 - два датапикера для интервала
            selectControls[queryNames[13]] = new Dictionary<string, Control>();
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(20, 64);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[queryNames[13]]["dateTimePicker1"] = dateTimePicker;

            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(20, 94);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[queryNames[13]]["dateTimePicker2"] = dateTimePicker;


            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[13]]["label1"] = label;


            // 15 комбобокс для издательства
            selectControls[queryNames[14]] = new Dictionary<string, Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(20, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[14]]["comboBox1"] = comboBox;

            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[14]]["label1"] = label;


            //16 нумерик цена комбобокс издательство
            selectControls[queryNames[15]] = new Dictionary<string, Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[queryNames[15]]["numericUpDown1"] = numericUpDown;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[15]]["label1"] = label;

            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(160, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[queryNames[15]]["comboBox1"] = comboBox;

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(160, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[queryNames[15]]["label2"] = label;

        }

        private void QueryCase()
        {
            DataSet dataSet = new DataSet();
            var item = queryNames.Count;
            for (int i = 0; i < item; i++)
            {
                if (i == 0)//по имени
                {
                    adapter = new SqlDataAdapter($" select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи',Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна' " +
                        $" from Products" +
                        $" inner join Publishing on Publishing.ID = Products.Publishing_FK" +
                        $" inner join Type on Type.ID = Products.Type_FK" +
                        $" inner join Country on Country.Id = Products.Country_FKwhere Type.Name_TP = 'Книга'" +
                        $" order by Name; ", connection);

                }
                if (i == 1)//по тиражу
                {
                    adapter = new SqlDataAdapter($"select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи',Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна' " +
                        " from Products" +
                        "inner join Publishing on Publishing.ID = Products.Publishing_FK" +
                        "inner join Type on Type.ID = Products.Type_FK" +
                        "inner join Country on Country.Id = Products.Country_FK" +
                        "where Type.Name_TP = 'Книга'" +
                        "order by Circulation;", connection);
                }
                if (i == 2)//по стоимости
                {
                    adapter = new SqlDataAdapter($"select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи',Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна'" +
                        $"  from Products" +
                        $"inner join Publishing on Publishing.ID = Products.Publishing_FK" +
                        $"inner join Type on Type.ID = Products.Type_FK" +
                        $"inner join Country on Country.Id = Products.Country_FK" +
                        $"where Type.Name_TP = 'Книга'" +
                        $"order by Price ;", connection);
                }
                if (i == 3)//Вывести самое дорогое.  для каждого вида прессы
                {
                    adapter = new SqlDataAdapter($"select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи',Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна'" +
                        $"  from Products" +
                        $"inner join Publishing on Publishing.ID = Products.Publishing_FK" +
                        $"inner join Type on Type.ID = Products.Type_FK" +
                        $"inner join Country on Country.Id = Products.Country_FK" +
                        $"and Price = (select max (Price)" +
                        $"from Products);", connection);
                    //Самое дешевое
                    adapter = new SqlDataAdapter($"select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи',Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна'" +
                        $"  from Products" +
                        $"inner join Publishing on Publishing.ID = Products.Publishing_FK" +
                        $"inner join Type on Type.ID = Products.Type_FK" +
                        $"inner join Country on Country.Id = Products.Country_FK" +
                        $"and Price = (select min (Price)" +
                        $"from Products);", connection);
                    //срендняя стоимость  для каждого вида прессы (Журнал)
                    adapter = new SqlDataAdapter($"select AVG (Price) AS [Средняя цена Журналов]" +
                        $"from Products,Type" +
                        $"where Type_FK= Type.Id" +
                        $"and Name_TP = 'Журнал';", connection);
                    // Средняя стоимость  Книг
                    adapter = new SqlDataAdapter($"select AVG (Price) AS [Средняя цена Книг]" +
                        $"from Products,Type" +
                        $"where Type_FK= Type.Id" +
                        $"and Name_TP = 'Книга';", connection);
                    //Средняя стоимость Газет
                    adapter = new SqlDataAdapter($"select AVG (Price) AS [Средняя цена Газет]" +
                        $"from Products,Type" +
                        $"where Type_FK = Type.Id" +
                        $"and Name_TP = 'Газета';", connection);
                    //Средняя стоимость Словарей
                    adapter = new SqlDataAdapter($"select AVG (Price) AS [Средняя цена Словарей]" +
                        $"from Products,Type " +
                        $"where Type_FK = Type.Id" +
                        $"and Name_TP = 'Словарь';", connection);
                    //Средняя стоимость Буклетов
                    adapter = new SqlDataAdapter($"-select AVG (Price) AS [Средняя цена Буклетов]" +
                        $"from Products,Type " +
                        $"where Type_FK = Type.Id" +
                        $"and Name_TP = 'Буклет';", connection);
                    //Средняя стоимость
                    adapter = new SqlDataAdapter($"select AVG (Price) AS [Средняя цена ]" +
                        $"from Products;", connection);
                }
                if (i == 4)//Вывести прессу с ценой выше заданной   
                {
                    adapter = new SqlDataAdapter($"select [Name],Circulation,Price, [Date_of_Sale], Demand,Name_TP" +
                        " from Products,Type" +
                        " where Type_FK = Type.Id " +
                        $"and Price>{Price_NumericUpDown.Value};", connection); ;
                }
                if (i == 5)//Вывести все издания, чей тираж находится в заданных пределах
                {
                    adapter = new SqlDataAdapter("select  [Name],Circulation,Price, Date_of_Sale, Demand,Name_TP" +
                        " from Products,Type" +
                        "where Type_FK = Type.Id " +
                        $"and Circulation >{Circulation_NumericUpDown.Value} " +
                        $"and Circulation <{Circulation_NumericUpDown.Value};", connection);

                }
                if (i == 6)//Вывести все виды газетной продукции для заданного издательства
                {
                    adapter = new SqlDataAdapter($"select  [Name],Name_PUBL, Circulation,Price, Date_of_Sale, Demand,Name_TP" +
                        "from Products" +
                        "inner join Publishing on Products.Publishing_FK = Publishing.Id" +
                        "inner join Type on Products.Type_FK = Type.Id" +
                        $" and Name_TP ='{Type_Press_ComboBox.SelectedItem}' and Name_PUBL = '{Name_PUBL_ComboBox.SelectedItem}';", connection);
                }
                if (i == 7)//Вывести все издания, чья стоимость находится в заданных пределах
                {
                    adapter = new SqlDataAdapter(";", connection);
                }
                if (i == 8)//Вывести долю прессы от общего числа изданий
                {
                    adapter = new SqlDataAdapter(";", connection);
                }
                if (i == 9)//Вывести долю прессы проданной за определённый период
                {
                    // adapter = new SqlDataAdapter("select Count(t1.Id) / Count(t2.Id) as [Доля] " +
                    //    $"from (select * from Products where Date_of_Sale>='{dateTimePicker.Data}' and Date_of_Sale<='{dateTimePicker.Data}') t1," +
                    //    $" (select* from Products) t2;", connection);
                }
                if (i == 10)//Вывести все виды прессы со стоимостью больше заданной
                {
                    adapter = new SqlDataAdapter($"select  [Name],Circulation,Price, Date_of_Sale, Demand,Name_TP,Name_PUBL" +
                        $"from Products" +
                        $"inner join Type on Type_FK = TYPE.Id" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id" +
                        $"and Price > {Price_NumericUpDown.Value}" +
                        $"and Publishing.Name_PUBL='{Name_PUBL_ComboBox.SelectedItem}',", connection);
                }
                if (i == 11)//Вывести всю прессу, чья стоимость выше средней стоимости по стране
                {
                    adapter = new SqlDataAdapter($"select  [Name],Circulation,Price, Date_of_Sale, Demand,Name_TP,Name_PUBL" +
                        $"from Products" +
                        $"inner join Type on Type_FK = TYPE.Id" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id," +
                        $"(select avg(Price)as avg_price from Products" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id" +
                        $"where Name_PUBL = '{Name_PUBL_ComboBox.SelectedItem}') t1 " +
                        $"where Price > t1.avg_price;;", connection);
                }
                if (i == 12)//Вывести долю дешевой прессы, поступившей от заданного издательства"
                {
                    adapter = new SqlDataAdapter($";", connection);
                }
                if (i == 13)//Вывести среднюю стоимость прессы, проданной за определённый промежуток времени
                {
                    //adapter = new SqlDataAdapter($"select avg(Price)as [средняя стоимость]" +
                    //    $"from Products" +
                    // $"where Date_of_Sale BETWEEN ('{dateTimePicker1.Data}') AND ('{dateTimePicker2.Data}');", connection);
                }
                if (i == 14)//Вывести всю прессу, чья стоимость выше средней стоимости прессы заданного издательства
                {
                    adapter = new SqlDataAdapter($"select  [Name],Circulation,Price, Date_of_Sale, Demand,Name_TP,Name_PUBL" +
                        $"from Products" +
                        $"inner join Type on Type_FK = TYPE.Id" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id," +
                        $"(select avg(Price)as avg_price from Products" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id" +
                        $"where Name_PUBL = '{Name_PUBL_ComboBox.SelectedItem}') t1 " +
                        $"where Price > t1.avg_price;", connection);
                }
                if (i == 15)//Вывести прессу которую чаще всего покупают
                {
                    adapter = new SqlDataAdapter($"select  [Name] as'Название',Circulation as 'Тираж',Price as 'Цена',Date_of_Sale as'Дата продажи'," +
                        $"Demand as'Спрос',Name_PUBL as'Издательство',Name_CNTR as 'Страна'" +
                        $"from Products" +
                        $"inner join Type on Type_FK = TYPE.Id" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id" +
                        $"inner join Country on Country_FK = Country.Id" +
                        $"where Demand =  (select Max(Demand ) from Products" +
                        $"inner join Publishing on Publishing_FK = Publishing.Id" +
                        $"where Price >90 and Name_PUBL = '{Name_PUBL_ComboBox.SelectedItem}' );", connection);
                }
            }
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];





        }

        private void ShowTable()
        {
            try
            {
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].Rows.Clear();
                }

                adapter = new SqlDataAdapter("select Products.id as 'ID', [Name] as'Название'," +
                    "Circulation as 'Тираж'," +
                    "(select FORMAT( Price,'n2')) as 'Цена'," +
                    "Date_of_Sale as'Дата продажи'" +
                    ",Demand as'Спрос'," +
                    "Name_PUBL as'Издательство'," +
                    "Name_CNTR as 'Страна'," +
                    "Type.Name_TP as 'Тип' " +
                    " from Products  " +
                    " inner join Publishing on Publishing.ID = Products.Publishing_FK " +
                    " inner join Type on Type.ID = Products.Type_FK" +
                    " inner join Country on Country.Id = Products.Country_FK; ", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SaveUpdate()
        {
            try
            {
                string save = "update Products set [Name] = @pName,Circulation = @pCirculation,Price = @pPrice," +
                   "Date_of_Sale=@pDate_of_Sale,Demand = @pDemand where Products.ID = @pID;";

                command = new SqlCommand(save, connection);
                command.Parameters.Add(new SqlParameter("@pName", SqlDbType.NVarChar, Parameters.MAX_PRODUCTS_NAME_LENGTH));
                command.Parameters.Add(new SqlParameter("@pCirculation", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@pPrice", SqlDbType.Money));
                command.Parameters.Add(new SqlParameter("@pDate_of_Sale", SqlDbType.Date));
                command.Parameters.Add(new SqlParameter("@pDemand", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@pID", SqlDbType.Int));

                command.Parameters["@pName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pCirculation"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pPrice"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pDate_of_Sale"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pDemand"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@pID"].SourceVersion = DataRowVersion.Original;

                command.Parameters["@pName"].SourceColumn = "Название";
                command.Parameters["@pCirculation"].SourceColumn = "Тираж";
                command.Parameters["@pPrice"].SourceColumn = "Цена";
                command.Parameters["@pDate_of_Sale"].SourceColumn = "Дата продажи";
                command.Parameters["@pDemand"].SourceColumn = "Спрос";
                command.Parameters["@pID"].SourceColumn = "ID";

                adapter.UpdateCommand = command;
                adapter.Update(ds);
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].Rows.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Некорректный формат данных!");
                ShowTable();
            }
        }

        private void AddData()
        {
            if (Product_Name_TextBox.Text == "" || Name_PUBL_ComboBox.SelectedIndex == -1 ||
                Type_Press_ComboBox.SelectedIndex == -1 ||
                Country_ComboBox.SelectedIndex == -1 ||
                Circulation_NumericUpDown.Value < Parameters.MIN_CIRCULATION ||
                Demand_NumericUpDown.Value < Parameters.MIN_DEMOND ||
                Price_NumericUpDown.Value < Parameters.MIN_PRICE ||
                Product_Name_TextBox.Text.Length > Parameters.MAX_PRODUCTS_NAME_LENGTH ||
                Name_PUBL_ComboBox.SelectedIndex > Parameters.MAX_PUBLICHING_NAME_LENGTH)
            {
                MessageBox.Show("Некорректно заполнены данные");
                return;
            }


            connection.Open();
            command = new SqlCommand($"insert into [dbo].[Products]" +
                $"values" +
                $" ('{Product_Name_TextBox.Text}'," +
                $"{Circulation_NumericUpDown.Value}," +
                $"'{(int)Price_NumericUpDown.Value}.{Price_NumericUpDown.Value % 1 * 100}'," +
                //$"'{Price_NumericUpDown.Value.ToString("#.##")}',"+
                $"'{Sale_DateTimePicker1.Value.Date}'," +
                $"{Demand_NumericUpDown.Value} ," +
                $"{Name_PUBL[Name_PUBL_ComboBox.SelectedItem.ToString()]}," +
                $"{Type_Press[Type_Press_ComboBox.SelectedItem.ToString()]} ," +
                $"{Country[Country_ComboBox.SelectedItem.ToString()]});", connection);

            int number = command.ExecuteNonQuery();
            connection.Close();
            if (number == 0)
            {
                MessageBox.Show("Неудачная попытка входа");
                return;
            }

        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SaveUpdate();
            ShowTable();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            AddData();
            SaveUpdate();
            ShowTable();
            ClearFields();

        }
        private void ClearFields()
        {
            Product_Name_TextBox.Text = "";
            Name_PUBL_ComboBox.SelectedIndex = 0;
            Type_Press_ComboBox.SelectedIndex = 0;
            Country_ComboBox.SelectedIndex = 0;
            Circulation_NumericUpDown.Value = 0;
            Demand_NumericUpDown.Value = 0;
            Price_NumericUpDown.Value = 0;
            Sale_DateTimePicker1.Value = DateTime.Now;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var list in selectControls.Values)
            {
                foreach (var item in list.Values)
                {
                    item.Visible = false;
                }
            }

            foreach (var item in selectControls[comboBox1.SelectedItem.ToString()].Values)
            {
                item.Visible = true;
            }
        }

        private void Print_Select_Button_Click(object sender, EventArgs e)
        {
            QueryCase();
        }
    }
}
