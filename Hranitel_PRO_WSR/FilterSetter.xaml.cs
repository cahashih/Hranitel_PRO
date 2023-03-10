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

namespace Hranitel_PRO_WSR
{
    /// <summary>
    /// Логика взаимодействия для FilterSetter.xaml
    /// </summary>
    public partial class FilterSetter : Window
    {
        public FilterSetter(Staff staffUser)
        {
            InitializeComponent();
            if (staffUser.Departament.Name == "Охрана")
            {
                statusText.Visibility = Visibility.Hidden;
                StatusApp.Visibility = Visibility.Hidden;

            }
            else if(staffUser.Departament.Name == "Общий отдел")
            {
                dateText.Visibility = Visibility.Hidden;
                DateApp.Visibility = Visibility.Hidden;
            }
            DivisionApp.ItemsSource = HranitelPRO_WSREntities.GetContext().Division.Select(x => x.Name.ToString()).ToList();
            StatusApp.ItemsSource = HranitelPRO_WSREntities.GetContext().StatusCode.Select(x => x.Name.ToString()).ToList();
        }

        private void FilterSet_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        
    }
}
