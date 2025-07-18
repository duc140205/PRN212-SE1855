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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService();
        //new 
        bool is_loaded_product_completed = true;
        Category selected_category = null;
        Product selected_product = null;
        TreeViewItem selected_product_node = null;
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesAndProductsIntoTreeView();
        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            tvCategory.Items.Clear();
            // Create a root node for categories
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cái Mép";
            tvCategory.Items.Add(root);
            // Load categories from the service
            List<Category> categories = categoryService.GetCategories();
            foreach (Category category in categories)
            {
                //Create cate node
                TreeViewItem categoryNode = new TreeViewItem();
                categoryNode.Header = category.CategoryName;
                categoryNode.Tag = category; // Store the category object in the Tag property
                root.Items.Add(categoryNode);
                // Load products for each category
                List<Product> products = productService
                                            .GetProductsByCategory(category.CategoryId);
                category.Products = products; // Ensure the category has its products loaded
                foreach (Product product in category.Products)
                {
                    // Create product node
                    TreeViewItem productNode = new TreeViewItem();
                    productNode.Header = product.ProductName;
                    productNode.Tag = product; // Store the product object in the Tag property
                    categoryNode.Items.Add(productNode);
                }
            }
            root.ExpandSubtree(); // Expand the root node to show categories
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lay danh muc dang chon ra
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if ((cate_item == null || selected_category == null) 
                    && selected_product == null )
                {
                    MessageBox.Show("Bạn chưa chọn danh mục, không thể sửa được",
                                    "Lỗi chưa chọn danh mục",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    return;
                }
                //tao 1 doi tuong Product
                Product p = new Product();
                p.ProductId = int.Parse(txtId.Text);    
                p.ProductName = txtName.Text;
                p.UnitPrice = decimal.Parse(txtPrice.Text);
                p.UnitsInStock = short.Parse(txtQuantity.Text);
                if(selected_product_node == null)
                {
                    p.CategoryId = selected_category.CategoryId;
                }
                else
                {
                    p.CategoryId = selected_product.CategoryId; // Keep the same category ID if editing a product
                }


                bool ret = productService.UpdateProduct(p);
                if (ret)
                {
                    is_loaded_product_completed = false;

                    //Nap lai len tree
                    if(selected_product_node == null)
                    {
                        cate_item.Items.Clear(); // Clear existing items in the category node   
                        var products = productService
                                        .GetProductsByCategory(selected_category.CategoryId);
                        foreach (var product in products)
                        {
                            TreeViewItem p_item = new TreeViewItem();
                            p_item.Header = product.ProductName;
                            p_item.Tag = product; // Store the product object in the Tag property
                            cate_item.Items.Add(p_item);
                        }
                        //Nap lai ListView
                        lvProduct.ItemsSource = null;
                        lvProduct.ItemsSource = products;
                    }
                    else
                    {
                        selected_product_node.Header = p.ProductName; // Update the product name in the tree view
                        selected_product_node.Tag = p; // Update the product object in the Tag property
                    
                        List<Product> products1 = new List<Product>();
                        products1.Add(p); // Add the updated product to the list
                        lvProduct.ItemsSource = null; // Clear the ListView
                        lvProduct.ItemsSource = products1;
                    }
                        
                    is_loaded_product_completed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message,
                    "Lỗi cập nhật",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lay danh muc dang chon ra
                TreeViewItem cate_item = tvCategory.SelectedItem as TreeViewItem;
                if (cate_item == null || selected_category == null)
                {
                    MessageBox.Show("Bạn chưa chọn danh mục, không thêm mới được",
                                    "Lỗi chưa chọn danh mục",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    return;
                }
                //tao 1 doi tuong Product
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitPrice = decimal.Parse(txtPrice.Text);
                p.UnitsInStock = short.Parse(txtQuantity.Text);
                p.CategoryId = selected_category.CategoryId; // Set the category ID
                bool ret = productService.SaveProduct(p);
                if (ret == true)
                {
                    //Save successfully: Nap lai TreeView + ListView
                    //Nap lai len tree
                    TreeViewItem p_node = new TreeViewItem();
                    p_node.Header = p.ProductName;
                    p_node.Tag = p;
                    cate_item.Items.Add(p_node);
                    //Nap lai ListView
                    var products = productService
                                    .GetProductsByCategory(selected_category.CategoryId);
                    is_loaded_product_completed = false;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_loaded_product_completed = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu mới: "+ex.Message,
                    "Lỗi lưu mới",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // phai xac thuc muon xoa hay khong
            int productId = int.Parse(txtId.Text);
            // tien hanh xoa
            bool ret = productService.DeleteProduct(productId); 
            if (ret == true)
            {
                // Xoa thanh cong: Nap lai TreeView + ListView
                if(selected_product_node != null)
                {
                    // Remove the selected product node from the List view
                    
                }
                else
                {
                    //nap lai Products list cho Cate node va listView
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtId.Focus();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(is_loaded_product_completed == false)
                return; // Prevent loading product details while changing selection
            if(e.AddedItems.Count <= 0) return;
            Product p = e.AddedItems[0] as Product;
            txtId.Text = p.ProductId.ToString();
            txtName.Text = p.ProductName;
            txtPrice.Text = p.UnitPrice.ToString();
            txtQuantity.Text = p.UnitsInStock.ToString();
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            is_loaded_product_completed = false; // Prevent loading products while changing selection
            selected_category = null;
            if (e.NewValue == null)
                return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if(item == null)
                return;
            List<Product> products = null;
            object data = item.Tag;
            if(data == null)
            {
                //User selected a root node -> display all products into list view
                products = productService.GetProducts();
                
            }
            else if(data is Category)
            {
                //User selected Cate node ->
                //display prodcts of that category into list view
                Category category = data as Category;
                selected_category = category; // Store the selected category
                products = productService
                                .GetProductsByCategory(category.CategoryId);    
            }
            else if (data is Product)
            {
                // Display product details on list view
                Product product = data as Product;
                products = new List<Product>(); // Create a list with a single product
                products.Add(product);

                selected_product = product; // Store the selected product
                selected_product_node = item; // Store the selected product node
            }
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
            is_loaded_product_completed = true; // Allow loading products again
        }
    }
}
