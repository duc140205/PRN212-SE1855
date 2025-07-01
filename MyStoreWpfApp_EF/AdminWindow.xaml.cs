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
            if(category == null) 
                return;
            LoadProductIntoListView(category);
        }

        private void LoadProductIntoListView(Category category)
        {
            var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }
    }
}
