using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PP8_February.DataSet1TableAdapters;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using System.Data.Entity;
using static PP8_February.DataSet1;
using MessageBox = System.Windows.MessageBox;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Window = System.Windows.Window;
using System.Runtime.ConstrainedExecution;

namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        DataSet1 dataSet1 = new DataSet1();
        ScheduleTableAdapter STA = new ScheduleTableAdapter();

        public Schedule()
        {
            InitializeComponent();

            data.ItemsSource = dataSet1.Schedule.DefaultView;
            STA.Fill(dataSet1.Schedule);
        }

        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
        }

        private void export(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = null;
            Excel.Workbook wb = null;

            object missing = Type.Missing;
            Excel.Worksheet ws = null;
            Excel.Range rng = null;

            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            DataView view = (DataView)data.ItemsSource;
            DataTable dt = DataViewAsDataTable(view);

            for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
            {
                ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
            }

            for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
            {
                ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
            }

            excel.Visible = true;
            wb.Activate();
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MenuAdmin go = new MenuAdmin();
            go.Show();
            this.Close();
        }

        private void dob_table(object sender, RoutedEventArgs e)
        {

            List<string> День_неделиs = new List<string> { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            List<string> times = new List<string> { "1", "2", "3", "4", "5", "6" };
            string Sql = "select Дисциплина from dbo.Discipline";
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand(Sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> subjects = new List<string>();
            while (reader.Read())
            {
                subjects.Add(reader["Дисциплина"].ToString());
            }
            reader.Close();
            connection.Close();

            string Sql1 = "select Название_группы from dbo.Class1";
            SqlConnection connection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            connection1.Open();
            SqlCommand command1 = new SqlCommand(Sql1, connection1);
            SqlDataReader reader1 = command1.ExecuteReader();
            List<string> classes = new List<string>();
            while (reader1.Read())
            {
                //group.SelectedIndex = group.SelectedIndex + 1;
                classes.Add(reader1["Название_группы"].ToString());
            }
            reader1.Close();
            connection1.Close();

            // Получение количества записей в таблице расписания
            SqlConnection conngroup = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            conngroup.Open();
            SqlCommand commgroup = new SqlCommand("SELECT COUNT(*) FROM Class1", conngroup);
            int countgroup = (int)commgroup.ExecuteScalar();
            conngroup.Close();

            SqlConnection connsubject = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            connsubject.Open();
            SqlCommand commsubject = new SqlCommand("SELECT COUNT(*) FROM Discipline", connsubject);
            int countsubject = (int)commsubject.ExecuteScalar();
            connsubject.Close();

            // Генерация случайного расписания для каждого класса
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            int number5 = 0;
            int number6 = 0;

            int intforchicl = 0;
            string groupforchicl;
            int intsubjects = 0;
            string subject;
            int chet = 0;
            Random random = new Random();

            for (int shetgroup = 0; shetgroup < countgroup; shetgroup++)
            {
                groupforchicl = classes[intforchicl];
                
                for (int i = 0; i < 3; i++)
                {
                    number1++;
                    for (int l = 0;l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Понедельник" == dataSet1.Schedule.Rows[l][1].ToString() && number1.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subjects[intsubjects] == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            chet=1;
                            Console.WriteLine(chet);
                        }
                    }
                    if (chet > 0)
                    {
                        intsubjects++;
                        Console.WriteLine(chet);
                        Console.WriteLine("intsubjects:" + intsubjects);
                        if (intsubjects == countsubject)
                        {
                            intsubjects = 0;
                        }
                        chet = 0;
                    }
                    for (int е = 0; е < dataSet1.Schedule.Rows.Count; е++)
                    {
                        if ("Понедельник" == dataSet1.Schedule.Rows[е][1].ToString() && number1.ToString() == dataSet1.Schedule.Rows[е][2].ToString() && subjects[intsubjects] == dataSet1.Schedule.Rows[е][4].ToString())
                        {
                            Console.WriteLine("Есть");
                        }
                    }
                    STA.InsertQuery("Понедельник", number1.ToString(), groupforchicl, subjects[intsubjects]);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    subject = subjects[intsubjects];
                    for (int l = 0; l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Вторник" == dataSet1.Schedule.Rows[l][1].ToString() && number2.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subject == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            //intsubjects++;
                        }
                    }
                    subject = subjects[intsubjects];
                    number2++;
                    STA.InsertQuery("Вторник", number2.ToString(), groupforchicl, subject);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    subject = subjects[intsubjects];
                    for (int l = 0; l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Среда" == dataSet1.Schedule.Rows[l][1].ToString() && number3.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subject == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            //intsubjects++;
                        }
                    }
                    subject = subjects[intsubjects];
                    number3++;
                    STA.InsertQuery("Среда", number3.ToString(), groupforchicl, subject);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    subject = subjects[intsubjects];
                    for (int l = 0; l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Четверг" == dataSet1.Schedule.Rows[l][1].ToString() && number4.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subject == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            //intsubjects++;
                        }
                    }
                    subject = subjects[intsubjects];
                    number4++;
                    STA.InsertQuery("Четверг", number4.ToString(), groupforchicl, subject);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    subject = subjects[intsubjects];
                    for (int l = 0; l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Пятница" == dataSet1.Schedule.Rows[l][1].ToString() && number5.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subject == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            //intsubjects++;
                        }
                    }
                    subject = subjects[intsubjects];
                    number5++;
                    STA.InsertQuery("Пятница", number5.ToString(), groupforchicl, subject);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    subject = subjects[intsubjects];
                    for (int l = 0; l < dataSet1.Schedule.Rows.Count; l++)
                    {
                        if ("Суббота" == dataSet1.Schedule.Rows[l][1].ToString() && number6.ToString() == dataSet1.Schedule.Rows[l][2].ToString() && subject == dataSet1.Schedule.Rows[l][4].ToString())
                        {
                            //intsubjects++;
                        }
                    }
                    subject = subjects[intsubjects];
                    number6++;
                    STA.InsertQuery("Суббота", number6.ToString(), groupforchicl, subject);
                    intsubjects++;
                    if (intsubjects == countsubject)
                    {
                        intsubjects = 0;
                    }
                }
                STA.InsertQuery(null, null, null, null);
                STA.Fill(dataSet1.Schedule);

                number1 = 0;
                number2 = 0;
                number3 = 0;
                number4 = 0;
                number5 = 0;
                number6 = 0;
                intforchicl++;
           
            }

        }

        private void delete_table(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            string Sql = "TRUNCATE TABLE Schedule";
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            STA.Fill(dataSet1.Schedule);
        }

        //Убирает первый столбец datagrid
        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ID_schedule")
            {
                e.Cancel = true;
            }
        }   
    }

}
