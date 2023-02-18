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
        SqlConnection connection = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog = Press;Integrated Security = true;");
        SqlDataAdapter adapter;
        SqlCommand command;
        DataSet ds = new DataSet();
        Dictionary<string, int> Name_PUBL = new Dictionary<string, int>();
        Dictionary<string, int> Type_Press = new Dictionary<string, int>();
        Dictionary<string, int> Country = new Dictionary<string, int>();
        Dictionary<int, List<Control>> selectControls = new Dictionary<int, List<Control>>();
        public Form1()
        {
            InitializeComponent();
            FillComboBoxes();
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
               5 нумерик - цена комбобоксc
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

            #region selectControls[1] = new List<Control>();
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
            selectControls[1].Add(comboBox);

            Label label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(20, 44);
            label.Text = "Тип прессы";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[1].Add(label);

            selectControls[2] = new List<Control>();
            selectControls[2].Add(comboBox);
            selectControls[2].Add(label);

            selectControls[3] = new List<Control>();
            selectControls[3].Add(comboBox);
            selectControls[3].Add(label);

            selectControls[4] = new List<Control>();
            selectControls[4].Add(comboBox);
            selectControls[4].Add(label);
            // 5 нумерик - цена комбобокс
            selectControls[5] = new List<Control>();
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(20, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[5].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 44);
            label.Text = "Цена";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[5].Add(label);

            selectControls[5] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(40, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[5].Add(comboBox);

            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(40, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[5].Add(label);

            //6 два нумерика для ввода интервала тиража

            selectControls[6] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(40, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[6].Add(numericUpDown);

            selectControls[6] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(40, 84);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[6].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[6].Add(label);

            //7 комбобокс с издатель
            selectControls[7] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(60, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[7].Add(comboBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(60, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[7].Add(label);

            // 8 два нумерика для интервала стоимости + комбобокс для издательства
            selectControls[8] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[8].Add(numericUpDown);

            selectControls[8] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 84);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[8].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала стоимости";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[8].Add(label);

            selectControls[8] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(320, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[8].Add(comboBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(320, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[8].Add(label);

            //9 немерик для ограничения цены
            selectControls[9] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[9].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 44);
            label.AutoSize = true;
            label.Text = "Ввод ограничения цены";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[9].Add(label);


            //10 - два датапикера для интервала
            selectControls[10] = new List<Control>();
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(40, 64);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[10].Add(dateTimePicker);
            selectControls[10] = new List<Control>();
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(40, 84);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[10].Add(dateTimePicker);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(40, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[10].Add(label);

            // 11 комбобокс для издательства и нумерик для стоимости
            selectControls[11] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(320, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[11].Add(comboBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(320, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[11].Add(label);

            selectControls[11] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[11].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 64);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[11].Add(label);

            //12 комбобокс для издательства текстбокс для прессы комбобокс для страны

            selectControls[12] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(420, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[12].Add(comboBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(420, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[12].Add(label);
            //comboBox country
            selectControls[12] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Country.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(220, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[12].Add(comboBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(220, 44);
            label.AutoSize = true;
            label.Text = "Выбор страны";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[12].Add(label);
            //textbox для ввода прессы
            selectControls[12] = new List<Control>();
            TextBox textBox = new TextBox();
            this.tabPage2.Controls.Add(textBox);
            textBox.Visible = false;
            textBox.Location = new System.Drawing.Point(600, 64);
            textBox.Multiline = true;
            textBox.Size = new System.Drawing.Size(150, 20);
            selectControls[12].Add(textBox);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(620, 44);
            label.AutoSize = true;
            label.Text = "Выбор прессы";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[12].Add(label);

            // 13 нумерик для стоимости комбобокс для издательства
            selectControls[13] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[13].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 64);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[13].Add(label);



            selectControls[13] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(220, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[13].Add(comboBox);
            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(420, 44);
            label.AutoSize = true;
            label.Text = "Выбор издателя";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[13].Add(label);


            //14 - два датапикера для интервала
            selectControls[14] = new List<Control>();
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(40, 64);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[14].Add(dateTimePicker);
            selectControls[14] = new List<Control>();
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Visible = false;
            this.tabPage2.Controls.Add(dateTimePicker);
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker.Location = new System.Drawing.Point(40, 84);
            dateTimePicker.Size = new System.Drawing.Size(156, 22);
            selectControls[14].Add(dateTimePicker);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(40, 44);
            label.AutoSize = true;
            label.Text = "Ввод интервала";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[14].Add(label);


            // 15 комбобокс для издательства
            selectControls[15] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(40, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[15].Add(comboBox);

            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(40, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[15].Add(label);


            //16 нумерик цена комбобокс издательство
            selectControls[16] = new List<Control>();
            numericUpDown = new NumericUpDown();
            numericUpDown.Visible = false;
            this.tabPage2.Controls.Add(numericUpDown);
            numericUpDown.DecimalPlaces = 2;
            numericUpDown.Location = new System.Drawing.Point(60, 64);
            numericUpDown.Maximum = new decimal(new int[] { 410065408, 2, 0, 0 });
            selectControls[16].Add(numericUpDown);

            label = new Label();
            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(50, 64);
            label.AutoSize = true;
            label.Text = "Стоимость";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[16].Add(label);

            selectControls[16] = new List<Control>();
            comboBox = new ComboBox();
            comboBox.Visible = false;
            foreach (var name in Name_PUBL.Keys)
            {
                comboBox.Items.Add(name);
            }
            comboBox.SelectedIndex = 0;
            this.tabPage2.Controls.Add(comboBox);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(40, 64);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            selectControls[16].Add(comboBox);

            label.Visible = false;
            this.tabPage2.Controls.Add(label);
            label.Location = new System.Drawing.Point(40, 44);
            label.AutoSize = true;
            label.Text = "Издательство";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            selectControls[16].Add(label);
            #endregion
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




    }
}
