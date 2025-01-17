﻿using System;
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
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace PP8_February
{
    public partial class MainWindow : Window
    {

        DataSet1 dataSet = new DataSet1();
        AdminTableAdapter ATA = new AdminTableAdapter();
        

        public MainWindow()
        {
            InitializeComponent();
            ATA.Fill(dataSet.Admin);
        }

        private void Voyti_Click(object sender, RoutedEventArgs e)
        {
            string log = LOG.Text;
            string pass = PASS.Text;
            AdminAuth(log, pass);
        }

        int prov = 0;
        private void AdminAuth(string adminlog, string adminpass)
        {
            try
            {
                for (int i = 0; i < dataSet.Admin.Rows.Count; i++)
                {
                    if (adminlog == dataSet.Admin.Rows[i][1].ToString() && adminpass == dataSet.Admin.Rows[i][2].ToString())
                    {
                        prov = 1;
                        MenuAdmin adm = new MenuAdmin();
                        adm.Show();
                        this.Close();
                    }
                }
                    if(prov == 0)
                    {
                        MessageBox.Show("Введите данные!");
                    }
            }
            catch { }
            prov = 0;
        }

        private void log_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNMйцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }
        private void pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNMйцукёенгшщзхъэждлорпавыфячсмитьбю.ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ".IndexOf(e.Text) < 0;
        }

    }
}
