using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Part_I
{
    public class Transactions
    {
        public string Id { get; set; }
        public float Montant { get; set; }             // a transformer
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public float MaxRetrait { get; }

        //string path = Directory.GetCurrentDirectory();
        //string trxnPath = path + @"\Transactions_1.txt";

        public Transactions(string id, float montant, string sender, string receiver)  //constructeur
        {
            Id = id;
            Montant = montant;
            Sender = sender;
            Receiver = receiver;
            // MaxRetrait = maxRetrait;
        }

        public static List<Transactions> ReadTransactions(string trxnPath)          // pas de (string path)
        {
            List<Transactions> data_fic_transactions = new List<Transactions>();
            using (StreamReader streamReader = new StreamReader(trxnPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] column_values = line.Split(';');

                    string number = column_values[0];
                    int id_trans = int.Parse(number);

                    string balance = column_values[1].Replace('.', ',');
                    float.TryParse(balance, out solde);
                    // remplacer le . par , pour eviter des bug dans le traitement en windows francais
                    // float solde = float.TryParse(balance); ne gere pas les exceptions de solde vide

                    string sender = column_values[2];
                    //int expediteur = int.Parse(sender);
                    string expediteur = sender;

                    string receiver = column_values[3];
                    //int destinataire = int.Parse(receiver);
                    string destinataire = receiver;

                    Transactions x = new Transactions(number, solde, expediteur, destinataire);
                    //BankAccount x = new BankAccount(column_values[0],column_values[1]);

                    data_fic_transactions.Add(x);
                    // rajouter le compte x qui vient d'etre lu a notre Liste

                }
                streamReader.Dispose();
            }

            return data_fic_transactions;

        }

        public static float retrait(id_trans, montant, )
        { 
        }
        public static float depot(,)
        {
        }
    }
}

    //******************************************************************************************************************
    //******************************************************************************************************************
        /*
        public void Deposer(double montant)
        {
            solde = solde + montant;
            Console.Out.WriteLine("Opération bien effectuée");
        }

        public void Deposer(BankAccount c, double montant)                      //une deuxiéme méthode Crediter(..) avec des paramétres différents (surcharge des méthodes)
        {
            if (c.solde >= montant)                                             // (BankAccount.solde >= montant)
            {
                solde = solde + montant;
                Console.Out.WriteLine("Opération bien effectuée");
            }
            else
            {
                Console.Out.WriteLine("Solde de compte insuffisant");
            }
        }

        public bool Retirer(BankAccount c, double montant)                      //une deuxiéme méthode Debiter(..) avec des paramétres différents (surcharge des méthodes)
        {                                                                       // Retirer(BankAccount c, double montant)

            if ((solde >= montant) && (montant <= 1000))
            {
                solde = solde - montant;
                // c.solde = c.solde + montant;
                Console.Out.WriteLine("Opération bien effectuée");
                return true;
            }
            else
            {
                Console.Out.WriteLine("Solde insuffisant");
                return false;
            }


            public void Afficher()
            {
                Console.Out.WriteLine("************************");
                Console.Out.WriteLine("Numéro de Compte: " + number);
                Console.Out.WriteLine("Solde de compte: " + solde);
                Console.Out.WriteLine("Propriétaire du compte : ");
                proprietaire.Afficher();
                Console.Out.WriteLine("*************************");
            }

            public static void Nombre_Comptes()
            {
                Console.Out.WriteLine("\n\nLe nombre de comptes crées: " + nombre_comptes);
            }
        }

        public void Prelevement(BankAccount c, double montant)
        */