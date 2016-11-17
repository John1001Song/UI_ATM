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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            this.button_home.Visibility = Visibility.Hidden;
        }

        private enum LoginState { ACCOUNT_NUM, ACCOUNT_PIN }

        MainMenu mainMenu;
        private int max_account_bits = 14;
        private LoginState loginState = LoginState.ACCOUNT_NUM;


        private static string request_acc_num_label = "Please enter your account number:";
        private static string request_acc_pin_label = "Please enter your PIN number:";

        private void num_button_click(int i)
        {
            if (this.num_screen.Text.Length >= max_account_bits)
            {
                System.Windows.MessageBox.Show("Your account number is incorrect.");
            }
            else
            {
                if (i == 11)
                {
                    this.num_screen.Text = this.num_screen.Text + 0 + 0;
                }
                else
                {
                    this.num_screen.Text = this.num_screen.Text + i;
                }
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(1);
        }

        private void account_num_input_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(3);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(4);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(5);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(6);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(7);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(8);
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(9);
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(0);
        }

        private void button00_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(11);
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {   
            if (this.num_screen.Text.Length != 0)
            {
                this.num_screen.Text = this.num_screen.Text.Remove(this.num_screen.Text.Length - 1);
            }
        }

        private void button_clr_Click(object sender, RoutedEventArgs e)
        {
            if (this.num_screen.Text.Length != 0)
            {
                this.num_screen.Text = this.num_screen.Text.Remove(this.num_screen.Text.Length - this.num_screen.Text.Length);
            }
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            if (this.num_screen.Text.Length != 0)
            {

                if (loginState == LoginState.ACCOUNT_NUM)
                {
                    int account_num = Int32.Parse(this.num_screen.Text);

                    Globals.loginAccount = Database.ValidateAccout(account_num);

                    if (Globals.loginAccount != null)
                    {
                        button_home.Visibility = Visibility.Visible;
                        loginState = LoginState.ACCOUNT_PIN;
                        this.num_screen.Text = "";
                        this.login_label.Content = request_acc_pin_label;

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Account number does not exist!");
                    }
                }
                else
                {   
                    int guess_pin = Int32.Parse(this.num_screen.Text);

                    if (Globals.loginAccount.pin == guess_pin)
                    {
                        mainMenu = new MainMenu();
                        this.NavigationService.Navigate(mainMenu);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Incorrect password!");
                    }

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Account number can not be empty!");
            }


        }

        private void button_home_Click(object sender, RoutedEventArgs e)
        {
            Globals.loginAccount = null;
            this.num_screen.Text = "";
            this.login_label.Content = request_acc_num_label;
            this.loginState = LoginState.ACCOUNT_NUM;
            NavigationService service = NavigationService.GetNavigationService(this);
            service.GoBack();
          
        }
    
  //    private void button_home_Click(object sender, RoutedEventArgs e)
  //   {
  //        NavigationService service = NavigationService.GetNavigationService(this);
  //        service.GoBack();
  //    }
    }
}
