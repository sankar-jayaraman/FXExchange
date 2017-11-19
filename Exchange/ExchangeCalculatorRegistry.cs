using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Exchange
{
	public class ExchangeCalculatorRegistry:Registry
	{
		public ExchangeCalculatorRegistry()
		{
			For<ICommandLineValidation>().Use<ExchangeCommandLineValidation>();
			For<IExchangeRateCalculator>().Use<SimpleExchangeRateCalculator>();
			For<IExchangeRateRetriever>().Use<ExchangeRateRetriever>();
			For<IExchangeRateStore>().Use<HardCodedExchangeRateStore>();
			For<ILogger>().Use<ConsoleLogger>();
		}
	}
}
