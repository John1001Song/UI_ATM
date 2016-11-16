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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM
{
    /// <summary>
    /// Interaction logic for Balance_view.xaml
    /// </summary>
    public partial class Balance_view : Page
    {
        public Balance_view()
        {
            InitializeComponent();
            this.balance_label.Content = "Your current balance is $" + Globals.loginAccount.balance;
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service = NavigationService.GetNavigationService(this);
            service.GoBack();
        }
    }
}
