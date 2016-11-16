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
    /// Interaction logic for TransferPage.xaml
    /// </summary>
    public partial class TransferPage : Page
    {

        private enum TransferStage { ACCOUNT, AMOUNT }
        private TransferStage transferStage;
        private Account toAccount;

        public TransferPage()
        {
            InitializeComponent();
            this.transferStage = TransferStage.ACCOUNT;
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

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(0); 
        }

        private void button_dot_Click(object sender, RoutedEventArgs e)
        {
            num_button_click(10);
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

        private void button_del_Click(object sender, RoutedEventArgs e)
        {   
            if (this.num_screen.Text.Length != 0)
            {
                this.num_screen.Text = this.num_screen.Text.Remove(this.num_screen.Text.Length - 1);
            }
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            if (this.transferStage == TransferStage.ACCOUNT)
            {
                NavigationService service =  NavigationService.GetNavigationService(this);
                service.GoBack();
            }
            else if (this.transferStage == TransferStage.AMOUNT)
            {
                this.top_label.Content = "Please enter an account number:";
                this.num_screen.Text = "";
                this.transferStage = TransferStage.ACCOUNT;
            }

        }

        private void account_num_input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {
            if (this.transferStage == TransferStage.ACCOUNT)
            {
                if (this.num_screen.Text != "")
                {
                    int toAccNum = 0;
                    try
                    {
                        toAccNum = Int32.Parse(this.num_screen.Text);
                        this.toAccount = Database.ValidateAccout(toAccNum); 
                    }
                    catch
                    {

                        System.Windows.MessageBox.Show("Invalid input account, please try again!");
                        this.num_screen.Text = "";
                    }

                    if (this.toAccount != null)
                    {   
                        if (Globals.loginAccount.accountNumber == toAccNum)
                        {
                            System.Windows.MessageBox.Show("You cannot transfer to yourself.");
                            this.num_screen.Text = "";
                        }

                        else if (Database.contains(toAccNum))
                        {
                            this.top_label.Content = "Please enter an amount to transfer:";
                            this.num_screen.Text = "";
                            this.transferStage = TransferStage.AMOUNT;
                            this.button_dot.IsEnabled = true;
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Unknown account!");
                            this.num_screen.Text = "";
                        }

                    }
                }


            }
            else
            {

                double amount = 0;
                try
                {
                    amount = Double.Parse(this.num_screen.Text);
                }
                catch
                {

                    System.Windows.MessageBox.Show("Invalid input amount, please try again!");
                    this.num_screen.Text = "";
                }

                if (amount > 0)
                {
                    MessageBoxResult messageBoxResult = 
                        System.Windows.MessageBox.Show(String.Format("Are you sure you want to transfer ${0} to account {1}?", amount, this.toAccount.accountNumber), 
                                                       "Delete Confirmation", 
                                                       System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        Globals.loginAccount.transfer(amount, this.toAccount);
                        System.Windows.MessageBox.Show("Sucess, press OK to go to home page");
                        NavigationService service =  NavigationService.GetNavigationService(this);
                        service.GoBack();

                    }

                }

            }
        }
    }
}
