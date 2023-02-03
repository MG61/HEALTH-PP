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

namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void EXIT_2(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Employee(object sender, RoutedEventArgs e)
        {
            Admin go = new Admin();
            go.Show();
            this.Close();
        }

        private void Schedule(object sender, RoutedEventArgs e)
        {
            Schedule go = new Schedule();
            go.Show();
            this.Close();
        }

        private void Group(object sender, RoutedEventArgs e)
        {
            Class go = new Class();
            go.Show();
            this.Close();
        }

        private void discipline(object sender, RoutedEventArgs e)
        {
            Discipline go = new Discipline();
            go.Show();
            this.Close();
        }
    }
}
