using System;
using System.Collections.Generic;

#nullable disable

namespace estockmarket.Models
{
    public partial class Company
    {
        public Company()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCeo { get; set; }
        public decimal? CompanyTurnover { get; set; }
        public string CompanyWebsite { get; set; }
        public string StockExchange { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
