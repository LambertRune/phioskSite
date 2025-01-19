using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Services.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace PhioskSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestPdfController : Controller
    {
        
        private readonly IOrderDBService _orderDBService;
        private readonly IDBService<User> _userService;

        public QuestPdfController(IOrderDBService orderDBService, IDBService<User> userService)
        {
            _orderDBService = orderDBService;            
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GeneratePdf")]
        public async Task<IActionResult> GeneratePdf(int orderId)
        {
            // Haal de ordergegevens op
            var order = await _orderDBService.GetOrderWithDetailsAsync(orderId);

            if (order == null)
            {
                return NotFound($"Order with ID {orderId} not found.");
            }

            // Haal de gerelateerde gegevens op
            var user = order.User;
            var phones = order.Phones;
            var address = user.Address;

            if (user == null)
            {
                return NotFound($"User for order {orderId} not found.");
            }

            if (phones == null || !phones.Any())
            {
                return NotFound($"Phones for order {orderId} not found.");
            }

            // Maak het PDF-document
            var document = CreateDocument(order, user, phones, address);

            // Genereer de PDF
            var pdf = document.GeneratePdf();

            // Retourneer de gegenereerde PDF als bestand voor download
            return File(pdf, "application/pdf", $"Invoice_{orderId}.pdf");
        }





        QuestPDF.Infrastructure.IDocument CreateDocument(Order order, User? user, ICollection<Phone>? phones, Address? address)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10).FontColor(Colors.Black));
                    page.MarginVertical(0);
                    page.MarginHorizontal(20);

                    // Header Section
                    page.Header()
                        .Height(150)
                        .Row(row =>
                        {
                            // Logo and Company Info
                            row.RelativeItem().PaddingTop(20).AlignMiddle().MaxHeight(40)
                                .Column(column =>
                                {

                                    column.Item().Image("C:\\Users\\Pc_Rune\\Documents\\GitHub\\phioskSite\\phioskSite\\wwwroot\\Images\\PdfGenerator\\Logo.png").FitArea();
                                });

                            // Invoice Title
                            row.RelativeItem()
                                .Padding(20)
                                .AlignRight()
                                .AlignBottom()
                                .Column(column =>
                                {
                                    column.Item().Text("FACTUUR").FontSize(40).ExtraBold().FontColor("#bdc9c7");
                                    column.Item().Text($"Factuur Nr: {order.Id}").FontSize(10).FontColor(Colors.Grey.Darken2);
                                    column.Item().Text($"Factuurdatum: {order.InvoiceDate}").FontSize(10).FontColor(Colors.Grey.Darken2);
                                    column.Item().Text($"Vervaldatum: {order.ExpireDate}").FontSize(10).FontColor(Colors.Grey.Darken2);
                                });
                        });

                    // Content Section
                    page.Content().PaddingVertical(20).Column(column =>
                    {
                        // Client and Contact Information
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(info =>
                            {
                                info.Item().Text("FACTUREREN AAN").Bold();
                                info.Item().Text($"{user?.FirstName} {user?.LastName}");
                                if (address != null)
                                {
                                    info.Item().Text("straatnaam nr");                                
                                    info.Item().Text($"{address?.PostalCode} {address?.City}, {address?.Country}");
                                }
                                
                            });

                            row.RelativeItem().Column(info =>
                            {
                                info.Item().AlignRight().Text(" ");
                            });
                        });

                        column.Spacing(20);

                        // Product Table
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.ConstantColumn(50);
                                columns.ConstantColumn(70);
                                columns.ConstantColumn(50);
                                columns.ConstantColumn(50);
                            });

                            // Table Header
                            table.Header(header =>
                            {
                                header.Cell().Background("bdc9c7").Padding(5).Text("OMSCHRIJVING").AlignCenter().Bold();
                                header.Cell().Background("bdc9c7").Padding(5).Text("AANTAL").AlignCenter().Bold();
                                header.Cell().Background("bdc9c7").Padding(5).Text("STUKPRIJS").AlignCenter().Bold();
                                header.Cell().Background("bdc9c7").Padding(5).Text("TOTAAL").AlignCenter().Bold();
                                header.Cell().Background("bdc9c7").Padding(5).Text("BTW").AlignCenter().Bold();
                            });

                            foreach (var phone in phones)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5).Text($"{phone.Description}");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5).Text("1").AlignCenter();
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5).Text(phone.Price.ToString("F2")).AlignCenter();
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5).Text(phone.Price.ToString("F2")).AlignCenter();  // Aangepast
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5).Text("21%").AlignCenter();
                            }

                        });

                        column.Spacing(20);

                        // Summary Section
                        column.Item().Height(100).Column(summary =>
                        {
                            summary.Item().Row(row =>
                            {
                                row.ConstantItem(280).Border(1).Padding(10).Row(payment =>
                                {

                                    payment.RelativeItem(3).Column(column =>
                                    {
                                        column.Spacing(10);
                                        column.Item().Text("Eenvoudig online betalen").Bold();
                                        column.Item().Text(text =>
                                        {
                                            text.Span("1. ").Bold();
                                            text.Span("Scan de QR code met je telefoon");
                                        });
                                        column.Item().Text(text =>
                                        {
                                            text.Span("2. ").Bold();
                                            text.Span("Betaal veilig via je bank");
                                        });
                                    });
                                    payment.RelativeItem(2).AlignRight().Image("C:\\Users\\Pc_Rune\\Documents\\GitHub\\phioskSite\\phioskSite\\wwwroot\\Images\\PdfGenerator\\googleQRcodes.png").FitHeight();
                                });
                                row.RelativeItem(2);
                                row.RelativeItem(2).Column(summary =>
                                {

                                    summary.Item().Row(row =>
                                    {
                                        row.RelativeItem().Text("TOTAAL");
                                        row.ConstantItem(70).AlignRight().Text("00.00");
                                    });
                                    summary.Item().BorderBottom(1).PaddingBottom(4).Row(row =>
                                    {
                                        row.RelativeItem().Text("BTW");
                                        row.ConstantItem(70).AlignRight().Text("00.00");
                                    });
                                    summary.Item().PaddingTop(4).Row(row =>
                                    {
                                        row.RelativeItem().Text("Totaalbedrag").Bold();
                                        row.ConstantItem(70).AlignRight().Text("00.00").Bold();
                                    });
                                });

                            });


                        });

                        column.Spacing(20);





                    });

                    // Footer Section
                    page.Footer()
                        .Height(100).BorderTop(1).PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem(1).Column(column =>
                            {
                                column.Item().Text("Phiosk").Bold();
                                column.Item().Text("Bruggestraat 44");
                                column.Item().Text("8750 Zwevezele, België");
                                column.Item().Text("BTW-nr:[BTW-nr]");

                            });
                            row.RelativeItem(2).Column(column =>
                            {

                                column.Item().Text("Betalingsmethode naar keuze").Bold();
                                column.Item().Text("bekijk ons privacybeleid op phiosk.be.");



                            });



                            row.RelativeItem().AlignRight()
                    .Text(text =>
                    {
                        text.Span("Pagina ");
                        text.CurrentPageNumber();
                        text.Span(" van ");
                        text.TotalPages();
                    });
                        });


                });
            });
        }
    }
}
