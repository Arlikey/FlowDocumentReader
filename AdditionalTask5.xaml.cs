using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdditionalTask5.xaml
    /// </summary>
    public partial class AdditionalTask5 : Window
    {
        private double[] fontSizes = { 12, 16, 18, 20, 28, 36 };
        private string[] fontColors = { "Black", "Blue", "Green", "Orange"};
        public AdditionalTask5()
        {
            InitializeComponent();
            startSelectionTextBox.TextChanged += SelectionTextBox_TextChanged;
            endSelectionTextBox.TextChanged += SelectionTextBox_TextChanged;
            fontSizeComboBox.ItemsSource = fontSizes;
            fontSizeComboBox.SelectedIndex = 0;
            fontColorComboBox.ItemsSource = fontColors;
            fontColorComboBox.SelectedIndex = 0;
        }
        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            userTextBox.Selection.Select(userTextBox.Document.ContentStart, userTextBox.Document.ContentStart);
            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            userTextBox.Selection.Select(userTextBox.Document.ContentStart, userTextBox.Document.ContentStart);
            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            userTextBox.Selection.Select(userTextBox.Document.ContentStart, userTextBox.Document.ContentStart);
            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            selectedText.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
        }
        private void SelectText()
        {
            TextRange fullRange = new TextRange(userTextBox.Document.ContentStart, userTextBox.Document.ContentEnd);

            TextPointer start = userTextBox.Document.ContentStart.GetPositionAtOffset(int.Parse(startSelectionTextBox.Text), LogicalDirection.Forward);
            TextPointer end = userTextBox.Document.ContentStart.GetPositionAtOffset(int.Parse(endSelectionTextBox.Text) + 1, LogicalDirection.Forward);

            userTextBox.Selection.Select(start, end);
        }

        private void SelectionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
            int startIndex = int.Parse(startSelectionTextBox.Text);
            int endIndex = int.Parse(endSelectionTextBox.Text);

            TextRange textRange = new TextRange(userTextBox.Document.ContentStart, userTextBox.Document.ContentEnd);
            string text = textRange.Text;

            if (startIndex > endIndex || startIndex >= text.Length-2 || endIndex >= text.Length-2)
            {
                buttonsToolBar.IsEnabled = false;
            }
            else
            {
                buttonsToolBar.IsEnabled = true;
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(FontSizeProperty, fontSizeComboBox.SelectedValue);
        }

        private void fontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString(fontColorComboBox.SelectedValue.ToString());
            Brush brush = new SolidColorBrush(color);

            SelectText();
            TextSelection selectedText = userTextBox.Selection;
            selectedText.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
        }
    }
}
