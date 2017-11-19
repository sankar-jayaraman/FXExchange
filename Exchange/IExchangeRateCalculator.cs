using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
	interface IExchangeRateCalculator
	{
		double Calculate(string MainCurrency, string MoneyCurrency, double amount);
	}

	public class SimpleExchangeRateCalculator:IExchangeRateCalculator
	{
		private readonly IExchangeRateRetriever _exchangeRateRetriever;

		public SimpleExchangeRateCalculator(IExchangeRateRetriever exchangeRateRetriever)
		{
			_exchangeRateRetriever = exchangeRateRetriever;
		}

		public double Calculate(string MainCurrency, string MoneyCurrency, double amount)
		{
			return _exchangeRateRetriever.ExchangeRate(MainCurrency, MoneyCurrency) * amount;
		}
	}
}
