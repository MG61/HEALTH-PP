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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        DataSet1 dataSet = new DataSet1();
        AdminTableAdapter ATA = new AdminTableAdapter();

        public Admin()
        {
            InitializeComponent();

            data.ItemsSource = dataSet.Admin.DefaultView;
            ATA.Fill(dataSet.Admin);
        }

        private void DOB_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                ATA.InsertQuery(log.Text, pass.Text);
                ATA.Fill(dataSet.Admin);
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void UPDATE_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    DataRowView preobraz = (DataRowView)data.SelectedItem;
                    int id = (int)preobraz["Номер пользователя"];
                    ATA.UpdateQuery(log.Text, pass.Text, id);
                    ATA.Fill(dataSet.Admin);
                }
            }
            catch
            {
                MessageBox.Show("Названия не должны повторяться!");
            }
        }

        private void DELETE_sotr_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.SelectedItem != null)
                {
                    DataRowView preobraz = (DataRowView)data.SelectedItem;
                    int id = (int)preobraz["Номер пользователя"];
                    ATA.DeleteQuery(id);
                    ATA.Fill(dataSet.Admin);
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
            if (log.Text == "Логин")
                log.Clear();
        }
        private void los1(object sender, RoutedEventArgs e)
        {
            if (log.Text == "")
                log.Text = "Логин";
        }
        private void got2(object sender, RoutedEventArgs e)
        {
            if (pass.Text == "Пароль")
                pass.Clear();
        }
        private void los2(object sender, RoutedEventArgs e)
        {
            if (pass.Text == "")
                pass.Text = "Пароль";
        }

        private void log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNMйцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

        private void pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM".IndexOf(e.Text) < 0;
        }


    }
}
