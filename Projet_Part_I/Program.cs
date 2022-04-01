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

        /****************************************************************************/
        // visualisation (sur console) et ecriture (foreach) de mes data de comptes
            List<BankAccount> Mylist = BankAccount.ReadAccounts(acctPath);

            foreach (BankAccount bankAccount in Mylist)
            {
                Console.WriteLine($"{bankAccount.Number} - {bankAccount.Balance} euros");
            }

            Console.WriteLine("");
            //--------------------------------------------------------------------------//
            // visualisation (sur console) et ecriture (foreach) de mes data de comptes


        /****************************************************************************/
        //visualisation (sur console) et traitement de mes data de transactions
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
                    /*****************************/
                    // DEPOT depuis environnement
                    if (transaction.Sender == "0" && transaction.Receiver != "0")       
                    {
                        if (transaction.Montant > 0)
                        {
                            for (int i = 0; i < Mylist.Count; i++)       // parcours de liste
                            {
                                if (Mylist[i].Number == transaction.Receiver)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"transaction Id {transaction.Id} peut etre effectuée normalement, solde initial {Mylist[i].Balance}");
                                    Console.WriteLine($"transaction Id {transaction.Id} - montant {transaction.Montant} est un depot depuis un compte externe a la banque (c.f. environnement) ou en cash ");

                                    Transactions x = new Transactions(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver);
                                    x.depot(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver, Mylist[i]);

                                    Console.WriteLine($"transaction Id {transaction.Id} a été effectuée vers le compte N° {Mylist[i].Number}");
                                    Console.WriteLine("");

                                }
                            }
                        }
                    }

                    /******************************/
                    // RETRAIT vers environnement sous condition de solde
                    if (transaction.Sender != "0" && transaction.Receiver == "0")       
                    {
                        for (int i = 0; i < Mylist.Count; i++)          // parcours de liste
                        {
                            if (Mylist[i].Number == transaction.Sender)                                         // (utilisation de "contains". ou bien equals ou indexof peut-etre appropriée ?
                            {                                                                                   // (myList[i].Contains(myString)) ne marche pas ici          
                                if ((Mylist[i].Balance > transaction.Montant) && (transaction.MaxRetrait < 1000))           // condition solde et max retrait
                                {
                                    // effectuer le retrait

                                    // retrait(int id_trans, int montant, string expediteur, string destinataire, List < BankAccount > aupif, BankAccount c)
                                    Console.WriteLine("");
                                    Console.WriteLine($"transaction Id {transaction.Id} peut etre effectuée normalement, solde initial {Mylist[i].Balance}");
                                    Console.WriteLine($"transaction Id {transaction.Id} - montant {transaction.Montant} est un retrait vers un compte externe a la banque (c.f. environnement) ou en cash ");

                                    Transactions x = new Transactions(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver);
                                    x.retrait(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver, Mylist[i]);

                                    //  bool etat = Transactions.retrait();

                                    Console.WriteLine($"transaction Id {transaction.Id} a été effectuée a partir du compte N° {Mylist[i].Number}");
                                    Console.WriteLine("");
                                }
                                //return i;
                            }

                        }
                            //(BankAccount.(transaction.Sender)  > Transactions.montant && Transactions.montant < Transactions.maxretrait)                     // je veux acceder au solde de mon compte Sender
                            //Transactions.retrait;
                        //Console.WriteLine($"{transaction.Id} - montant {transaction.Montant} est un retrait vers un compte externe a la banque (c.f. environnement) ou en cash");
                    }

                    /******************************/
                    // VIREMENT vers un compte de la banque
                    if (transaction.Sender != "0" && transaction.Receiver != "0")
                    {
                        if (transaction.Montant < transaction.MaxRetrait)
                        {
                            for (int i = 0; i < Mylist.Count; i++)          // parcours de liste
                            {
                                if (Mylist[i].Number == transaction.Sender)                                         // (utilisation de "contains". ou bien equals ou indexof peut-etre appropriée ?
                                {                                                                                   // (myList[i].Contains(myString)) ne marche pas ici          
                                    if ((Mylist[i].Balance > transaction.Montant) && (transaction.MaxRetrait < 1000))           // condition solde et max retrait
                                    {
                                        // effectuer le virement

                                        // retrait(int id_trans, int montant, string expediteur, string destinataire, List < BankAccount > aupif, BankAccount c)
                                        Console.WriteLine("");
                                        Console.WriteLine($"transaction Id {transaction.Id} virement peut etre effectuée normalement, solde initial emetteur{Mylist[i].Balance}");
                                        Console.WriteLine($"transaction Id {transaction.Id} - montant {transaction.Montant} est un virement a un compte bancaire de la banque");

                                        Transactions x = new Transactions(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver);
                                        x.virement(transaction.Id, transaction.Montant, transaction.Sender, transaction.Receiver, Mylist[i]);

                                        //  bool etat = Transactions.retrait();

                                        Console.WriteLine($"transaction Id {transaction.Id} a été effectuée a partir du compte N° {Mylist[i].Number}");
                                        Console.WriteLine("");
                                    }
                                    else 
                                    {
                                        Console.WriteLine($"transaction Id {transaction.Id} a été effectuée a partir du compte N° {Mylist[i].Number}");
                                    }
                                    //return i;
                                }
                            }
                        }
                      
                        else
                        {
                            Console.WriteLine($"transaction Id {transaction.Id} ne peut etre effectuée pour cause de montant > maximum par retrait");
                        }
                    }
                }
            }

            // draft Transactions x = new Transactions("",10,"","");
            // draft x.retrait(1, 0, "", "", Mylist, );


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
            //-----------------------------------------------------------------------------//
            // fin de traitement sur les transactions
        



    }
}
