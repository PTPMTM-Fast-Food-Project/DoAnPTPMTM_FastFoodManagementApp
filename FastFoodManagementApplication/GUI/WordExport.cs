//using DTO;
//using Microsoft.Office.Interop.Word;
//using Syncfusion.DocIO;
//using Syncfusion.DocIO.DLS;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GUI
//{
//   public  class WordExport
//    {
//        #region ---- Constants & Enum -----

        
//        private const string FILE_BCTK = "BM11";
         

//        #endregion

//        #region --- Member Variables ----

//        private bool _IsPringPriview = false;

//        #endregion

//        #region --- Private medthods ---

         
//        /// PrinPreview the document
//        /// </summary>
//        /// <param name="fileToPrint"></param>
//        private void PrinPriview(string fileToPrint)
//        {
//            object missing = System.Type.Missing;
//            object objFile = fileToPrint;
//            object readOnly = true;
//            object addToRecentOpen = false;

//            // Create  a new Word application           
//            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
//            try
//            {
//                // Create a new file based on our template
//                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Open(ref objFile, ref missing, ref readOnly, ref addToRecentOpen);

//                wordApplication.Options.SaveNormalPrompt = false;

//                if (wordDocument != null)
//                {
//                    // Show print preview
//                    wordApplication.Visible = true;
//                    wordDocument.PrintPreview();
//                    wordDocument.Activate();
//                    //wordDocument.op
//                    while (!_IsPringPriview)
//                    {
//                        wordDocument.ActiveWindow.View.Magnifier = true;
//                        Thread.Sleep(500);
//                    }

//                    wordDocument.Close(ref missing, ref missing, ref missing);
//                    wordDocument = null;
//                }
//            }
//            catch
//            {
//                //I didn't include a default error handler so i'm just throwing the error
//                // throw ex;
//            }
//            finally
//            {
//                // Finally, Close our Word application
//                wordApplication.Quit(ref missing, ref missing, ref missing);
//                wordApplication = null;
//            }
//        }

//        /// <summary>
//        /// Manage WordExport_DocumentBeforeClose
//        /// </summary>
//        /// <param name="Doc"></param>
//        /// <param name="Cancel"></param>
//        private void WordExport_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
//        {
//            _IsPringPriview = false;
//        }

//        /// <summary>
//        /// Merges the specified files to merge.
//        /// </summary>
//        /// <param name="filesToMerge">The files to merge.</param>
//        /// <param name="outputFilename">The output filename.</param>
//        /// <param name="insertPageBreaks">if set to <c>true</c> [insert page breaks].</param>
//        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
//        {
//            string fileTempate = Global.AppPath + Constants.FOLDER_TEMPLATES +
//                                 Constants.CHAR_FLASH + Constants.FILE_NORMAL_DOT;
//            Merge(filesToMerge, outputFilename, insertPageBreaks, fileTempate);
//        }

//        /// <summary>
//        /// A function that merges Microsoft Word Documents that uses a template specified by the user
//        /// </summary>
//        /// <param name="filesToMerge">An array of files that we want to merge</param>
//        /// <param name="outputFilename">The filename of the merged document</param>
//        /// <param name="insertPageBreaks">Set to true if you want to have page breaks inserted after each document</param>
//        /// <param name="documentTemplate">The word document you want to use to serve as the template</param>
//        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks, string documentTemplate)
//        {
//            object defaultTemplate = documentTemplate;
//            object missing = System.Type.Missing;
//            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
//            object outputFile = outputFilename;

//            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
//            Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Add(ref defaultTemplate, ref missing, ref missing, ref missing);
//            Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection; // Khai báo selection

//            if (filesToMerge.Count() == 1)
//                pageBreak = false;

//            int index = 0; // Khai báo biến index

//            try
//            {
//                foreach (string file in filesToMerge)
//                {
//                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);

//                    // Thêm dòng mới sau khi chèn tài liệu
//                    selection.TypeParagraph(); // Thêm dòng mới

//                    if (insertPageBreaks && index != filesToMerge.Length - 1) // Sử dụng filesToMerge.Length
//                    {
//                        selection.InsertBreak(ref pageBreak);
//                    }

//                    index++;
//                }

//                wordDocument.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing,
//                                     ref missing, ref missing, ref missing, ref missing, ref missing,
//                                     ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

//                wordDocument.Close(ref missing, ref missing, ref missing);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                wordApplication.Quit(ref missing, ref missing, ref missing);
//            }
//        }

//        /// <summary>
//        /// Page setup the word document
//        /// </summary>
//        /// <param name="document"></param>
//        private void PageSetup(ref WordDocument document)
//        {
//            foreach (WSection section in document.Sections)
//            {

//                // Setting Page Margins
//                section.PageSetup.Margins.Top = 72f;
//                section.PageSetup.Margins.Bottom = 90f;
//                section.PageSetup.Margins.Left = 72f;
//                section.PageSetup.Margins.Right = 72f;

//                section.PageSetup.HeaderDistance = 1;
//                section.PageSetup.FooterDistance = 1;

//                //Setup page size
//                section.PageSetup.PageSize = PageSize.A4;

//                // Setting the Page Orientation as Portrait or Landscape
//                section.PageSetup.Orientation = PageOrientation.Landscape;
//            }
//        }

//        #endregion

//        public void BCTK(DateTime fromDate, DateTime toDate, List<OrderDTO> dataSource)
//        {
//            #region ===== Core======
//            MemoryStream mStream = null;
//            WordDocument document = null;
//            string fileBoNhiem = string.Empty;

//            // Create currency format
//            CultureInfo vietnam = new CultureInfo(1066);
//            NumberFormatInfo vnfi = vietnam.NumberFormat;
//            vnfi.CurrencySymbol = Constants.VN_UNIT;
//            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
//            vnfi.CurrencyDecimalDigits = 0;

//            // Create Temp Folder if it does not exist
//            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
//            {
//                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
//            }

//            // Delete existing *.doc files
//            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP + Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);
//            foreach (string file in DocFile)
//            {
//                File.Delete(file);
//            }

//            try
//            {
//                // Read template
//                mStream = new MemoryStream(File.ReadAllBytes("BCTK.docx"));
//                document = new WordDocument(mStream);
//                mStream.Close();
//            }
//            catch
//            {
//                return;
//            }

//            fileBoNhiem = Global.AppPath + Constants.FOLDER_TEMP + Constants.CHAR_FLASH + "BCTK" + Constants.FILE_EXT_DOC;

//            #endregion =====  End Core=====

//            #region === Set value =====//III
//            DateTime SysDate = DateTime.Now;

//            // Prepare fields for mail merge
//            var fields = new List<string> { "Ngay", "Thang", "Nam", "OrderId", "OrderDate", "OrderCustomer" };
//            var values = new List<string>();

//            // Add date values
//            values.Add(SysDate.Day.ToString());
//            values.Add(SysDate.Month.ToString());
//            values.Add(SysDate.Year.ToString());

//            // Create a new Word application for the selection
//            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
//            Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Add(); // Tạo tài liệu mới
//            Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection; // Khai báo selection

//            // Iterate through dataSource and add orders
//            foreach (var order in dataSource)
//            {
//                values.Add(order.order_id.ToString()); // Giả sử order_id là long

//                // Kiểm tra kiểu dữ liệu của order_date
//                string formattedDate;
//                if (order.order_date is DateTime dateTime)
//                {
//                    formattedDate = dateTime.ToString("dd/MM/yyyy");
//                }
//                else if (DateTime.TryParse(order.order_date.ToString(), out dateTime)) // Nếu order_date là string
//                {
//                    formattedDate = dateTime.ToString("dd/MM/yyyy");
//                }
//                else
//                {
//                    formattedDate = "N/A"; // Giá trị mặc định nếu không thể chuyển đổi
//                }

//                values.Add(formattedDate);
//                values.Add(order.customer_id.ToString()); // Chuyển customer_id sang string nếu cần

//                // Thêm thông tin vào tài liệu
//                selection.TypeText($"Order ID: {order.order_id}, Order Date: {formattedDate}, Customer ID: {order.customer_id}");
//                selection.TypeParagraph(); // Thêm dòng mới
//            }

//            // Prepare for mail merge
//            document.MailMerge.Execute(fields.ToArray(), values.ToArray());

//            #endregion End Set Value=====

//            #region =====Core=====
//            // Save document to file
//            document.Save(fileBoNhiem, FormatType.Doc);

//            // Close the document after save
//            document.Close();

//            // Print preview the document
//            this.PrinPriview(fileBoNhiem);

//            #endregion =====  End Core=====
//        }


//    }
//}
