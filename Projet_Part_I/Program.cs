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
            List<BankAccount> Mylist = BankAccount.ReadAccounts(acctPath);

            foreach (BankAccount bankAccount in Mylist)
            {
                Console.WriteLine($"{bankAccount.Number} - {bankAccount.Balance} euros");
            }

            //visualisation de mes data de transactions
            List<Transactions> list_tr = Transactions.ReadTransactions(trxnPath);


            foreach (Transactions transaction in list_tr)
            {
                Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} - origine {transaction.Sender} - destination {transaction.Receiver}");

                if (transaction.Sender == transaction.Receiver)
                {
                    Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} est un virement interne au compte ");         // rien n'est fait ou virement interne vers compte epargne ou compte-titres ... etc

                }

                if (transaction.Sender != transaction.Receiver)

                {
                    if (transaction.Sender == "0" && transaction.Receiver != "0")       // depot depuis environnement
                    {
                        Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} est un depot depuis un compte externe a la banque (c.f. environnement) ou en cash ");
                    }
                    if (transaction.Sender != "0" && transaction.Receiver == "0")       // retrait vers environnement sous condition de solde
                    {
                        for (int i = 0; i < Mylist.Count; i++)                          // parcours de liste
                        {
                            if (Mylist[i].Number == transaction.Sender)                                         // (utilisation de "contains". ou bien equals ou indexof peut-etre appropriée ?
                            {                                                                                   // (myList[i].Contains(myString)) ne marche pas ici          
                                if ((Mylist[i].Balance > transaction.Montant) && (transaction.MaxRetrait < 1000))           // condition solde et max retrait
                                {
                                    // effectuer le retrait

                                    //bool etat = Transactions.retrait();

                                    Console.WriteLine($"transaction {transaction.Id} peut etre effectuée normalement ");
                                }
                                //return i;
                            }
                        }

                            //(BankAccount.(transaction.Sender)  > Transactions.montant && Transactions.montant < Transactions.maxretrait)                     // je veux acceder au solde de mon compte Sender
                            //Transactions.retrait;
                        //Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} est un retrait vers un compte externe a la banque (c.f. environnement) ou en cash");
                    }

                }
            }

            Transactions x = new Transactions("",10,"","");
            x.retrait(1, 0, "", "", Mylist);


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
            


           // foreach (line in data_fic_transactions)
           // {
                
           // }
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
