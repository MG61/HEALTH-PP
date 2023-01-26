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

namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        DataSet1 dataSet1 = new DataSet1();

        public Schedule()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string Sql = "select Название_группы from dbo.class";
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                group.Items.Add(DR[0]);
            }
            conn.Close();
        }
        
        // Класс с данными расписания
        public class Lesson
        {
            public string День_недели { get; set; }
            public string Номер { get; set; }
            public string Группа { get; set; }
            public string Дисциплина { get; set; }

        }

        // Метод для генерации случайного расписания
        public Dictionary<string, List<Lesson>> GenerateSchedule()
        {
            // Словарь для хранения расписания для каждого класса
            Dictionary<string, List<Lesson>> schedule = new Dictionary<string, List<Lesson>>();

            // Список возможных значений для каждого поля
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

            string Sql1 = "select Название_группы from dbo.class";
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

            // List<string> classes = new List<string> { "П50-4-19", "1B", "2A", "2B", "3A", "3B" };

            // Получение количества записей в таблице расписания
            SqlConnection conngroup = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            conngroup.Open();
            SqlCommand commgroup = new SqlCommand("SELECT COUNT(*) FROM class", conngroup);
            int countgroup = (int)commgroup.ExecuteScalar();
            conngroup.Close();

            // Генерация случайного расписания для каждого класса
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            int number5 = 0;
            int number6 = 0; 
            Random random = new Random();
            //for (int shetgroup = 0; shetgroup < countgroup; shetgroup++)
            //{
            foreach (string className in classes)
            {
                List<Lesson> classSchedule = new List<Lesson>();
                    for (int i = 0; i < 3; i++)
                    {
                        number1++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Понедельник",
                            Номер = number1.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }
                    classSchedule.Add(new Lesson
                    {
                        День_недели = null,
                        Номер = null,
                        Группа = null,
                        Дисциплина = null
                    });
                    for (int i = 0; i < 3; i++)
                    {
                        number2++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Вторник",
                            Номер = number2.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }
                    classSchedule.Add(new Lesson
                    {
                        День_недели = null,
                        Номер = null,
                        Группа = null,
                        Дисциплина = null
                    });
                    for (int i = 0; i < 3; i++)
                    {
                        number3++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Среда",
                            Номер = number3.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }
                    classSchedule.Add(new Lesson
                    {
                        День_недели = null,
                        Номер = null,
                        Группа = null,
                        Дисциплина = null
                    });
                    for (int i = 0; i < 3; i++)
                    {
                        number4++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Четверг",
                            Номер = number4.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }
                    classSchedule.Add(new Lesson
                    {
                        День_недели = null,
                        Номер = null,
                        Группа = null,
                        Дисциплина = null
                    });
                    for (int i = 0; i < 3; i++)
                    {
                        number5++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Пятница",
                            Номер = number5.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }
                    classSchedule.Add(new Lesson
                    {
                        День_недели = null,
                        Номер = null,
                        Группа = null,
                        Дисциплина = null
                    });
                    for (int i = 0; i < 3; i++)
                    {
                        number6++;
                        classSchedule.Add(new Lesson
                        {
                            День_недели = "Суббота",
                            Номер = number6.ToString(),
                            Группа = className,
                            Дисциплина = subjects[random.Next(subjects.Count)]
                        });
                    }

                    schedule.Add(className, classSchedule);
                    number1 = 0;
                    number2 = 0;
                    number3 = 0;
                    number4 = 0;
                    number5 = 0;
                    number6 = 0;
                    
                }                
            //}
            return schedule;
        }

        // Заполнение DataGrid расписанием
        private void FillDataGrid(Dictionary<string, List<Lesson>> schedule)
        {
            // Выбор класса для отображения
            string selectedClass = group.SelectedValue.ToString();
            data.ItemsSource = schedule[selectedClass];
        }

        //public static DataTable DataViewAsDataTable(DataView dv)
        //{
        //    DataTable dt = dv.Table.Clone();
        //    foreach (DataRowView drv in dv)
        //        dt.ImportRow(drv.Row);
        //    return dt;
        //}



        private void export(object sender, RoutedEventArgs e)
        {
            //Dictionary<string, List<Lesson>> schedule = GenerateSchedule();
            //using (XLWorkbook workbook = new XLWorkbook())
            //{
            //    for (int i = 0; i < listDataTables.Count; i++)
            //    {
            //        workbook.Worksheets.Add(schedule[i], "Sheet" + (i + 1));
            //    }
            //    workbook.SaveAs("data.xlsx");
            //}
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {

        }

        private void FillDataGrid1(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Lesson>> schedule = GenerateSchedule();
            FillDataGrid(schedule);

        }
    }
}
