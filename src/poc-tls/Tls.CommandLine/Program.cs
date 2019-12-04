using System;
using Tls.Engine;

namespace Tls.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new TlsChecker();
            foreach (var value in checker.GetSupportedProtocols().Result)
            {
                Console.WriteLine($"{value.Key}::{value.Value}");
            }

            Console.ReadLine();
        }
    }
}
