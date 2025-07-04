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

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
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
                products = productService
                                .GetProductsByCategory(category.CategoryId);    
            }
            else if (data is Product)
            {
                // Display product details on list view
                Product product = data as Product;
                products = new List<Product>(); // Create a list with a single product
                products.Add(product);
            }
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }
    }
}
