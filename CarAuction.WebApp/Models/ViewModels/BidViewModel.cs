namespace CarAuction.WebApp.Models.ViewModels
{
    public class BidViewModel
    {
        public FeeViewModel[]? Fees { get; set; }
        public string? CarType { get; set; }
        public decimal? CarPrice { get; set; }
        public decimal? Total => Fees!.Sum(f => f.Amount) + CarPrice;
    }
}
