using System;
using System.Collections.Generic;

namespace VSSummit2020.Pages.Relatorios
{
    public class RealInformation
    {
        public string Product { get; }
        public decimal Quantity { get; }
        public string Value { get; }
        public string Total { get; }
        public DateTime Date { get; }

        private RealInformation(string product, decimal quantity, decimal value, DateTime date)
        {
            Product = product;
            Quantity = quantity;
            Value = $"{value:c2}";
            Total = $"{quantity * value:c2}";
            Date = date;
        }

        public static IList<RealInformation> GetRealInformation() =>
            new List<RealInformation>(22)
            {
                new RealInformation("Produto real 1", 1.1M, 10.1M, DateTime.Now),
                new RealInformation("Produto real 2", 2.2M, 20.2M, DateTime.Now.AddDays(-1)),
                new RealInformation("Produto real 3", 3.3M, 30.3M, DateTime.Now.AddDays(-1)),
                new RealInformation("Produto real 4", 4.4M, 40.4M, DateTime.Now.AddDays(-1)),
                new RealInformation("Produto real 5", 5.5M, 50.5M, DateTime.Now.AddDays(-2)),
                new RealInformation("Produto real 6", 6.6M, 60.6M, DateTime.Now.AddDays(-2)),
                new RealInformation("Produto real 7", 7.7M, 70.7M, DateTime.Now.AddDays(-2)),
                new RealInformation("Produto real 8", 8.8M, 80.8M, DateTime.Now.AddDays(-3)),
                new RealInformation("Produto real 9", 9.9M, 90.9M, DateTime.Now.AddDays(-3)),
                new RealInformation("Produto real 10", 10.1M, 100.1M, DateTime.Now.AddDays(-3)),
                new RealInformation("Produto real 11", 1.1M, 10.1M, DateTime.Now.AddDays(-4)),
                new RealInformation("Produto real 12", 2.2M, 20.2M, DateTime.Now.AddDays(-4)),
                new RealInformation("Produto real 13", 3.3M, 30.3M, DateTime.Now.AddDays(-4)),
                new RealInformation("Produto real 14", 4.4M, 40.4M, DateTime.Now.AddDays(-5)),
                new RealInformation("Produto real 15", 5.5M, 50.5M, DateTime.Now.AddDays(-5)),
                new RealInformation("Produto real 16", 6.6M, 60.6M, DateTime.Now.AddDays(-5)),
                new RealInformation("Produto real 17", 7.7M, 70.7M, DateTime.Now.AddDays(-6)),
                new RealInformation("Produto real 18", 8.8M, 80.8M, DateTime.Now.AddDays(-6)),
                new RealInformation("Produto real 19", 9.9M, 90.9M, DateTime.Now.AddDays(-6)),
                new RealInformation("Produto real 20", 10.1M, 100.1M, DateTime.Now.AddDays(-7)),
                new RealInformation("Produto real 21", 100.1M, 1000.1M, DateTime.Now.AddDays(-7)),
                new RealInformation("Produto real 22", 1000.1M, 10000.1M, DateTime.Now.AddDays(-7)),
            };
    }
}
