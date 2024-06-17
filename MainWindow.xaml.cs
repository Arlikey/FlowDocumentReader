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

namespace FlowDocumentReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(productTextBox.Text))
            {
                MessageBox.Show("Empty string", "Invalid data");
                return;
            }
            productListBox.ListItems.Add(new ListItem(new Paragraph(new Run(productTextBox.Text))));
            productTextBox.Clear();
        }
    }
}