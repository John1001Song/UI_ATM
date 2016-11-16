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
    /// Interaction logic for DepositPage.xaml
    /// </summary>
    public partial class DepositPage : Page
    {
        public DepositPage()
        {
            InitializeComponent();
            System.Windows.MessageBox.Show("This ATM only takes 5, 10, 20, 50 and 100 dollar bill.");
        }

        private void num_button_click(int i)
        {
            if (this.num_screen.Text.Length >= Globals.max_account_bits)
            {
                System.Windows.MessageBox.Show("Your account number is incorrect.");
            }
            else
            {
                if (i == 10 )
                {
                    this.num_screen.Text = this.num_screen.Text + ".";
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

        private void button_del_Click(object sender, RoutedEventArgs e)
        {   
            if (this.num_screen.Text.Length != 0)
            {
                this.num_screen.Text = this.num_screen.Text.Remove(this.num_screen.Text.Length - 1);
            }
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService service =  NavigationService.GetNavigationService(this);
            service.GoBack();
        }

        private void account_num_input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool isValidAmount(int amount)
        {
            int remainder1 = amount % 100;
            int remainder2 = remainder1 % 50;
            int remainder3 = remainder2 % 20;
            int remainder4 = remainder3 % 10;
            int remainder5 = remainder4 % 5;
            return remainder5 == 0;
        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {

            if (this.num_screen.Text != "" || this.num_screen.Text != null)
            {
                int amount = 0;
                try
                {
                    amount = Int32.Parse(this.num_screen.Text);
                }
                catch
                {
                    System.Windows.MessageBox.Show("Invalid input amount, please try again!");
                    this.num_screen.Text = "";
                }

                if (amount > 0)
                {
                    MessageBoxResult messageBoxResult = 
                        System.Windows.MessageBox.Show(String.Format("Are you sure you want to deposit ${0}?", amount), 
                                                       "Delete Confirmation", 
                                                       System.Windows.MessageBoxButton.YesNo);

                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        if (isValidAmount(amount))
                        {
                            Globals.loginAccount.deposit(amount);
                            System.Windows.MessageBox.Show("Sucessful, please press OK to go back to home page.");
                            NavigationService service =  NavigationService.GetNavigationService(this);
                            service.GoBack();
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("This ATM only takes 5, 10, 20, 50 and 100 dollar bill.");
                            this.num_screen.Text = "";
                        }
                    }

                }
            }

        }
    }
}
