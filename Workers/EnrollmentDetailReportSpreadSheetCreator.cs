using CourseReportEmailer.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace CourseReportEmailer.Workers
{
    class EnrollmentDetailReportSpreadSheetCreator
    {
        public void Create(string fileName, IList<EnrollmentReportDetailModel> enrollmentModels)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                var Json = JsonConvert.SerializeObject(enrollmentModels);
                DataTable enrollmentsTable = (DataTable)JsonConvert.DeserializeObject(Json, typeof(DataTable));

                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheetList = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                Sheet singleSheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Report Sheet"
                };

                sheetList.Append(singleSheet);

                Row excelTitleRow = new Row();

                foreach (DataColumn tableColumn in enrollmentsTable.Columns)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(tableColumn.ColumnName);
                    excelTitleRow.Append(cell);
                }

                sheetData.AppendChild(excelTitleRow);

                foreach (DataRow dataRow in enrollmentsTable.Rows)
                {
                    Row excelNewRow = new Row();
                    foreach (DataColumn dataColumn in enrollmentsTable.Columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dataRow[dataColumn.ColumnName].ToString());
                        excelNewRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(excelNewRow);
                }

                workbookPart.Workbook.Save();
            }
        }
    }
}
