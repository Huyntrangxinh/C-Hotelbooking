using HotelBooking.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;

namespace HotelBooking.Documents
{
    public class ContractDocument : IDocument
    {
        private readonly ReviewViewModel _model;
        private const string CommissionRate = "15%";

        public ContractDocument(ReviewViewModel model)
        {
            _model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Trang ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("HỢP ĐỒNG HỢP TÁC KHÁCH SẠN")
                        .Bold().FontSize(18).AlignCenter();
                    column.Item().Text("HOTEL COOPERATION AGREEMENT")
                        .SemiBold().FontSize(14).AlignCenter();
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Column(column =>
            {
                column.Spacing(25);

                // SỬA LẠI: Áp dụng style sau khi gọi .Text()
                column.Item().Text($"Hợp đồng này được lập ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy} tại Thái Nguyên, Việt Nam, giữa:").FontSize(10).Italic();

                column.Item().Element(c => ComposeSection(c, "BÊN A: CHỦ CƠ SỞ LƯU TRÚ (SAU ĐÂY GỌI LÀ 'KHÁCH SẠN')", table =>
                {
                    table.Cell().Text("Tên pháp nhân:").SemiBold();
                    table.Cell().Text(_model.LegalEntityName ?? "Chưa cung cấp");
                    table.Cell().Text("Địa chỉ đăng ký:").SemiBold();
                    table.Cell().Text(_model.LegalEntityAddress ?? "Chưa cung cấp");
                    table.Cell().Text("Đại diện bởi:").SemiBold();
                    table.Cell().Text($"{_model.SignatoryName} - Chức vụ: {_model.SignatoryPosition}");
                    table.Cell().Text("Email:").SemiBold();
                    table.Cell().Text(_model.SignatoryEmail ?? "Chưa cung cấp");
                }));

                column.Item().Element(c => ComposeSection(c, "BÊN B: BOOKING.COM (SAU ĐÂY GỌI LÀ 'NỀN TẢNG')", table =>
                {
                    table.Cell().Text("Tên công ty:").SemiBold();
                    table.Cell().Text("Booking.com B.V.");
                    table.Cell().Text("Địa chỉ:").SemiBold();
                    table.Cell().Text("Herengracht 597, 1017 CE Amsterdam, Hà Lan");
                }));

                column.Item().Text("Sau đây gọi riêng là 'Bên' và gọi chung là 'Các Bên'. Các Bên đồng ý ký kết Hợp đồng này với các điều khoản và điều kiện sau:").FontSize(10);
                
                // SỬA LẠI: Chuyển .PaddingTop() ra trước .Text()
                column.Item().PaddingTop(10).Text("CÁC ĐIỀU KHOẢN VÀ ĐIỀU KIỆN").Bold().FontSize(14).Underline();

                column.Item().Element(c => ComposeParagraph(c, "Điều 1: Phạm vi hợp tác", "1.1. Bên B đồng ý cung cấp cho Bên A quyền truy cập vào Hệ thống Quản lý của Nền tảng, cho phép Bên A đăng tải thông tin, hình ảnh, giá phòng, tình trạng phòng trống và các chính sách liên quan của Khách sạn để quảng bá và bán dịch vụ lưu trú cho người dùng cuối ('Khách hàng').\n1.2. Bên A hiểu rằng Bên B chỉ hoạt động như một nền tảng trung gian kết nối Khách sạn với Khách hàng và không chịu trách nhiệm về chất lượng dịch vụ tại cơ sở của Bên A."));
                column.Item().Element(c => ComposeParagraph(c, "Điều 2: Nghĩa vụ của Khách sạn (Bên A)", "2.1. Cung cấp thông tin chính xác: Bên A có trách nhiệm đảm bảo mọi thông tin đăng tải lên Nền tảng là chính xác và được cập nhật liên tục.\n2.2. Tôn trọng đặt phòng: Bên A phải tôn trọng tất cả các đặt phòng được thực hiện bởi Khách hàng qua Nền tảng theo đúng thông tin giá và chính sách đã công bố.\n2.3. Đảm bảo giá tốt nhất (Rate Parity): Bên A cam kết rằng giá phòng được công bố trên Nền tảng sẽ không cao hơn giá được công bố trên bất kỳ kênh phân phối trực tuyến nào khác, bao gồm cả website của chính Khách sạn."));
                column.Item().Element(c => ComposeParagraph(c, "Điều 3: Phí hoa hồng và Thanh toán", $"3.1. Bên A đồng ý trả cho Bên B một khoản phí hoa hồng là {CommissionRate} (mười lăm phần trăm) trên tổng giá trị cuối cùng của mỗi đặt phòng thành công (bao gồm thuế và các loại phí khác mà Khách hàng phải trả).\n3.2. Vào ngày 05 hàng tháng, Bên B sẽ gửi cho Bên A một bản sao kê chi tiết các đặt phòng đã hoàn thành trong tháng trước đó và hóa đơn phí hoa hồng. Bên A có trách nhiệm thanh toán toàn bộ số tiền trên hóa đơn trong vòng 14 (mười bốn) ngày kể từ ngày nhận được hóa đơn."));
                column.Item().Element(c => ComposeParagraph(c, "Điều 4: Bảo mật Dữ liệu", "4.1. Mỗi Bên cam kết tuân thủ các quy định hiện hành về bảo vệ dữ liệu cá nhân. Dữ liệu của Khách hàng do Bên B cung cấp chỉ được Bên A sử dụng cho mục đích hoàn thành đặt phòng.\n4.2. Các Bên đồng ý giữ bí mật các điều khoản của Hợp đồng này và mọi thông tin kinh doanh độc quyền của Bên còn lại."));
                column.Item().Element(c => ComposeParagraph(c, "Điều 5: Giải quyết tranh chấp", "5.1. Mọi tranh chấp phát sinh từ hoặc liên quan đến Hợp đồng này trước hết sẽ được giải quyết thông qua thương lượng hòa giải. \n5.2. Nếu không thể giải quyết qua thương lượng trong vòng 30 ngày, tranh chấp sẽ được đưa ra giải quyết tại Tòa án nhân dân có thẩm quyền tại Thái Nguyên, Việt Nam. Luật áp dụng là luật pháp Việt Nam."));

                column.Item().PaddingTop(50).Row(row =>
                {
                    row.RelativeItem().Column(col => {
                        col.Item().AlignCenter().Text("ĐẠI DIỆN BÊN A").Bold();
                        col.Item().AlignCenter().Text("(Ký, ghi rõ họ tên và đóng dấu nếu có)");
                        col.Item().Height(80);
                        col.Item().AlignCenter().Text(_model.SignatoryName ?? "..............................").Underline();
                        col.Item().AlignCenter().Text($"Chức vụ: {_model.SignatoryPosition}");
                    });
                    row.RelativeItem().Column(col => {
                        col.Item().AlignCenter().Text("ĐẠI DIỆN BÊN B").Bold();
                        col.Item().AlignCenter().Text("(Ký, ghi rõ họ tên và đóng dấu nếu có)");
                        col.Item().Height(80);
                        col.Item().AlignCenter().Text("..............................").Underline();
                        col.Item().AlignCenter().Text("Giám đốc Điều hành");
                    });
                });
            });
        }
        
        void ComposeSection(IContainer container, string title, Action<TableDescriptor> content)
        {
            container.ShowEntire().Column(column =>
            {
                // SỬA LẠI: Chuyển .PaddingBottom() ra trước .Text()
                column.Item().PaddingBottom(5).Text(title).SemiBold().FontSize(11);
                column.Item().Border(1).Padding(10).Column(col =>
                {
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(100);
                            columns.RelativeColumn();
                        });
                        content(table);
                    });
                });
            });
        }
        
        void ComposeParagraph(IContainer container, string title, string text)
        {
            container.ShowEntire().Column(column =>
            {
                column.Spacing(5);
                column.Item().Text(title).SemiBold().FontSize(11);
                column.Item().Text(text).FontSize(10).LineHeight(1.5f);
            });
        }
    }
}