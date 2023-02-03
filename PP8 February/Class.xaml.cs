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
    /// Логика взаимодействия для Class.xaml
    /// </summary>
    public partial class Class : Window
    {
        DataSet1 dataSet = new DataSet1();
        Class1TableAdapter CTA = new Class1TableAdapter();

        public Class()
        {
            InitializeComponent();

            data.ItemsSource = dataSet.Class1.DefaultView;
            CTA.Fill(dataSet.Class1);
        }

        private void DOB_group(object sender, RoutedEventArgs e)
        {
            try
            {
                CTA.InsertQuery(Classtext.Text);
                CTA.Fill(dataSet.Class1);
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
                    int id = (int)preobraz["Номер пользователя"];
                    CTA.UpdateQuery(Classtext.Text, id);
                    CTA.Fill(dataSet.Class1);
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
                    int id = (int)preobraz["Номер пользователя"];
                    CTA.DeleteQuery(id);
                    CTA.Fill(dataSet.Class1);
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
    }
}

