using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Part_I
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            // visualisation de mes data de comptes
            List<BankAccount> lst = BankAccount.ReadAccounts(acctPath);

            foreach (BankAccount bankAccount in lst)
            {
                Console.WriteLine($"{bankAccount.Number} - {bankAccount.Balance}€");
            }

            //visualisation de mes data de transactions
            List<Transactions> lst_tr = Transactions.ReadTransactions(trxnPath);

            foreach (Transactions transaction in lst_tr)
            {
                Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} - origine {transaction.Sender} - destination {transaction.Receiver}");
            }

            //Transactions.ReadTransactions(trxnPath);

            //TODO: Votre implémentation
            BankAccount.ReadAccounts(acctPath);
            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            // Transactions x = new Transactions(" ",0," "," ");  probablement inutile
            
        }

        



    }
}
