using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for AdditionalTask1.xaml
    /// </summary>
    public partial class AdditionalTask1 : Window
    {
        public AdditionalTask1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            table.Columns.Add(new TableColumn { Width = new GridLength(200) });
            table.Columns.Add(new TableColumn { Width = new GridLength(200) });
            table.Columns.Add(new TableColumn { Width = new GridLength(200) });

            TableRowGroup contentTableRowGroup = new TableRowGroup();

            var dataTypes = new[]
            {
                new { Name = "int", Range = "-2,147,483,648 до 2,147,483,647", Size = "4 байта" },
                new { Name = "double", Range = "±5.0 × 10^−324 до ±1.7 × 10^308", Size = "8 байт" },
                new { Name = "bool", Range = "true или false", Size = "1 байт" },
                new { Name = "char", Range = "0 до 65,535 (символ Unicode)", Size = "2 байта" },
                new { Name = "decimal", Range = "±1.0 × 10^−28 до ±7.9 × 10^28", Size = "16 байт" },
                new { Name = "float", Range = "±1.5 × 10^−45 до ±3.4 × 10^38", Size = "4 байта" }
            };

            foreach (var dataType in dataTypes)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell(new Paragraph(new Run(dataType.Name))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(dataType.Range))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(dataType.Size))));
                contentTableRowGroup.Rows.Add(row);
            }

            table.RowGroups.Add(contentTableRowGroup);
        }
    }
}
