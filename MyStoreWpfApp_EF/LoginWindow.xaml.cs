using MyStoreWpfApp_EF.Models;
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

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public LoginWindow()
        {
            InitializeComponent();
            ChangeBackground(); 
        }

        private void ChangeBackground()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.PaleVioletRed, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.5));
            btnThoat.Background = brush;

            RadialGradientBrush gradientBrush = new RadialGradientBrush();
            gradientBrush.GradientOrigin = new Point(0.25, 0.75); //góc xoay
            gradientBrush.GradientStops.Add(new GradientStop(Colors.RoyalBlue, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Tomato, 0.5));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Violet, 1.0));
            btnDangNhap.Background = gradientBrush;
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            AccountMember am = context.AccountMembers
                .FirstOrDefault(a => a.EmailAddress == email && a.MemberPassword == password);
            if(am == null)
            {
                MessageBox.Show("Đăng nhập thất bại", "Login failed", 
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            else
            {
                if (am.MemberRole == 1)
                {
                    MessageBox.Show("Đăng nhập ADMIN thành công", "ADMIN Login successfully", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                    Close();
                }
                else if(am.MemberRole == 2)
                {
                    MessageBox.Show("Đăng nhập STAFF thành công", "STAFF Login successfully", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (am.MemberRole == 3)
                {
                    MessageBox.Show("Đăng nhập MEMBER thành công", "MEMBER Login successfully", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
