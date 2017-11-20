using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Exchange
{
	class Program
	{
		static int Main(string[] args)
		{
			var registry = new Registry();
			registry.IncludeRegistry<ExchangeCalculatorRegistry>();
			var container = new Container(registry);
			var commandLineValidator = container.GetInstance<ICommandLineValidation>();
			if (!commandLineValidator.ValidateCommandLine(args))
			{
				return -1;
			}
			var currencies = args[0].Split('/');
			var amount = Convert.ToDouble(args[1]);
			var calculator = container.GetInstance<IExchangeRateCalculator>();
			try
			{
				Console.WriteLine((calculator.Calculate(currencies[0], currencies[1], amount).ToString()));
			}
			catch (ArgumentException argE)
			{
				return -1;
			}
			return 0;
		}
	}
}
