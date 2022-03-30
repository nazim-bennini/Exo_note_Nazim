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

        static int id_trans;              // inutile sauf pour faire marcher ma fonction lecture de Transactions
        
        string expediteur;                // static string expediteur;
        string destinataire;              // static string destinataire;

        //string path = Directory.GetCurrentDirectory();
        //string trxnPath = path + @"\Transactions_1.txt";

        public Transactions(string id, float montant, string sender, string receiver)  //constructeur
        {
            Id = id;
            Montant = montant;
            Sender = sender;
            Receiver = receiver;
            id_trans = 0;                       // initialiser par defaut a zero
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
                    id_trans = int.Parse(number);

                    string amount = column_values[1].Replace('.', ',');

                    float somme;
                    float.TryParse(amount, out somme);
                    // remplacer le . par , pour eviter des bug dans le traitement en windows francais
                    // float solde = float.TryParse(balance); ne gere pas les exceptions de solde vide

                    string sender = column_values[2];
                    //int expediteur = int.Parse(sender);       // expediteur = sender;    ne sert a rien ici  //static string expediteur; a declarer si jamais



                    string receiver = column_values[3];
                    //int destinataire = int.Parse(receiver);    // destinataire = receiver; ne sert a rien ici  // static string destinataire;


                    Transactions x = new Transactions(number, somme, sender, receiver);         // expediteur, destinataire a place de sender, receiver
                    //BankAccount x = new BankAccount(column_values[0],column_values[1]);

                    data_fic_transactions.Add(x);
                    // rajouter le compte x qui vient d'etre lu a notre Liste

                }
                streamReader.Dispose();
            }

            return data_fic_transactions;
        }
        /*
        List<Transactions> recup_trans = BankAccount.data_fic_comptes;
        */  // a revoir si jamais



           public bool retrait(int id_trans, int montant, string expediteur, string destinataire)
           {
                    double amount = montant;
                    bool status = false;                                            // statut par defaut

                    if (solde >= montant && MaxRetrait <= 1000)                     // solde(expediteur)
                    {

                       status = true;
                       return status;
                    }
                    else
                    {
                        throw new Exception("virement impossible, car limite depassé");

                        return status;
                    }
           }

           public bool depot(id_trans, montant, expediteur, destinataire)
           {
                    double amount = montant;
           }

           public bool virement(id_trans, montant, expediteur, destinataire)
           {
                    string chemin =
                    List<BankAccount> nomVariable = BankAccount.ReadAccounts(chemin);

                    double amount = montant;
                    bool status = false;                                             // statut par defaut

                    if (MaxRetrait <= 1000)
                    {
                        status = true;
                        return status;
                    }
                    else
                    {
                        throw new Exception("virement impossible, car limite depassé");

                        return status;
                    }
           }

           public bool prelevement(id_trans, montant, expediteur, destinataire)
           {
                    double amount = montant;
                    bool status = false;    // statut par defaut

                    if (virement(id_trans, montant, expediteur, destinataire))
                    {
                        Console.WriteLine($"prelevement autorisé du compte {expediteur} vers le compte {destinataire}");
                        status = true;
                    }
                    else
                    {
                        Console.WriteLine($"prelevement autorisé du compte {expediteur} vers le compte {destinataire}");            // throw new Exception("prelevement impossible, car virement a partir du compte non-autorisé");
                    }
                    return status;
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