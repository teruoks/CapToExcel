using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace CapToExcel
{
    /// <summary>
    /// Excel操作クラス
    /// </summary>
    public class CreateExcelService
    {
        public void execute(string workPath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbooks books = null;
            Workbook book = null;
            Worksheet sheet = null;
            Shapes shapes = null;

            if (string.IsNullOrEmpty(workPath)) return;
            if (!System.IO.Directory.Exists(workPath)) return;

            try {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                // 非表示でブックを作成
                excelApp.Visible = false;
                // 保存時アラートを出さない
                excelApp.DisplayAlerts = false;
                books = excelApp.Workbooks;
                book = books.Add();
                sheet = (Worksheet)book.Sheets[1];
                shapes = sheet.Shapes;

                string targetFile;
                float nextHeight = 50;
                float spaceHeight = 50;
                
                 for (int i = 1; i <= 100; i++)
                {
                    targetFile = workPath + "\\" + i.ToString("000") + ".bmp";
                    if (System.IO.File.Exists(targetFile)) {
                        // 画像を等倍で追加
                        shapes.AddPicture(targetFile, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, 0,nextHeight + 100, 0, 0);
                        shapes.Item(i).ScaleHeight(1, Microsoft.Office.Core.MsoTriState.msoCTrue);
                        shapes.Item(i).ScaleWidth(1, Microsoft.Office.Core.MsoTriState.msoCTrue);
                        nextHeight += shapes.Item(i).Height + spaceHeight;

                    }
                    else
                    {
                        // 画像なし
                        if (i == 0)
                        {
                            // １枚も無いのでブックを作成しない
                            return;
                        }
                        break;
                    }
                }

                book.SaveAs(System.Windows.Forms.Application.StartupPath + "\\" + "test" + ".xlsx");
            
            } finally {

                // EXCELオブジェクトを確実に開放する
                if (shapes != null)
                {
                    Marshal.FinalReleaseComObject(shapes);
                    shapes = null;
                }
                if (sheet != null)
                {
                    Marshal.ReleaseComObject(sheet);
                    sheet = null;
                }
                if (book != null)
                {
                    book.Close();
                    Marshal.ReleaseComObject(book);
                    book = null;
                }
                if (books != null)
                {
                    books.Close();
                    Marshal.FinalReleaseComObject(books);
                    books = null;
                }
                if (excelApp != null) {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }

                // ガーベージコレクションを強制実行
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

        }

        private void resizeImage() {

        }


    }
}
