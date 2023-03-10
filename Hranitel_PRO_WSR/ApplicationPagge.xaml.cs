using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Hranitel_PRO_WSR
{
    /// <summary>
    /// Логика взаимодействия для ApplicationPagge.xaml
    /// </summary>
    class FilterSetting
    {
        int TypeApp { get; set; }
        int DivisionApp { get; set; }
        int StatusApp { get; set; }
        DateTime DateApp { get; set; }
    }
    public partial class ApplicationPagge : Page
    {   
        Staff staffUser = new Staff();
        public ApplicationPagge(Staff staffUser)
        {
            InitializeComponent();

            this.staffUser = staffUser;
            LoadAppl();
            
        }
        public void LoadAppl()
        {
            
            if (staffUser.Departament.Name.ToString() == "Общий отдел")
            {
                DGridApplication.ItemsSource = HranitelPRO_WSREntities.GetContext().Applications.ToList();
                SearchBox.Visibility = Visibility.Hidden;
                SearchButton.Visibility = Visibility.Hidden;
                TypeSearch.Visibility = Visibility.Hidden;
            }
            else if (staffUser.Departament.Name.ToString() == "Охрана")
            {
                DGridApplication.ItemsSource = HranitelPRO_WSREntities.GetContext().Applications.Where(u => u.StatusCode1.Name == "Одобрена").ToList();
            }
        }
        private async void BtnView_Click(object sender, RoutedEventArgs e)
        {

            Applications selectApplication = (Applications)DGridApplication.SelectedItem;
            
            
            DGridUsers.ItemsSource = (HranitelPRO_WSREntities.GetContext().Applications.Where(i => i.id == selectApplication.id).SelectMany(u => u.UsersGroupVisit).SelectMany(h => h.User).ToList());
                
            
            
            // 
        }
        private void BtnSession_Click(object sender, RoutedEventArgs e)
        {
            Applications selectApplication = (Applications)DGridApplication.SelectedItem;
            SessionEditPage editPage = new SessionEditPage(selectApplication);
            if (editPage.ShowDialog() == true)
            {
            }
        }
        
        private void FilterSet_Click(object sender, RoutedEventArgs e)
        {
            FilterSetter setfilter = new FilterSetter(staffUser);
            if (setfilter.ShowDialog() == true)
            {
                if (staffUser.Departament.Name == "Общий отдел")
                {
                    
                        int TypeAppint = setfilter.TypeApp.SelectedIndex;
                        bool TypeApp = TypeAppint == 0 ? false: true;
                        var filtered = HranitelPRO_WSREntities.GetContext().Applications.Include(u => u.Appointment);
                        
                        if (TypeAppint != -1)
                        {
                            filtered = filtered.Where(n => n.GroupVisit == TypeApp);
                        };
                        if (setfilter.DivisionApp.SelectedItem != null)
                        {
                            filtered = filtered.Where(i => i.Appointment.Staff.Division.Name == setfilter.DivisionApp.SelectedItem.ToString());
                        };
                        if (setfilter.StatusApp.SelectedItem != null)
                        {
                            filtered = filtered.Where(i => i.StatusCode1.Name == setfilter.StatusApp.SelectedItem.ToString());
                        };
                        DGridApplication.ItemsSource = filtered.ToList();
                    
                    
                }
                else if(staffUser.Departament.Name == "Охрана")
                {
                    int TypeAppint = setfilter.TypeApp.SelectedIndex;
                    bool TypeApp = TypeAppint == 0 ? false : true;
                    var filtered = HranitelPRO_WSREntities.GetContext().Applications.Include(u => u.Appointment);

                    if (TypeAppint != -1)
                    {
                        filtered = filtered.Where(n => n.GroupVisit == TypeApp);
                    };
                    if (setfilter.DivisionApp.SelectedItem != null)
                    {
                        filtered = filtered.Where(i => i.Appointment.Staff.Division.Name == setfilter.DivisionApp.SelectedItem.ToString());
                    };
                    if (setfilter.DateApp.SelectedDate != null)
                    {
                        filtered = filtered.Where(i => i.Appointment.Date == setfilter.DateApp.SelectedDate);
                    };
                    filtered = filtered.Where(i => i.StatusCode1.Name == "Одобрена");
                    DGridApplication.ItemsSource = filtered.ToList();
                }
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string[] searchText = SearchBox.Text.Split(' '); 
            
            if (TypeSearch.SelectedIndex == 0)
            {
                try
                {
                    
                    string firstName = searchText[1];
                    string lastName = searchText[0];
                    string patronomyc = searchText[2];
                    DGridApplication.ItemsSource = HranitelPRO_WSREntities.GetContext().User
                    .Where(i => i.LastName == lastName)
                    .Where(i => i.FirstName == firstName)
                    .Where(i => i.Patronomyc == patronomyc)
                    .SelectMany(i => i.UsersGroupVisit)
                    .Select(i => i.Applications)
                    .ToList();
                }
                catch { MessageBox.Show("Введены некорректные значения"); }
                
            }
            else if (TypeSearch.SelectedIndex == 1)
            {
                try
                {
                    string numberPas = searchText[1];
                    string serialPas = searchText[0];
                    DGridApplication.ItemsSource = HranitelPRO_WSREntities.GetContext().User
                    .Where(i => i.Passport.Serial == serialPas)
                    .Where(i => i.Passport.Number == numberPas)
                    .SelectMany(i => i.UsersGroupVisit)
                    .Select(i => i.Applications)
                    .ToList();
                }
                catch { MessageBox.Show("Введены некорректные значения"); }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
           
            LoadAppl();
        }
    }
}
