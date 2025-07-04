using BusinessObjects_EF;
using Services_EF;
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

namespace WpfApp_EF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IAccountMemberService accountMemberService = new AccountMemberService();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountMember am = accountMemberService.login(
                txtEmail.Text, txtPassword.Password);
            if (am == null)
            {
                MessageBox.Show(
                    "Đăng nhập thất bại - vui lòng kiểm tra lại", "Login Fail",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (am.MemberRole == 1)
                {
                    //ADMIN
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
