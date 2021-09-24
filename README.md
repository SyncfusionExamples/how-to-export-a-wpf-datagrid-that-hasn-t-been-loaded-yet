# How to export a WPF DataGrid (SfDataGrid) that hasn't been loaded yet?

THis sample show cases how to export a [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) that hasn't been loaded yet?

# About the sample

You can export the datagrid to excel by using the [ExportToExcel](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGridConverter.WPF~Syncfusion.UI.Xaml.Grid.Converter.GridExcelExportExtension~ExportToExcel.html) method in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid). You can also export the datagrid before it’s loading (AutoGenerateColumns = True/False) by using the [DataGrid.ApplyTemplate](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelement.applytemplate?view=netcore-3.1#:~:text=ApplyTemplate%20is%20called%20on%20every,or%20by%20the%20layout%20system.) method.

```c#
private static void OnExecuteExportToExcel(object sender, ExecutedRoutedEventArgs args)
{
    var dataGrid = args.Source as SfDataGrid;
    EccelOptionsConverter ExcelOption=new EccelOptionsConverter();
    if (dataGrid == null) return;
    try
    {
        var options = args.Parameter as ExcelExportingOptions;
        ICollectionViewAdv view;
        ExcelEngine excelEngine = new ExcelEngine();
                
        options.ExcelVersion = ExcelVersion.Excel2010;
        options.ExportingEventHandler = ExportingHandler;
        if (!ExcelOption.isCustomized)
            options.CellsExportingEventHandler = CellExportingHandler;
        else
            options.CellsExportingEventHandler = CustomizeCellExportingHandler;

        dataGrid.ApplyTemplate();

        excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);

        var workBook = excelEngine.Excel.Workbooks[0];

        SaveFileDialog sfd = new SaveFileDialog
        {
            FilterIndex = 2,
            Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx",
            FileName = "Book1"
        };

        if (sfd.ShowDialog() == true)
        {
            using (Stream stream = sfd.OpenFile())
            {
                if (sfd.FilterIndex == 1)
                    workBook.Version = ExcelVersion.Excel97to2003;
                else
                    workBook.Version = ExcelVersion.Excel2010;
                workBook.SaveAs(stream);                        
            }

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                System.Diagnostics.Process.Start(sfd.FileName);
            } 
        }                                              
    }
    catch (Exception)
    {

    }
}
```

KB article - [How to export a WPF DataGrid (SfDataGrid) that hasn't been loaded yet?](https://www.syncfusion.com/kb/11915/how-to-export-wpf-datagrid-sfdatagrid-to-excel-that-hasnt-loaded)

## Requirements to run the demo
 Visual Studio 2015 and above versions
