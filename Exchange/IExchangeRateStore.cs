using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    public interface IExchangeRateStore
    {
        Dictionary<string, double> ExchangeRates { get; }
        int LotSize { get; }
    }

    public class HardCodedExchangeRateStore : IExchangeRateStore
    {

        public Dictionary<string, double> ExchangeRates => new Dictionary<string, double>{
            {"EUR", 743.94 },
            {"USD", 663.11 },
            {"GBP", 852.85 },
            {"SEK", 76.10 },
            {"NOK", 78.4 },
            {"CHF", 683.58 },
            {"JPY", 5.97 }
        };

        public int LotSize => 100;
    }
}
