using System;
using System.Collections.Generic;

#nullable disable

namespace estockmarket.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public string CompanyCode { get; set; }
        public decimal? StockPrice { get; set; }
        public DateTime? StockStartDate { get; set; }
        public DateTime? StockEndDate { get; set; }
        public TimeSpan? StockStartTime { get; set; }
        public TimeSpan? StockEndTime { get; set; }

        public virtual Company CompanyCodeNavigation { get; set; }
    }
}
