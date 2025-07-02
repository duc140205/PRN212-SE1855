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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriresIntoTreeView();
        }

        private void LoadCategoriresIntoTreeView()
        {
            //Tạo gốc cây
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Danh mục sản phẩm";
            tvCategory.Items.Add(root);
            //Dùng EF truy cấn toàn bộ danh mục và nạp lên Trê:
            var categories = context.Categories.ToList();
            foreach ( var category in categories )
            {
                //tạo node cho danh mục
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                //nạp danh sách Sản phẩm vào node danh mục:
                var products = context.Products
                    .Where(x=>x.CategoryId == category.CategoryId)
                    .ToList();
                foreach (var product in products)
                {
                    //Tao product node
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);
                }
            }
            root.ExpandSubtree();   
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
                return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            Category category = item.Tag as Category;
            if (category != null) {
                LoadProductIntoListView(category);
            }
            Product product = item.Tag as Product;
            if(product != null) // nếu là sản phẩm thì nạp sản phẩm vào ListView
            {
                var products = new List<Product>();
                products.Add(product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
            }

        }

        private void LoadProductIntoListView(Category category)
        {
            var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            Product product = e.AddedItems[0] as Product;
            if (product == null) return;
            DisplayProductDetail(product);  
        }

        private void DisplayProductDetail(Product product)
        {
            if(product == null)
            {
                txtId.Text = "";
                txtName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = string.Empty;
                txtId.Focus();
            }
            else
            {
                txtId.Text = product.ProductId+"";
                txtName.Text = product.ProductName;
                txtQuantity.Text = product.UnitsInStock+"";
                txtPrice.Text = product.UnitPrice+"";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetail(null); 
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Bước 1: Tạo đối tượng Sản phẩm
                //Bước 2: Phải biết sản phẩm này gán vào Danh mục nào
                // Bước 3: Lưu đối tượng
                // Bước 4: Cập nhật lại TreeView và ListView                       

                //Chi tiết xử lý
                //Bước 1: tạo đối tượng Sản phẩm
                Product product = new Product();
                //ko gán Id vì Id CSDL thiết kế là tự tăng
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                //Bước 2: Phải biết sản phẩm này gán vào Danh mục nào
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected == null)
                {
                    MessageBox.Show("Bạn phải chọn danh mục trước khi lưu sản phẩm",
                        "Thông báo lưu bị lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                Category category = cate_node_selected.Tag as Category;
                if (category == null)
                {
                    MessageBox.Show("Bạn phải chọn danh mục trước khi lưu sản phẩm",
                        "Thông báo lưu bị lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                product.CategoryId = category.CategoryId; //gán vào danh mục
                                                          //Bước 3: Lưu đối tượng
                context.Products.Add(product);
                context.SaveChanges();
                //Bước 4: Cập nhật lại TreeView và ListView
                //Bước 4.1: Cập nhật lại TreeeView
                TreeViewItem product_node = new TreeViewItem();
                product_node.Header = product.ProductName;
                product_node.Tag = product;
                cate_node_selected.Items.Add(product_node);
                //Bước 4.2: Cập nhật lại ListView (hiển thị sản phẩm vừa lưu
                //vừa thêm vào CSDL thành công lên giao diện)
                LoadProductIntoListView(category);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, 
                    "Thông báo lỗi", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Bước 1: Phải tìm được sản phẩm thì mới sửa
                // Bước 2: Cập nhật các thông tin
                // Bước 3: Lưu đối tượng
                // Bước 4: Cập nhật lại TreeView và ListView
                //---------CHI TIẾT XỬ LÝ----------------
                //Bước 1: Phải tìm được sản phẩm thì mới sửa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã =" + id + "để Sửa",
                        "Thông báo lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                //Bước 2: Cập nhật các thông tin
                //Theo ORM ta học: Sửa giá trị của thuộc tính chính là sửa CELL của 1 row
                //trong bảng 
                product.ProductName = txtName.Text;
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                product.UnitPrice = decimal.Parse(txtPrice.Text);

                //Bước 3: Lưu đối tượng
                context.SaveChanges();
                //Bước 4: Cập nhật lại TreeView và ListView
                //Bước 4.1: Cập nhật lại TreeView
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected != null)
                {
                    Category category = cate_node_selected.Tag as Category;
                    if (category != null)
                    {
                        //Xóa toàn bộ Node con trong node danh mục
                        cate_node_selected.Items.Clear();
                        //Nạp lại toàn bộ Products node
                        //nạp danh sách Sản phẩm vào node danh mục:
                        var products = context.Products
                            .Where(x => x.CategoryId == category.CategoryId)
                            .ToList();
                        foreach (var product_new in products)
                        {
                            //Tao product node
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_new.ProductName;
                            product_node.Tag = product_new;
                            cate_node_selected.Items.Add(product_node);
                        }
                        //Bước 4.2: Cập nhật lại ListView (hiển thị sản phẩm vừa sửa
                        //vừa cập nhật CSDL thành công lên giao diện)
                        LoadProductIntoListView(category);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bước 1: Phải tìm được sản phẩm thì mới xóa
                //Bước 2: Xác nhận có xóa hay không
                //Bước 3: Xóa đối tượng 
                //Bước 4: Nếu xóa thành công thì cập nhật lại TreeView và ListView

                //---------CHI TIẾT XỬ LÝ----------------
                //Bước 1: Phải tìm được sản phẩm thì mới xóa
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm có mã =" + id + "để Xóa",
                        "Thông báo lỗi",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                //Bước 2: Xác nhận có xóa hay không
                MessageBoxResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{product.ProductName}] không?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                if (result == MessageBoxResult.No) return;
                //Bước 3: Xóa đối tượng
                context.Products.Remove(product);
                context.SaveChanges();
                //Bước 4: Nếu xóa thành công thì cập nhật lại TreeView và ListView
                //Bước 4.1: Xóa node sản phẩm ra khỏi Node danh mục trên TreeView
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected != null)
                {
                    Category category = cate_node_selected.Tag as Category;
                    if (category != null)
                    {
                        //Xóa toàn bộ Node con trong node danh mục
                        cate_node_selected.Items.Clear();
                        //Nạp lại toàn bộ Products node
                        //nạp danh sách Sản phẩm vào node danh mục:
                        var products = context.Products
                            .Where(x => x.CategoryId == category.CategoryId)
                            .ToList();
                        foreach (var product_new in products)
                        {
                            //Tao product node
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = product_new.ProductName;
                            product_node.Tag = product_new;
                            cate_node_selected.Items.Add(product_node);
                        }
                        //Bước 4.2: Cập nhật lại ListView (hiển thị sản phẩm vừa sửa
                        //vừa cập nhật CSDL thành công lên giao diện)
                        LoadProductIntoListView(category);
                        DisplayProductDetail(null); //Xóa thông tin sản phẩm trên giao diện
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Thông báo lỗi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            
        }
    }
}
