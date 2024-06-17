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

namespace FlowDocumentReader
{
    /// <summary>
    /// Interaction logic for AdditionalTask4.xaml
    /// </summary>
    public partial class AdditionalTask4 : Window
    {
        public AdditionalTask4()
        {
            InitializeComponent();
        }

        private void boldTextButton_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox.Selection.Text != "")
            {
                TextSelection selectedText = richTextBox.Selection;
                if (selectedText.GetPropertyValue(FontWeightProperty).Equals(FontWeights.Bold))
                {
                    selectedText.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
                }
                else 
                {
                    selectedText.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
                }
            }
        }
    }
}
