using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //x là giá trị muốn đưa vào cuối danh sách
            int x = int.Parse(txtGiaTri.Text);
            //thêm x vào danh sách
            dsDuLieu.Add(x);
            HienThiDanhDanh();
            txtGiaTri.Text = "";
        }

        //Hàm hiển thị danh sách lên giao diện
        void HienThiDanhDanh()
        {
            lstDuLieu.Items.Clear();
            for(int i = 0; i<dsDuLieu.Count; i++)
            {
                int x = dsDuLieu[i];
                lstDuLieu.Items.Add(x);
            }

        }

        private void btnChen_Click(object sender, RoutedEventArgs e)
        {
            //x là giá trị muốn chèn
            int x = int.Parse(txtGiaTriChen.Text);
            //vt mà ta chèn x vào 
            int vt = int.Parse(txtViTriChen.Text);
            //chen x vao vi tri vt
            dsDuLieu.Insert(vt,x);
            //hien thi lai danh sach
            HienThiDanhDanh();
            txtViTriChen.Text = "";
            txtGiaTriChen.Text = "";
        }

        private void btnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            //goi lenh sap xep danh sach
            dsDuLieu.Sort();
            //Hien thi lai danh sach
            HienThiDanhDanh();
        }

        private void btnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            //sap xep tang dan 
            dsDuLieu.Sort();
            //dao lai danh sach 
            dsDuLieu.Reverse();
            //hien thi lai danh sach
            HienThiDanhDanh();
        }

        private void btnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            //xoa phan tu tai vi tri dang chon
            dsDuLieu.RemoveAt(lstDuLieu.SelectedIndex);
            HienThiDanhDanh();
        }

        private void btnXoaNhieuPhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            //vong lap lay cac phan tu duoc chon tren giao dien 
            while(lstDuLieu.SelectedItems.Count > 0)
            {
                //lay phan tu dau tien ra
                int data = (int)lstDuLieu.SelectedItems[0];
                //xoa khoi danh sach 
                dsDuLieu.Remove(data);
                //xoa du lieu tren giao dien
                lstDuLieu.Items.Remove(data);
            }
        }

        private void btnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear();//xoa toan bo du lieu
            HienThiDanhDanh();
        }
    }
}