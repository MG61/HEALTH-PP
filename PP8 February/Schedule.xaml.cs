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
        
        //// Класс с данными расписания
        //public class Lesson
        //{
        //    public string День_недели { get; set; }
        //    public string Номер { get; set; }
        //    public string Группа { get; set; }
        //    public string Дисциплина { get; set; }

        //}

        private void export(object sender, RoutedEventArgs e)
        {
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
            string Sql = "select Name_discipline from dbo.Discipline";
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand(Sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> subjects = new List<string>();
            while (reader.Read())
            {
                subjects.Add(reader["Name_discipline"].ToString());
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

            // Генерация случайного расписания для каждого класса
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            int number5 = 0;
            int number6 = 0;

            int intforchicl = 0;
            string groupforchicl;
            Random random = new Random();

            for (int shetgroup = 0; shetgroup < countgroup; shetgroup++)
            {
                groupforchicl = classes[intforchicl];
                for (int i = 0; i < 3; i++)
                {
                    number1++;
                    STA.InsertQuery("Понедельник", number1.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    number2++;
                    STA.InsertQuery("Вторник", number2.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    number3++;
                    STA.InsertQuery("Среда", number3.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    number4++;
                    STA.InsertQuery("Четверг", number4.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    number5++;
                    STA.InsertQuery("Пятница", number5.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
                }
                STA.InsertQuery(null, null, null, null);
                for (int i = 0; i < 3; i++)
                {
                    number6++;
                    STA.InsertQuery("Суббота", number6.ToString(), groupforchicl, subjects[random.Next(subjects.Count)]);
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
        private void test(object sender, RoutedEventArgs e)
        {
            string Sql = "select Name_discipline from dbo.Schedule";
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand(Sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<string> sch = new List<string>();
            while (reader.Read())
            {
                sch.Add(reader["Name_discipline"].ToString());
            }
            reader.Close();
            connection.Close();
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };

            //for (var i = 0; i < sch.Count; i++)
            //{
            //    if (sch[1] == )
            //    Console.WriteLine(nums[i]);
            //}
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
    }
}
