using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Class BankAccount;

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
            List<BankAccount> list = BankAccount.ReadAccounts(acctPath);

            foreach (BankAccount bankAccount in list)
            {
                Console.WriteLine($"{bankAccount.Number} - {bankAccount.Balance}€");
            }

            //visualisation de mes data de transactions
            List<Transactions> list_tr = Transactions.ReadTransactions(trxnPath);


            foreach (Transactions transaction in list_tr)
            {
                Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} - origine {transaction.Sender} - destination {transaction.Receiver}");

                switch 

                Transactions.retrait;

                /*
                if (transaction.Receiver == '0' )
                {
                    Transactions.retrait(Transactions.id_trans, Transactions.montant, string expediteur, string destinataire)
                        BankAccount.Balance = solde - montant
                        BankAccount var = new BankAccount(a, b);

                }

                if ()
                {
                    Transactions.depot
                }

                if ()
                {
                    Transactions.prelevement
                }

                if ()
                {
                    Transactions.virement
                }
                */
            }


            foreach (line in data_fic_transactions)
            {
                
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
