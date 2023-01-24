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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PP8_February.DataSet1TableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace PP8_February
{
    public partial class MainWindow : Window
    {

        DataSet1 dataSet1 = new DataSet1();
        TeacherTableAdapter TTA = new TeacherTableAdapter();
        DisciplineTableAdapter DTA = new DisciplineTableAdapter();
        View_ParaTableAdapter VPTA = new View_ParaTableAdapter();
        MondayTableAdapter MTA = new MondayTableAdapter();
        TuesdayTableAdapter TUTA = new TuesdayTableAdapter();
        WednesdayTableAdapter WTA = new WednesdayTableAdapter();
        ThursdayTableAdapter THTA = new ThursdayTableAdapter();
        FridayTableAdapter FTA = new FridayTableAdapter();
        SaturdayTableAdapter STA = new SaturdayTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            Monday.ItemsSource = dataSet1.Monday.DefaultView;
            Tuesday.ItemsSource = dataSet1.Tuesday.DefaultView;
            Wednesday.ItemsSource = dataSet1.Wednesday.DefaultView;
            Thursday.ItemsSource = dataSet1.Thursday.DefaultView;
            Friday.ItemsSource = dataSet1.Friday.DefaultView;
            Saturday.ItemsSource = dataSet1.Saturday.DefaultView;
            MTA.Fill(dataSet1.Monday);
            TUTA.Fill(dataSet1.Tuesday);
            WTA.Fill(dataSet1.Wednesday);
            THTA.Fill(dataSet1.Thursday);
            FTA.Fill(dataSet1.Friday);
            STA.Fill(dataSet1.Saturday);

            string Sql = "select Фамилия from dbo.Teacher";
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                teachercombo.Items.Add(DR[0]);
            }
            conn.Close();

            string Sql1 = "select Name_discipline from dbo.Discipline";
            SqlConnection conn1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PP8;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn1);
            SqlDataReader DR1 = cmd1.ExecuteReader();
            while (DR1.Read())
            {
               disciplinecombo.Items.Add(DR1[0]);
            }
            conn1.Close();
        }

        private void add_monday(object sender, RoutedEventArgs e)
        {
            MTA.Fill(dataSet1.Monday);
            MTA.InsertQuery(disciplinecombo.Text, teachercombo.Text );
            MTA.Fill(dataSet1.Monday);

        }

        private void delete_monday(object sender, RoutedEventArgs e)
        {
                DataRowView preobraz = (DataRowView)Monday.SelectedItem;
                if (preobraz != null)
                {
                    int id = (int)preobraz["Номер пары"];
                    MTA.DeleteQuery(id);
                    MTA.Fill(dataSet1.Monday);
                }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }

        }

        private void add_tuesday(object sender, RoutedEventArgs e)
        {
            TUTA.Fill(dataSet1.Tuesday);
            TUTA.InsertQuery(disciplinecombo.Text, teachercombo.Text);
            TUTA.Fill(dataSet1.Tuesday);
        }

        private void delete_tuesday(object sender, RoutedEventArgs e)
        {
            DataRowView preobraz = (DataRowView)Tuesday.SelectedItem;
            if (preobraz != null)
            {
                int id = (int)preobraz["Номер пары"];
                TUTA.DeleteQuery(id);
                TUTA.Fill(dataSet1.Tuesday);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void add_wednesday(object sender, RoutedEventArgs e)
        {
            WTA.Fill(dataSet1.Wednesday);
            WTA.InsertQuery(disciplinecombo.Text, teachercombo.Text);
            WTA.Fill(dataSet1.Wednesday);
        }

        private void delete_wednesday(object sender, RoutedEventArgs e)
        {
            DataRowView preobraz = (DataRowView)Wednesday.SelectedItem;
            if (preobraz != null)
            {
                int id = (int)preobraz["Номер пары"];
                WTA.DeleteQuery(id);
                WTA.Fill(dataSet1.Wednesday);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void add_thursday(object sender, RoutedEventArgs e)
        {
            THTA.Fill(dataSet1.Thursday);
            THTA.InsertQuery(disciplinecombo.Text, teachercombo.Text);
            THTA.Fill(dataSet1.Thursday);
        }

        private void delete_thursday(object sender, RoutedEventArgs e)
        {
            DataRowView preobraz = (DataRowView)Thursday.SelectedItem;
            if (preobraz != null)
            {
                int id = (int)preobraz["Номер пары"];
                THTA.DeleteQuery(id);
                THTA.Fill(dataSet1.Thursday);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void add_friday(object sender, RoutedEventArgs e)
        {
            FTA.Fill(dataSet1.Friday);
            FTA.InsertQuery(disciplinecombo.Text, teachercombo.Text);
            FTA.Fill(dataSet1.Friday);
        }

        private void delete_friday(object sender, RoutedEventArgs e)
        {
            DataRowView preobraz = (DataRowView)Friday.SelectedItem;
            if (preobraz != null)
            {
                int id = (int)preobraz["Номер пары"];
                FTA.DeleteQuery(id);
                FTA.Fill(dataSet1.Friday);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void add_saturday(object sender, RoutedEventArgs e)
        {
            STA.Fill(dataSet1.Saturday);
            STA.InsertQuery(disciplinecombo.Text, teachercombo.Text);
            STA.Fill(dataSet1.Saturday);
        }

        private void delete_saturday(object sender, RoutedEventArgs e)
        {
            DataRowView preobraz = (DataRowView)Saturday.SelectedItem;
            if (preobraz != null)
            {
                int id = (int)preobraz["Номер пары"];
                STA.DeleteQuery(id);
                STA.Fill(dataSet1.Saturday);
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {

        }

        int paramalltruncate = 0;

        private void delall(object sender, RoutedEventArgs e)
        {
            
            while (paramalltruncate < 2)
            {
                paramalltruncate++;
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = PP8; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Monday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                MTA.Fill(dataSet1.Monday);
            }
            Console.Read();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Tuesday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                TUTA.Fill(dataSet1.Tuesday);
            }
            Console.Read();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Wednesday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                WTA.Fill(dataSet1.Wednesday);
            }
            Console.Read();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Thursday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                THTA.Fill(dataSet1.Thursday);
            }
            Console.Read();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Friday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                FTA.Fill(dataSet1.Friday);
            }
            Console.Read();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = "TRUNCATE TABLE Saturday";
                command.Connection = connection;
                command.ExecuteNonQueryAsync();
                STA.Fill(dataSet1.Saturday);
            }
            Console.Read();
            }
        }

        private void export(object sender, RoutedEventArgs e)
        {

        }
    }
}
