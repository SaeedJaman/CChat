namespace CChat.Models.Dashboard
{
    public class VoucherViewModel
    {
        public int? voucherTypeId { get; set; }

        public string voucherTypeName { get; set; }

        public int? totalCount { get; set; }

        public decimal? amount { get; set; }
    }
}
