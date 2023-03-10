using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SF2022User_NN_Lib;

namespace Hranitel_PRO_WSR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Staff staffUser = new Staff();
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            Authorization();
            if (staffUser.Departament.Name.ToString() == "Общий отдел")
            {
                DemandMain.Visibility = Visibility.Visible;
            }
            else if (staffUser.Departament.Name.ToString() == "Охрана")
            {
                DemandMain.Visibility = Visibility.Visible;

            }
        }
        private void Authorization()
        {
            Authorization authorizationWindow = new Authorization();
            if (authorizationWindow.ShowDialog() == true)
            {
                try
                {
                    int Codestuff = Int32.Parse(authorizationWindow.StaffNum.Text);
                    if (HranitelPRO_WSREntities.GetContext().Staff.Any(o => o.Code == Codestuff))
                    {
                        MessageBox.Show("Авторизация пройдена");
                        
                        staffUser = HranitelPRO_WSREntities.GetContext().Staff.FirstOrDefault(i => i.Code == Codestuff);
                        UserLFP.Text = staffUser.LFP.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Неверный Код сотрудника");
                        Authorization();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Неккоректные значения");
                    Authorization();
                }
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
                this.Close();
            }
        }

        private void Demand_clck(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ApplicationPagge(staffUser));
        }
        
    }
}
