using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для SessionEditPage.xaml
    /// </summary>
    public partial class SessionEditPage : Window
    {
        Applications selectedApplication = new Applications();
        public SessionEditPage(Applications selectApplication)
        {
            InitializeComponent();
            selectedApplication = selectApplication;
            DGridUsers.ItemsSource = (HranitelPRO_WSREntities.GetContext().Applications.Where(i => i.id == selectApplication.id).SelectMany(u => u.UsersGroupVisit).SelectMany(h => h.User).ToList());

        }

        private void SessionAcces_Click(object sender, RoutedEventArgs e)
        {
            var sel = HranitelPRO_WSREntities.GetContext().Applications.FirstOrDefault(i => i.id == selectedApplication.id).StartSession = DateTime.Now;
            HranitelPRO_WSREntities.GetContext().SaveChanges();
            Console.Beep(1500, 300);
            this.Close();
        }
    }
}
