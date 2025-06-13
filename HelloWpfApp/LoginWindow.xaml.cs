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

namespace HelloWpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            //Ta giải đò làm đăng nhập:
            // nếu thành công thì vào MainWindow
            //nếu thất bại thhif thông tháo Failed
            if(txtUserName.Text == "obama" &&  txtPassword.Password == "123")
            {
                //mở màn hình MainWindow
                MainWindow mw = new MainWindow();
                mw.Show();
                //đóng màn hình đăng nhập:
                Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
