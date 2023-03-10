using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace Hranitel_PRO_WSR
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string StuffCode
        {

            get { return StaffNum.Text; }
        }

        private void StaffNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (StaffNum.Text == "")
            {
                CodeText.Visibility = Visibility.Visible;
            }
            else
            {
                CodeText.Visibility = Visibility.Hidden;
            }
        }
    }
}
