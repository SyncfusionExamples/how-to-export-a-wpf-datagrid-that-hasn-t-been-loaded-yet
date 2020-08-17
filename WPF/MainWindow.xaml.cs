#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Grid.Converter;

namespace ExportingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in new[] { dataGrid, dataGrid2 })
            {
                var cmd = Commands.ExportToExcel;
                var param = new ExcelExportingOptions
                {
                    AllowOutlining = allowOutlining.IsChecked.Value
                };
                new EccelOptionsConverter().isCustomized = customizeColumns.IsChecked.Value;
                new EccelOptionsConverter().IsCustomizeRow = customizeSelectedRow.IsChecked.Value;

                cmd.Execute(param, item);
            }
        }
    }
}
