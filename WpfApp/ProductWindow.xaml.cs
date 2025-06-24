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

using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();

        bool isComplete = false;
        public ProductWindow()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            isComplete = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isComplete = true;
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            isComplete = false;
            Product p = new Product();
            p.Id = int.Parse(txtId.Text);
            p.Name = txtName.Text;
            p.Quantity = int.Parse(txtQuantity.Text);
            p.Price = double.Parse(txtPrice.Text);

            bool ret = productService.SaveProduct(p);
            if (ret)
            {
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm mới Sản phẩm");
            }
            isComplete = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(isComplete == false)
                return; //các tác vụ thay đổi dữ liệu chưa xong
            if(e.AddedItems.Count < 0)        
                return; //user did not select any item
            //get selected product
            //because we are binding list Product, so item is Product
            Product p = e.AddedItems[0] as Product;
            if (p == null)
                return; //vì lí do thần thánh nào đó mà p là null thì ko làm gì
            txtId.Text = p.Id.ToString();
            txtName.Text = p.Name;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isComplete = false;
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                double price = double.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                Product p = new Product() { Id = id, Name = name, Price = price, Quantity = quantity };

                bool kq = productService.UpdateProduct(p);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isComplete = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return;
            }
            
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show("Bạn có chắc muốn xóa Sản phẩm này không?", 
                        "Xác nhận xóa", MessageBoxButton.YesNo, 
                                        MessageBoxImage.Question);
            if (ret == MessageBoxResult.No)
                return; //user does not want to delete product


            isComplete = false;

            Product pDel = new Product();
            pDel.Id = int.Parse(txtId.Text);

            bool kq = productService.DeleteProduct(pDel);
            if(kq == true)
            {
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = productService.GetProducts();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa Sản phẩm");
            }
            isComplete = true;
        }
    }
}
