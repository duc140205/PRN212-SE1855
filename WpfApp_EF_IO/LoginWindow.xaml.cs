using BusinessObjects_EF_IO;
using Services_EF_IO;
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
using System.IO;

namespace WpfApp_EF_IO
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            RestoreLoginInformation();
        }

        private void RestoreLoginInformation()
        {
            string filename = "log_login.txt";
            if(File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);   
                string line = sr.ReadLine();
                sr.Close();
                //tách line thành 3 thông số:
                //email;password;checked
                string[] arr = line.Split(";");
                if(arr.Length == 3 && arr[2] == "True")
                {
                    txtEmail.Text = arr[0];
                    txtPassword.Password = arr[1];
                    chkSaveInfor.IsChecked = true;
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Password;
                IAccountMemberService iAccountMemberService = new AccountMemberService();
                AccountMember am = iAccountMemberService.Login(email, password);
                if (am == null)
                {
                    MessageBox.Show(
                        "Login failed. Please check your email and password.",
                        "Login Failed",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                    SaveLoginInformation(am, chkSaveInfor.IsChecked.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        void SaveLoginInformation(AccountMember am, bool saved)
        {
            string data = am.EmailAddress + ";" + am.MemberPassword + ";" + saved;
            StreamWriter sw = new StreamWriter("log_login.txt", false, Encoding.UTF8);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}
