using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Features.Bids.Queries.ViewModels
{
    public class BidViewModel
    {
        public FeeViewModel[]? Fees { get; set; }
        public string? CarType { get; set; }
        public decimal? CarPrice { get; set; }
        public decimal? Total => Fees!.Sum(f => f.Amount) + CarPrice;
    }
}
