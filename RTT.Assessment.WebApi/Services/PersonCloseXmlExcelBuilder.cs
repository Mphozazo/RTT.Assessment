using ClosedXML.Excel;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Application.Features.Contact.Queries;
using RTT.Assessment.Application.Features.Person.Queries;
using RTT.Assessment.Application.Features.Reports;
using RTT.Assessment.WebApi.Contracts;

namespace RTT.Assessment.WebApi.Services
{
    public class PersonCloseXmlExcelBuilder : IPersonExcelBuilder
    {
        private static readonly XLColor HeaderBackground = XLColor.FromHtml("#2F5597");

        public byte[] Build(PersonReportDto report)
        {
            try
            {
                using var workbook = new XLWorkbook();

                BuildPersonSheet(workbook, report.personDto);
                BuildAddressSheet(workbook, report.addressDtos);
                BuildContactSheet(workbook, report.contactDtos);

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        #region Person Sheet
        private static void BuildPersonSheet(XLWorkbook workbook, PersonDto? person)
        {
            var ws = workbook.Worksheets.Add("Person");

            if (person == null)
            {
                ws.Cell(1, 1).SetValue("No data");
                return;
            }

            var fields = new (string Label, Action<IXLCell> Write)[]
            {
            ("Id",            c => c.SetValue(person.Id)),
            ("Name",          c => c.SetValue(person.Name ?? "")),
            ("Surname",       c => c.SetValue(person.Surname ?? "")),
            ("Age",           c => c.SetValue(person.Age)),
            ("Date of Birth", c =>
            {
                c.SetValue(person.DOB.ToDateTime(TimeOnly.MinValue));
                c.Style.DateFormat.Format = "yyyy-MM-dd";
            }),
            };

            for (var i = 0; i < fields.Length; i++)
            {
                var row = i + 1;

                var label = ws.Cell(row, 1);
                label.SetValue(fields[i].Label);
                label.Style.Font.Bold = true;
                label.Style.Fill.BackgroundColor = XLColor.LightGray;

                var value = ws.Cell(row, 2);
                fields[i].Write(value);
                value.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            }

            ws.Columns().AdjustToContents();
        }
        #endregion

        #region Address Sheet
        private static void BuildAddressSheet(XLWorkbook workbook, IEnumerable<Application.Features.Address.Queries.AddressDto>? addresses)
        {
            var ws = workbook.Worksheets.Add("Addresses");
            var list = addresses?.ToList() ?? new List<Application.Features.Address.Queries.AddressDto>();

            string[] headers =
            {
            "Id", "Person Id", "Address Type", "Street",
            "City", "Province", "Postal Code", "Country"
        };

            WriteHeaders(ws, headers);

            // Postal Code (column 7) stays text so leading zeros survive
            ws.Column(7).Style.NumberFormat.Format = "@";

            for (var i = 0; i < list.Count; i++)
            {
                var a = list[i];
                var row = i + 2;

                ws.Cell(row, 1).SetValue(a.Id);
                ws.Cell(row, 2).SetValue(a.PersonId);
                ws.Cell(row, 3).SetValue(a.AddressType.ToString());
                ws.Cell(row, 4).SetValue(a.Street ?? "");
                ws.Cell(row, 5).SetValue(a.City ?? "");
                ws.Cell(row, 6).SetValue(a.Province ?? "");
                ws.Cell(row, 7).SetValue(a.PostalCode ?? "");
                ws.Cell(row, 8).SetValue(a.Country ?? "");
            }

            FinishTableSheet(ws, list.Count, headers.Length, "No addresses");
        }

        #endregion

        #region Contact Sheet 
        private static void BuildContactSheet(XLWorkbook workbook, IEnumerable<Application.Features.Contact.Queries.ContactDto>? contacts)
        {
            var ws = workbook.Worksheets.Add("Contacts");
            var list = contacts?.ToList() ?? new List<Application.Features.Contact.Queries.ContactDto>();

            string[] headers = { "Id", "Person Id", "Email", "Phone Number", "Cell Number" };

            WriteHeaders(ws, headers);

            // Phone (4) and Cell (5) stay text so leading zeros survive
            ws.Column(4).Style.NumberFormat.Format = "@";
            ws.Column(5).Style.NumberFormat.Format = "@";

            for (var i = 0; i < list.Count; i++)
            {
                var c = list[i];
                var row = i + 2;

                ws.Cell(row, 1).SetValue(c.Id);
                ws.Cell(row, 2).SetValue(c.PersonId);
                ws.Cell(row, 3).SetValue(c.Email ?? "");
                ws.Cell(row, 4).SetValue(c.PhoneNumber ?? "");
                ws.Cell(row, 5).SetValue(c.CellNumber ?? "");
            }

            FinishTableSheet(ws, list.Count, headers.Length, "No contacts");
        }
        #endregion

        #region Helpers
        private static void WriteHeaders(IXLWorksheet ws, string[] headers)
        {
            for (var i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.SetValue(headers[i]);
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = HeaderBackground;
            }
        }

        private static void FinishTableSheet(IXLWorksheet ws, int rowCount, int columnCount, string emptyMessage)
        {
            if (rowCount == 0)
            {
                ws.Cell(2, 1).SetValue(emptyMessage);
            }
            else
            {
                ws.Range(1, 1, rowCount + 1, columnCount).SetAutoFilter();
            }

            ws.SheetView.FreezeRows(1);
            ws.Columns().AdjustToContents();
        }
        #endregion
    }
}
