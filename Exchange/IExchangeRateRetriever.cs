using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    public interface IExchangeRateRetriever
    {
        double ExchangeRate(string MainCurrency, string MoneyCurrency);
    }

    public class ExchangeRateRetriever : IExchangeRateRetriever
    {
        private readonly IExchangeRateStore _exchangeRateStore;
        private readonly string _moneyCurrency = "DKK";
        private readonly ILogger _log;
        public ExchangeRateRetriever(IExchangeRateStore exchangeRateStore, ILogger log)
        {
            _exchangeRateStore = exchangeRateStore;
            _log = log;
        }

        public double ExchangeRate(string MainCurrency, string MoneyCurrency)
        {
            if (MainCurrency.Equals(MoneyCurrency,StringComparison.InvariantCultureIgnoreCase))
                return 1.0;
            if (_moneyCurrency.Equals(MoneyCurrency, StringComparison.InvariantCultureIgnoreCase))
            {
                return GetCurrencyExchangeRate(MainCurrency)/
                       _exchangeRateStore.LotSize;
            }
            
            
            return GetCurrencyExchangeRate(MainCurrency)/GetCurrencyExchangeRate(MoneyCurrency);
            
        }

        private double GetCurrencyExchangeRate(string currency)
        {
            var exch = (from curr in _exchangeRateStore.ExchangeRates
                       where curr.Key.Equals(currency, StringComparison.InvariantCultureIgnoreCase)
                       select curr.Value).ToList();
            if (exch.Count != 0)
                return exch.First();
            var exceptionMessage = "Currency " + currency + " doesn't exist.";
            _log.Log(exceptionMessage);
            throw new ArgumentException(exceptionMessage);
        }
    }
}
