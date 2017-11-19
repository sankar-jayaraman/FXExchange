using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exchange
{
    public interface ICommandLineValidation
    {
        bool ValidateCommandLine(string[] args);
    }

    public class ExchangeCommandLineValidation : ICommandLineValidation
    {
        public bool ValidateCommandLine(string[] args)
        {
            if (args.Length <= 1)
            {
                return PrintUsage();
            }

            if (args.Length == 2)
            {
                var regex = new Regex(@"\D\D\D\/\D\D\D");
                if (!regex.IsMatch(args[0].ToUpper()))
                    return PrintUsage();
                double d;
                if (!Double.TryParse(args[1], out d) || d <= 0)
                    return PrintUsage();
                return true;
            }

            return PrintUsage();
        }

        private bool PrintUsage()
        {
            Console.Out.WriteLine("Usage: Exchange <Currency Pair> <Amount to exchange> ");
            Console.Out.WriteLine("Currency pair expressed as xxx/yyy");
            Console.Out.WriteLine("Amount must be > 0.0");
            return false;

        }
    }
}
