using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook p = new PhoneBook();
            p.AddPhoneNumber("0123456789", "Azerty");
            p.AddPhoneNumber("0123456789", "Azerty");

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
