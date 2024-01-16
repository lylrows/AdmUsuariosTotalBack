using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace HumanManagement.CrossCutting.Utils
{
    public class Functions
    {

        public static void DataSetToExcel(DataSet ds, string destination)
        {
            using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                var stylesPart = workbook.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();

                
                Font font = new Font();
                font.Append(new Color() { Rgb = "FFFFFF" });
                font.Append(new Bold());

                
                stylesPart.Stylesheet.Fonts = new Fonts();
                stylesPart.Stylesheet.Fonts.Count = 2;
                stylesPart.Stylesheet.Fonts.AppendChild(font);
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });

                
                stylesPart.Stylesheet.Fills = new Fills();

                
                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("005CA8") }; 
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                stylesPart.Stylesheet.Fills.Count = 3;

                
                stylesPart.Stylesheet.Borders = new Borders();
                stylesPart.Stylesheet.Borders.Count = 1;
                stylesPart.Stylesheet.Borders.AppendChild(new Border());

                
                stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                
                stylesPart.Stylesheet.CellFormats = new CellFormats();
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Left });
                stylesPart.Stylesheet.CellFormats.Count = 3;

                stylesPart.Stylesheet.Save();

                uint sheetId = 1;

                foreach (DataTable table in ds.Tables)
                {
                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                    sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                  
                    Columns lstColumns = sheetPart.Worksheet.GetFirstChild<Columns>();
                    Boolean needToInsertColumns = false;
                    if (lstColumns == null)
                    {
                        lstColumns = new Columns();
                        needToInsertColumns = true;
                    }

                    if (needToInsertColumns)
                        sheetPart.Worksheet.InsertAt(lstColumns, 0);

                    lstColumns.Append(new Column() { Min = 1, Max = 1, Width = 40, CustomWidth = true });
                    lstColumns.Append(new Column() { Min = 2, Max = 2, Width = 30, CustomWidth = true });
                    lstColumns.Append(new Column() { Min = 3, Max = 3, Width = 30, CustomWidth = true });
                    lstColumns.Append(new Column() { Min = 4, Max = 4, Width = 30, CustomWidth = true });
                    lstColumns.Append(new Column() { Min = 5, Max = 5, Width = 30, CustomWidth = true });

                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        cell.StyleIndex = 1;
                        headerRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                            cell.StyleIndex = 2;
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }
                }
            }
        }
        public static void DataTableToExcelWithStyle(DataTable table, string destination)
        {
            try
            {
                using (var spreadsheet = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
                {
                    spreadsheet.AddWorkbookPart();
                    spreadsheet.WorkbookPart.Workbook = new Workbook();
                    var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                    wsPart.Worksheet = new Worksheet();

                    var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = new Stylesheet();

                    
                    Font font = new Font();
                    font.Append(new Color() { Rgb = "FFFFFF" });
                    font.Append(new Bold());

                    
                    stylesPart.Stylesheet.Fonts = new Fonts();
                    stylesPart.Stylesheet.Fonts.Count = 2;
                    stylesPart.Stylesheet.Fonts.AppendChild(font);
                    stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });

                    
                    stylesPart.Stylesheet.Fills = new Fills();

                    
                    var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                    solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("005CA8") }; 
                    solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); 
                    stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                    stylesPart.Stylesheet.Fills.Count = 3;

                    
                    stylesPart.Stylesheet.Borders = new Borders();
                    stylesPart.Stylesheet.Borders.Count = 1;
                    stylesPart.Stylesheet.Borders.AppendChild(new Border());

                    
                    stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                    stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                    stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                    
                    stylesPart.Stylesheet.CellFormats = new CellFormats();
                    stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                    stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                    stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Left });
                    
                    

                    stylesPart.Stylesheet.Save();

                    
                    Columns columnExcel = new Columns();
                    int contadorColumn = 1;

                    foreach (DataColumn column in table.Columns)
                    {
                        columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 35, CustomWidth = true });
                        contadorColumn++;
                    }
                    

                    wsPart.Worksheet.Append(columnExcel);

                    var sheetData = wsPart.Worksheet.AppendChild(new SheetData());


                    DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    List<String> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        cell.StyleIndex = 1;
                        headerRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                        foreach (String col in columns)
                        {
                            DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                           
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                            cell.StyleIndex = 2;
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                    }

                    wsPart.Worksheet.Save();


                    var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                    sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Informe de evaluacion" });

                    spreadsheet.WorkbookPart.Workbook.Save();
                }
            }
            catch (Exception ex)
            {
                var error = ex;
            }
        }


        public static void SalaryBandXLS(DataTable table, string destination)
        {
            using (var spreadsheet = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                spreadsheet.AddWorkbookPart();
                spreadsheet.WorkbookPart.Workbook = new Workbook();
                var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                wsPart.Worksheet = new Worksheet();

                var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();


                Font font = new Font();
                font.Append(new Color() { Rgb = "FFFFFF" });
                font.Append(new Bold());


                stylesPart.Stylesheet.Fonts = new Fonts();
                stylesPart.Stylesheet.Fonts.AppendChild(font);
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "FFFFFF" },Bold = new Bold() });
                stylesPart.Stylesheet.Fonts.Count = 3;


                stylesPart.Stylesheet.Fills = new Fills();

    
                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("005CA8") }; 
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var solidCeleste = new PatternFill() { PatternType = PatternValues.Solid };
                solidCeleste.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("99ccff") };
                solidCeleste.BackgroundColor = new BackgroundColor { Indexed = 64 };
                


                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidCeleste});
                stylesPart.Stylesheet.Fills.Count = 4;

                
                stylesPart.Stylesheet.Borders = new Borders();
                stylesPart.Stylesheet.Borders.Count = 1;
                stylesPart.Stylesheet.Borders.AppendChild(new Border());

                
                stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                
                stylesPart.Stylesheet.CellFormats = new CellFormats();
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Left });

                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 0, FillId = 3, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center }); 





                stylesPart.Stylesheet.CellFormats.Count = 3;

                stylesPart.Stylesheet.Save();


                Columns columnExcel = new Columns();
                int contadorColumn = 1;

                #region Configurando ancho de columnas de datos

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 11.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 29.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 38, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 42.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 17.57, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 5.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 11.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 7.29, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.86, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.86, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 4.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 4.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 7.43, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;


                #endregion



                wsPart.Worksheet.Append(columnExcel);

                var sheetData = wsPart.Worksheet.AppendChild(new SheetData());


                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                List<String> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                    cell.StyleIndex = 1;
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        cell.StyleIndex = 2;
                        newRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(newRow);
                }

                wsPart.Worksheet.Save();

                var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Informe de evaluacion" });

                spreadsheet.WorkbookPart.Workbook.Save();

            }
        }

       
        public static void BudgetResumeXLS(DataTable table, string destination,int currentPeriod
                                    , decimal totalPreviousExecAmount2,decimal totalPreviousExecAmount1,decimal totalPreviousExecAmount 
                                    , decimal totalCurrentExecAmount  ,decimal totalPreviousAmount     
                                    , decimal totalCurrentAmount      ,decimal totalVariationPorc      ,decimal totalVariationAmount    
            )
        {
            using (var spreadsheet = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                spreadsheet.AddWorkbookPart();
                spreadsheet.WorkbookPart.Workbook = new Workbook();
                var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                wsPart.Worksheet = new Worksheet();

                var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();

     
                Font font = new Font();
                font.Append(new Color() { Rgb = "FFFFFF" });
                font.Append(new Bold());


                stylesPart.Stylesheet.Fonts = new Fonts();
                stylesPart.Stylesheet.Fonts.Count = 3;
                stylesPart.Stylesheet.Fonts.AppendChild(font);
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } , Bold = new Bold()  });


                stylesPart.Stylesheet.Fills = new Fills();


                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("343a67") }; 
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondogris = new PatternFill() { PatternType = PatternValues.Solid };
                fondogris.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("d9d9d9") }; 
                fondogris.BackgroundColor = new BackgroundColor { Indexed = 64 };


                var fondoazultotal = new PatternFill() { PatternType = PatternValues.Solid };
                fondoazultotal.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("002060") }; 
                fondoazultotal.BackgroundColor = new BackgroundColor { Indexed = 64 };


                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondogris });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondoazultotal });
                stylesPart.Stylesheet.Fills.Count = 5;


                stylesPart.Stylesheet.Borders = new Borders();
                
                stylesPart.Stylesheet.Borders.AppendChild(new Border());
                stylesPart.Stylesheet.Borders.AppendChild(new Border() { LeftBorder= new LeftBorder() { Style=  BorderStyleValues.Thin },RightBorder = new RightBorder() { Style = BorderStyleValues.Thin }
                , BottomBorder = new BottomBorder() { Style = BorderStyleValues.Thin }, TopBorder = new TopBorder() { Style = BorderStyleValues.Thin }
                });
                stylesPart.Stylesheet.Borders.Count = 2;


                stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                stylesPart.Stylesheet.CellFormats = new CellFormats();
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 1, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 3, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 1, FillId = 4, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.Count = 6;

                stylesPart.Stylesheet.Save();


                Columns columnExcel = new Columns();
                int contadorColumn = 1;

                foreach (DataColumn column in table.Columns)
                {
                    columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 35, CustomWidth = true });
                    contadorColumn++;
                }


                wsPart.Worksheet.Append(columnExcel);

                var sheetData = wsPart.Worksheet.AppendChild(new SheetData());


                DocumentFormat.OpenXml.Spreadsheet.Row titleRowWhite1 = new DocumentFormat.OpenXml.Spreadsheet.Row();
         
                sheetData.AppendChild(titleRowWhite1);

                DocumentFormat.OpenXml.Spreadsheet.Row titleRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                DocumentFormat.OpenXml.Spreadsheet.Cell cellTitle = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellTitle.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellTitle.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("RESUMEN: INCREMENTOS SALARIALES - "+ currentPeriod);
                cellTitle.StyleIndex = 4;
                
                titleRow.AppendChild(cellTitle);
                sheetData.AppendChild(titleRow);

                DocumentFormat.OpenXml.Spreadsheet.Row titleRowWhite2 = new DocumentFormat.OpenXml.Spreadsheet.Row();

                sheetData.AppendChild(titleRowWhite2);

                MergeCells mergeCells = new MergeCells();
                mergeCells.Append(new MergeCell() { Reference = new StringValue("A2:I2") });


                wsPart.Worksheet.InsertAfter(mergeCells, wsPart.Worksheet.Elements<SheetData>().First());



                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                List<String> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    
                    if (column.ColumnName != "ISGROUP")
                    {

                        columns.Add(column.ColumnName);
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                        cell.StyleIndex = 1;
                        headerRow.AppendChild(cell);
                    }
                    
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();


                    bool bisgroup = dsrow["ISGROUP"].ToString() == "1" ? true : false;
                    
                    foreach (String col in columns)
                    {

                        

                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        if (col != "AREA")
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        }
                        else
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        }

                        
                        if (bisgroup)
                            cell.StyleIndex = 3;
                        else
                            cell.StyleIndex = 2;
                       
                        newRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(newRow);
                }



                DocumentFormat.OpenXml.Spreadsheet.Row footerRowWhite1 = new DocumentFormat.OpenXml.Spreadsheet.Row();
                sheetData.AppendChild(footerRowWhite1);


                #region Totales

                DocumentFormat.OpenXml.Spreadsheet.Row totalRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                DocumentFormat.OpenXml.Spreadsheet.Cell cellTotalGrupoFe = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellTotalGrupoFe.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellTotalGrupoFe.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("TOTAL GRUPO FE");
                cellTotalGrupoFe.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellPreviousExecAmount2 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellPreviousExecAmount2.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellPreviousExecAmount2.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalPreviousExecAmount2));
                cellPreviousExecAmount2.StyleIndex = 5;


                DocumentFormat.OpenXml.Spreadsheet.Cell cellPreviousExecAmount1 = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellPreviousExecAmount1.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellPreviousExecAmount1.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalPreviousExecAmount1 ));
                cellPreviousExecAmount1.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellPreviousExecAmount = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellPreviousExecAmount.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellPreviousExecAmount.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalPreviousExecAmount) );
                cellPreviousExecAmount.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellCurrentExecAmount = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellCurrentExecAmount.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellCurrentExecAmount.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalCurrentExecAmount));
                cellCurrentExecAmount.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellPreviousAmount = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellPreviousAmount.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellPreviousAmount.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalPreviousAmount));
                cellPreviousAmount.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellCurrentAmount = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellCurrentAmount.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellCurrentAmount.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalCurrentAmount));
                cellCurrentAmount.StyleIndex = 5;


                DocumentFormat.OpenXml.Spreadsheet.Cell cellVariationPorc = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellVariationPorc.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellVariationPorc.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalVariationPorc) + " %");
                cellVariationPorc.StyleIndex = 5;

                DocumentFormat.OpenXml.Spreadsheet.Cell cellVariationAmount = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                cellVariationAmount.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                cellVariationAmount.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(String.Format("{0:n}", totalVariationAmount));
                cellVariationAmount.StyleIndex = 5;


                totalRow.Append(cellTotalGrupoFe,cellPreviousExecAmount2, cellPreviousExecAmount1, cellPreviousExecAmount, cellCurrentExecAmount, cellPreviousAmount, cellCurrentAmount, cellVariationPorc, cellVariationAmount);

                sheetData.AppendChild(totalRow);





                #endregion


                wsPart.Worksheet.Save();



                var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Resumen de Presupuesto" });

                spreadsheet.WorkbookPart.Workbook.Save();

            }
        }
        public static void EconomicConditionXLS(DataTable table, string destination)
        {
            using (var spreadsheet = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                spreadsheet.AddWorkbookPart();
                spreadsheet.WorkbookPart.Workbook = new Workbook();
                var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                wsPart.Worksheet = new Worksheet();

                var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();

                
                Font font = new Font();
                font.Append(new Color() { Rgb = "FFFFFF" });
                font.Append(new Bold());

                
                stylesPart.Stylesheet.Fonts = new Fonts();
                stylesPart.Stylesheet.Fonts.Count = 3;
                stylesPart.Stylesheet.Fonts.AppendChild(font);
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } ,Bold = new Bold() });

                
                stylesPart.Stylesheet.Fills = new Fills();

                
                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("005CA8") }; 
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondogris = new PatternFill() { PatternType = PatternValues.Solid };
                fondogris.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("F2F2F2") }; 
                fondogris.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondoceleste = new PatternFill() { PatternType = PatternValues.Solid };
                fondoceleste.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("DEEAF6") }; 
                fondoceleste.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondoamarillo = new PatternFill() { PatternType = PatternValues.Solid };
                fondoamarillo.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("FFF2CB") }; 
                fondoamarillo.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondoverdeclaro = new PatternFill() { PatternType = PatternValues.Solid };
                fondoverdeclaro.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("E2EEDA") }; 
                fondoverdeclaro.BackgroundColor = new BackgroundColor { Indexed = 64 };
                
                var fondoverdeoscuro = new PatternFill() { PatternType = PatternValues.Solid };
                fondoverdeoscuro.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("A9CD90") }; 
                fondoverdeoscuro.BackgroundColor = new BackgroundColor { Indexed = 64 };




                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondogris });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondoceleste });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondoamarillo });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondoverdeclaro });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondoverdeoscuro });


                stylesPart.Stylesheet.Fills.Count = 8;

                
                stylesPart.Stylesheet.Borders = new Borders();
                stylesPart.Stylesheet.Borders.AppendChild(new Border());
                stylesPart.Stylesheet.Borders.AppendChild(new Border()
                {
                    LeftBorder = new LeftBorder() { Style = BorderStyleValues.Thin },
                    RightBorder = new RightBorder() { Style = BorderStyleValues.Thin }
                ,
                    BottomBorder = new BottomBorder() { Style = BorderStyleValues.Thin },
                    TopBorder = new TopBorder() { Style = BorderStyleValues.Thin }
                });
                stylesPart.Stylesheet.Borders.Count = 2;

                
                stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                
                stylesPart.Stylesheet.CellFormats = new CellFormats();
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 0, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Left });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 3, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center ,WrapText=true ,Vertical= VerticalAlignmentValues.Center});
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { ApplyNumberFormat=true, NumberFormatId=4, FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Right });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 0, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Right }); 
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { ApplyNumberFormat=true, NumberFormatId= 14, FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center }); 

                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 4, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center , Vertical= VerticalAlignmentValues.Center, WrapText= true });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 5, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 6, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 7, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true });


                #region codigos de formatos
                /*
                 ID  FORMAT CODE
                    0   General
                    1   0
                    2   0.00
                    3   #,##0
                    4   #,##0.00
                    9   0%
                    10  0.00%
                    11  0.00E+00
                    12  # ?/?
                    13  # ??/??
                    14  d/m/yyyy
                    15  d-mmm-yy
                    16  d-mmm
                    17  mmm-yy
                    18  h:mm tt
                    19  h:mm:ss tt
                    20  H:mm
                    21  H:mm:ss
                    22  m/d/yyyy H:mm
                    37  #,##0 ;(#,##0)
                    38  #,##0 ;[Red](#,##0)
                    39  #,##0.00;(#,##0.00)
                    40  #,##0.00;[Red](#,##0.00)
                    45  mm:ss
                    46  [h]:mm:ss
                    47  mmss.0
                    48  ##0.0E+0
                    49  @
                 */
                #endregion
                stylesPart.Stylesheet.CellFormats.Count = 9;

                stylesPart.Stylesheet.Save();

                Columns columnExcel = new Columns();
                int contadorColumn = 1;

                #region Configurando ancho de columnas
                


                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.5, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 48.7, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 41.9, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 35, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 24.1, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 17, CustomWidth = true }); contadorColumn++;

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3, CustomWidth = true }); contadorColumn++; 

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3, CustomWidth = true }); contadorColumn++; 

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3, CustomWidth = true }); contadorColumn++; 

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3, CustomWidth = true }); contadorColumn++; 

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 13, CustomWidth = true }); contadorColumn++;



                #endregion

                

                wsPart.Worksheet.Append(columnExcel);

                var sheetData = wsPart.Worksheet.AppendChild(new SheetData());


                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                List<String> columns = new List<string>();

                List<string> columnasstring = new List<string>();
                columnasstring.Add("CÓDIGO");
                columnasstring.Add("COLABORADOR");
                columnasstring.Add("CARGO");
                columnasstring.Add("AREA");
                columnasstring.Add("CONDICIÓN");

                List<string> columnascelestes = new List<string>();

                columnascelestes.Add($"BÁSICO MES");
                columnascelestes.Add($"OTROS FIJOS MES");
                columnascelestes.Add($"VARIABLE MES");
                columnascelestes.Add($"PASI");
                columnascelestes.Add($"OTROS NO REMUNER.");
                columnascelestes.Add($"INGRESO MES");
                columnascelestes.Add($"BONO ANUAL");
                columnascelestes.Add($"COSTO ANUAL");

                List<string> columnasamarillas = new List<string>();


                columnasamarillas.Add($"VARIAC. INGRESO MES");
                columnasamarillas.Add($"VARIAC. COSTO ANUAL");


                List<string> columnasverdeclaro = new List<string>();

                columnasverdeclaro.Add($"BÁSICO MES 2");
                columnasverdeclaro.Add($"OTROS FIJOS MES 2");
                columnasverdeclaro.Add($"VARIABLE MES 2");
                columnasverdeclaro.Add($"PASI 2");
                columnasverdeclaro.Add($"OTROS NO REMUNER. 2");
                columnasverdeclaro.Add($"INGRESO MES 2");
                columnasverdeclaro.Add($"BONO ANUAL 2");
                columnasverdeclaro.Add($"COSTO ANUAL 2");

                List<string> columnasverdeoscuro = new List<string>();

                columnasverdeoscuro.Add($"INCREMENTO");
                columnasverdeoscuro.Add($"INCREMENTO PASI");




                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell newcell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    newcell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.InlineString;
                    if (column.ColumnName.Contains("ESPACIO")) {
                        newcell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("");
                        newcell.StyleIndex = 5;
                    }
                    else
                    {
                        string columnexcel = column.ColumnName.Replace(" 2", "");

                        columnexcel = columnexcel.Replace(" ", "\n");

                        newcell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(columnexcel);
                        newcell.InlineString = new InlineString() { Text = new Text() { Text = columnexcel } };



                        if (columnascelestes.Contains(column.ColumnName))
                        {
                            newcell.StyleIndex = 7;
                        }
                        else
                        {
                            if (columnasamarillas.Contains(column.ColumnName))
                            {
                                newcell.StyleIndex = 8;
                            }
                            else 
                            {
                                if (columnasverdeclaro.Contains(column.ColumnName))
                                {
                                      newcell.StyleIndex = 9;    
                                }
                                else {
                                    if (columnasverdeoscuro.Contains(column.ColumnName))
                                    {
                                          newcell.StyleIndex = 10;    
                                    }
                                    else 
                                    {
                                          newcell.StyleIndex = 3;    
                                    }
                                }
                            }   
                        }
                    }


                    headerRow.AppendChild(newcell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                        
                        
                        if (col.Contains("ESPACIO"))
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue("");
                            cell.StyleIndex = 5;
                            
                        }
                        else
                        {
                            if (columnasstring.Contains(col))
                            {
                                
                                cell.StyleIndex = 2;
                                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                            }
                            else
                            {

                                if (col.Contains("FECHA DE INGRESO"))
                                {
                                    DateTime celdadt = DateTime.Parse(dsrow[col].ToString());
                                    string valueString = celdadt.ToOADate().ToString();
                                    CellValue cellValue = new CellValue(valueString);
                                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                                    cell.StyleIndex = 6; 
                                    cell.Append(cellValue);
                                }
                                else {
                                    
                                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                                    cell.StyleIndex = 4;  
                                }
                            }
                        }
                        


                        newRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(newRow);
                }



                wsPart.Worksheet.Save();



                var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Condicion Economica" });

                spreadsheet.WorkbookPart.Workbook.Save();

            }
        }

        public static void StructureSalaryXLS(DataTable table, string destination)
        {
            using (var spreadsheet = SpreadsheetDocument.Create(destination, SpreadsheetDocumentType.Workbook))
            {
                spreadsheet.AddWorkbookPart();
                spreadsheet.WorkbookPart.Workbook = new Workbook();
                var wsPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                wsPart.Worksheet = new Worksheet();

                var stylesPart = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = new Stylesheet();

                
                Font font = new Font();
                font.Append(new Color() { Rgb = "FFFFFF" });
                font.Append(new Bold());

                
                stylesPart.Stylesheet.Fonts = new Fonts();
                stylesPart.Stylesheet.Fonts.AppendChild(font);
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" } });
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "FFFFFF" }, Bold = new Bold() });
                stylesPart.Stylesheet.Fonts.AppendChild(new Font { Color = new Color() { Rgb = "000000" }, Bold = new Bold() });
                stylesPart.Stylesheet.Fonts.Count = 4;

                
                stylesPart.Stylesheet.Fills = new Fills();

                
                var solidRed = new PatternFill() { PatternType = PatternValues.Solid };
                solidRed.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("005CA8") };
                solidRed.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var solidCeleste = new PatternFill() { PatternType = PatternValues.Solid };
                solidCeleste.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("99ccff") };
                solidCeleste.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondo_semaforo_01 = new PatternFill() { PatternType = PatternValues.Solid };
                fondo_semaforo_01.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("ff7171") };
                fondo_semaforo_01.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondo_semaforo_02 = new PatternFill() { PatternType = PatternValues.Solid };
                fondo_semaforo_02.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("ffdc6d") };
                fondo_semaforo_02.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondo_semaforo_03 = new PatternFill() { PatternType = PatternValues.Solid };
                fondo_semaforo_03.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("92d050") };
                fondo_semaforo_03.BackgroundColor = new BackgroundColor { Indexed = 64 };

                var fondo_semaforo_04 = new PatternFill() { PatternType = PatternValues.Solid };
                fondo_semaforo_04.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("00b0f0") };
                fondo_semaforo_04.BackgroundColor = new BackgroundColor { Indexed = 64 };


                var fondo_semaforo_05 = new PatternFill() { PatternType = PatternValues.Solid };
                fondo_semaforo_05.ForegroundColor = new ForegroundColor { Rgb = HexBinaryValue.FromString("EEF4F8") };
                fondo_semaforo_05.BackgroundColor = new BackgroundColor { Indexed = 64 };

                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.None } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = new PatternFill { PatternType = PatternValues.Gray125 } }); 
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidRed });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = solidCeleste });

                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondo_semaforo_01 });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondo_semaforo_02 });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondo_semaforo_03 });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondo_semaforo_04 });
                stylesPart.Stylesheet.Fills.AppendChild(new Fill { PatternFill = fondo_semaforo_05 });


                stylesPart.Stylesheet.Fills.Count = 9;

                
                stylesPart.Stylesheet.Borders = new Borders();
                stylesPart.Stylesheet.Borders.AppendChild(new Border());
                stylesPart.Stylesheet.Borders.AppendChild(new Border()
                {
                    LeftBorder = new LeftBorder() { Style = BorderStyleValues.Thin },
                    RightBorder = new RightBorder() { Style = BorderStyleValues.Thin }
                ,
                    BottomBorder = new BottomBorder() { Style = BorderStyleValues.Thin },
                    TopBorder = new TopBorder() { Style = BorderStyleValues.Thin }
                });
                stylesPart.Stylesheet.Borders.Count = 2;

                
                stylesPart.Stylesheet.CellStyleFormats = new CellStyleFormats();
                stylesPart.Stylesheet.CellStyleFormats.Count = 1;
                stylesPart.Stylesheet.CellStyleFormats.AppendChild(new CellFormat());

                
                stylesPart.Stylesheet.CellFormats = new CellFormats();
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat());
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 0, BorderId = 1, FillId = 2, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Left });

                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 2, BorderId = 1, FillId = 3, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center }); 
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { ApplyNumberFormat = true, NumberFormatId = 14, FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center }); 
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { ApplyNumberFormat = true, NumberFormatId = 4, FormatId = 0, FontId = 1, BorderId = 1, FillId = 0, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Right }); 

                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 3, BorderId = 1, FillId = 4, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 3, BorderId = 1, FillId = 5, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 3, BorderId = 1, FillId = 6, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 3, BorderId = 1, FillId = 7, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                stylesPart.Stylesheet.CellFormats.AppendChild(new CellFormat { FormatId = 0, FontId = 3, BorderId = 1, FillId = 8, ApplyFill = true }).AppendChild(new Alignment { Horizontal = HorizontalAlignmentValues.Center });
                




                stylesPart.Stylesheet.CellFormats.Count = 11;

                stylesPart.Stylesheet.Save();

                List<string> columnasstring = new List<string>();
                List<string> columnasfecha = new List<string>();
                List<string> columnasmonto = new List<string>();
                List<string> columnassemaforos = new List<string>();



                columnasstring.Add("Código");
                columnasstring.Add("Nombre");
                columnasstring.Add("Cargo");
                columnasstring.Add("Área");
                columnasstring.Add("Categoría");
                columnasfecha.Add("Fecha Ingreso");
                columnasstring.Add("Años de Servicio");
                columnasmonto.Add("Sueldo Básico");
                columnasmonto.Add("PASI");
                
                columnasmonto.Add("PROMEDIO DE INGRESOS VARIABLES");
                columnasmonto.Add("OTROS INGRESOS NO REMUNERATIVOS");
                columnasmonto.Add("TOTAL SUELDO ");
                columnasmonto.Add("Incremento Básico");
                columnasmonto.Add("Incremento de PASI");
                columnasmonto.Add("Incremento de Ing. No Remun.");
                columnasmonto.Add("SUELDO PARA BANDA");
                columnasmonto.Add("Total Nuevos Ingresos ");
                
                columnasstring.Add("Estado en Banda");
                columnasmonto.Add("Mínimo S/");
                columnasmonto.Add("Medio S/");
                columnasmonto.Add("Máximo S/");
                columnasmonto.Add("PER BANDA %");
                columnassemaforos.Add("Banda1");
                columnassemaforos.Add("Banda2");
                columnassemaforos.Add("Banda3");
                columnassemaforos.Add("Banda4");
                columnassemaforos.Add("Banda5");
                columnassemaforos.Add("Banda6");
                columnassemaforos.Add("Banda7");
                columnassemaforos.Add("Banda8");
                columnassemaforos.Add("Banda9");
                columnassemaforos.Add("Banda10");
                columnassemaforos.Add("Banda11");
                columnassemaforos.Add("Banda12");
                columnassemaforos.Add("Banda13");
                columnassemaforos.Add("Banda14");
                columnassemaforos.Add("Banda15");
                columnassemaforos.Add("Banda16");
                columnassemaforos.Add("Banda17");
                columnassemaforos.Add("Banda18");
                columnassemaforos.Add("Banda19");
                columnassemaforos.Add("Banda20");
                columnassemaforos.Add("Banda21");
                columnassemaforos.Add("Banda22");



                
                Columns columnExcel = new Columns();
                int contadorColumn = 1;

                #region Configurando ancho de columnas de datos

                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 11.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 29.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 38, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 42.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 17.57, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 5.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 11.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 7.29, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.86, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.86, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 10.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 6, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 4.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 4.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 12.71, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;
                columnExcel.Append(new Column() { Min = Convert.ToUInt32(contadorColumn), Max = Convert.ToUInt32(contadorColumn), Width = 3.14, CustomWidth = true }); contadorColumn++;


                #endregion


                wsPart.Worksheet.Append(columnExcel);

                var sheetData = wsPart.Worksheet.AppendChild(new SheetData());


                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                List<String> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                    cell.StyleIndex = 1;
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();


                        if (columnasfecha.Contains(col))
                        {
                            
                            DateTime celdadt = DateTime.Parse(dsrow[col].ToString());
                            string valueString = celdadt.ToOADate().ToString();
                            CellValue cellValue = new CellValue(valueString);
                            cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                            cell.StyleIndex = 4;
                            cell.Append(cellValue);
                        }
                        else if (columnasmonto.Contains(col))
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                            cell.StyleIndex = 5;
                        }
                        else if (columnasstring.Contains(col))
                        {
                            
                            cell.StyleIndex = 2;
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        }
                        else if (col.Contains("SEMAFORO DE ALERTA"))
                        {
                            string valorsemaforo = dsrow[col].ToString();

                            if (valorsemaforo == "0.1")
                            {
                                cell.StyleIndex = 6;
                            }
                            else if (valorsemaforo == "0.2")
                            {
                                cell.StyleIndex = 7;
                            }
                            else if (valorsemaforo == "0.3")
                            {
                                cell.StyleIndex = 8;
                            }
                            else if (valorsemaforo == "0.4")
                            {
                                cell.StyleIndex = 9;
                            }
                            else
                            {
                                cell.StyleIndex = 10;
                            }
                            
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(valorsemaforo);
                        }
                        else if (columnassemaforos.Contains(col)) {
                            cell.StyleIndex = 10;
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        }
                        else
                        {
                            
                            cell.StyleIndex = 2;
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                            cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString());
                        }



                        newRow.AppendChild(cell);

                    }
                    sheetData.AppendChild(newRow);
                }

                wsPart.Worksheet.Save();

                var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
                sheets.AppendChild(new Sheet() { Id = spreadsheet.WorkbookPart.GetIdOfPart(wsPart), SheetId = 1, Name = "Informe de evaluacion" });

                spreadsheet.WorkbookPart.Workbook.Save();

            }
        }



        public static void AddToCell(SheetData sheetData, UInt32Value styleIndex, UInt32 uint32rowIndex, string strColumnName, DocumentFormat.OpenXml.EnumValue<CellValues> CellDataType, string strCellValue)
        {
            Row row = new Row() { RowIndex = uint32rowIndex };
            Cell cell = new Cell();

            cell = new Cell() { StyleIndex = styleIndex };
            cell.CellReference = strColumnName + row.RowIndex.ToString();
            cell.DataType = CellDataType;
            cell.CellValue = new CellValue(strCellValue);
            row.AppendChild(cell);

            sheetData.Append(row);
        }



        public static void ReadExcel(string path, DataSet ds)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;

                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    Worksheet sheet = worksheetPart.Worksheet;

                    var cells = sheet.Descendants<Cell>();
                    var rows = sheet.Descendants<Row>();

                    Console.WriteLine("Row count = {0}", rows.LongCount());
                    Console.WriteLine("Cell count = {0}", cells.LongCount());

                    
                    foreach (Cell cell in cells)
                    {
                        if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                        {
                            int ssid = int.Parse(cell.CellValue.Text);
                            string str = sst.ChildElements[ssid].InnerText;
                            Console.WriteLine("Shared string {0}: {1}", ssid, str);
                        }
                        else if (cell.CellValue != null)
                        {
                            Console.WriteLine("Cell contents: {0}", cell.CellValue.Text);
                        }
                    }

                    
                    foreach (Row row in rows)
                    {
                        foreach (Cell c in row.Elements<Cell>())
                        {
                            if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                            {
                                int ssid = int.Parse(c.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                Console.WriteLine("Shared string {0}: {1}", ssid, str);
                            }
                            else if (c.CellValue != null)
                            {
                                Console.WriteLine("Cell contents: {0}", c.CellValue.Text);
                            }
                        }
                    }
                }
            }
        }

        public static string MonthByDescription(string descriptionMonth)
        {
            string _month = string.Empty;
            switch(descriptionMonth.ToUpper().Trim())
            {
                case "ENERO":
                    _month = "01";
                    break;
                case "FEBRERO":
                    _month = "02";
                    break;
                case "MARZO":
                    _month = "03";
                    break;
                case "ABRIL":
                    _month = "04";
                    break;
                case "MAYO":
                    _month = "05";
                    break;
                case "JUNIO":
                    _month = "06";
                    break;
                case "JULIO":
                    _month = "07";
                    break;
                case "AGOSTO":
                    _month = "08";
                    break;
                case "SETIEMBRE":
                    _month = "09";
                    break;
                case "SEPTIEMBRE":
                    _month = "09";
                    break;
                case "OCTUBRE":
                    _month = "10";
                    break;
                case "NOVIEMBRE":
                    _month = "11";
                    break;
                case "DICIEMBRE":
                    _month = "12";
                    break;
            }
            return _month;
        }

        public static string CleanBase64File(string base64String)
        {
            base64String = base64String.Replace("data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,", "");
            base64String = base64String.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", "");
            base64String = base64String.Replace("data:application/pdf;base64,", "");
            base64String = base64String.Replace("data:image/jpeg;base64,", "");
            base64String = base64String.Replace("data:image/png;base64,", "");
            base64String = base64String.Replace("data:application/vnd.ms-excel;base64,", "");
            return base64String;
        }
    }
}
