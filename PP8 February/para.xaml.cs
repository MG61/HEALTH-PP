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
using PP8_February.DataSet1TableAdapters;

namespace PP8_February
{
    /// <summary>
    /// Логика взаимодействия для para.xaml
    /// </summary>
    public partial class para : Window
    {
        public para()
        {
            InitializeComponent();
            DataSet1 dataSet1 = new DataSet1();
            ScheduleTableAdapter STA = new ScheduleTableAdapter();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DataSet1 dataSet1 = new DataSet1();
            //    ScheduleTableAdapter STA = new ScheduleTableAdapter();
            //    STA.InsertQuery(teacher.Text, discipline.Text);
            //    STA.Fill(dataSet1.Schedule);
            //}

            //catch
            //{
            //    MessageBox.Show("Названия не должны повторяться!");
            //}
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            //if (data.SelectedItem != null)
            //{
            //    DataSet1 dataSet1 = new DataSet1();
            //    ScheduleTableAdapter STA = new ScheduleTableAdapter();
            //    DataRowView preobraz = (DataRowView)data.SelectedItem;
            //    int id = (int)preobraz["ID_Schedule"];
            //    STA.DeleteQuery(id);
            //    STA.Fill(dataSet1.Schedule);
            //}
            //else { MessageBox.Show("Нельзя удалить пустое поле"); }
        }
    }
}
