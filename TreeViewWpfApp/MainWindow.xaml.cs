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

using TreeViewWpfApp.models;

namespace TreeViewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Category> categories 
            = SampleDataset.GenerateDataset();
        public MainWindow()
        {
            InitializeComponent();
            DisplayDatasetOnTreeView();
        }

        private void DisplayDatasetOnTreeView()
        {
            //delete old datas on TreeView
            tvCategory.Items.Clear();
            //Create root (or not)
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cái Mép";
            tvCategory.Items.Add(root);

            //loop 1 for inserting categories
            foreach(KeyValuePair<int, Category> item in categories)
            {
                Category cate = item.Value;
                //Create node for category
                TreeViewItem cate_Node = new TreeViewItem();
                cate_Node.Header = cate;
                //Add node to root
                root.Items.Add(cate_Node);
                //loop 2 for inserting products
                foreach (KeyValuePair<int,Product> subitem in cate.Products)
                {
                    Product product = subitem.Value;
                    //Create node for product
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product;
                    //Add node to category node
                    cate_Node.Items.Add(product_node);
                }
            }
        }
    }
}