using System;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace WindowCapture
{
    /// <summary>
    /// Excel操作クラス
    /// </summary>
    public class ExcelAction
    {
        private Workbook workbook;

        public void createExcel()
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;
            workbook = excelApp.Workbooks.Add();
            Worksheet sheet = (Worksheet)workbook.Worksheets.Add();
            sheet.Cells[1, 1] = "aaa";
            workbook.SaveAs("D:\\aaa.xlsx");
            workbook.Close();
        }


        public void pastImage()
        {

        }


    }
}
