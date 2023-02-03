using PP8_February.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для Discipline.xaml
    /// </summary>
    public partial class Discipline : Window
    {
        DataSet1 dataSet = new DataSet1();
        DisciplineTableAdapter DTA = new DisciplineTableAdapter();

        public Discipline()
        {
            InitializeComponent();

            data.ItemsSource = dataSet.Discipline.DefaultView;
            DTA.Fill(dataSet.Discipline);
        }

        private void DOB_group(object sender, RoutedEventArgs e)
        {
            try
            {
                DTA.InsertQuery(Disciplinetext.Text);
                DTA.Fill(dataSet.Discipline);
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void UPDATE_group(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    DataRowView preobraz = (DataRowView)data.SelectedItem;
                    int id = (int)preobraz["ID_discipline"];
                    DTA.UpdateQuery(Disciplinetext.Text, id);
                    DTA.Fill(dataSet.Discipline);
                }
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void DELETE_group(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    DataRowView preobraz = (DataRowView)data.SelectedItem;
                    int id = (int)preobraz["ID_discipline"];
                    DTA.DeleteQuery(id);
                    DTA.Fill(dataSet.Discipline);
                }
            }
            catch
            {
                MessageBox.Show("Выберите поле!");
            }
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MenuAdmin main = new MenuAdmin();
            main.Show();
            this.Close();
        }

        private void got1(object sender, RoutedEventArgs e)
        {
            if (Disciplinetext.Text == "Дисциплина")
                Disciplinetext.Clear();
        }

        //Убирает первый столбец datagrid
        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ID_discipline")
            {
                e.Cancel = true;
            }
        }
    }
}
