using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Part_I
{
    class BankAccount
    {
        private string number;                                      //int number; numero de compte
        private string balance;                                     //balance;  ; attribut de depart chiffre a virgule
        private static int nombre_comptes = 0;
        
        public string Number                                           //Pour voir le numéro de compte est lecture seule
        {                                                              // get set si modifiable
            get { return number; }
        }

        public string Balance                                           //Pour voir le solde est en lecture seule
        {
            get { return balance; }
        }


        public static void Liste_Comptes(string acctPath, string sttsPath)
        {
            string path = Directory.GetCurrentDirectory();

            Dictionary<int, float> Tableau_Comptes = new Dictionary<int, float>();

            using (StreamReader streamReader = new StreamReader(acctPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] column_values = line.Split(';');

                    string number = column_values[0];
                    int numero = int.Parse(number);

                    string balance = column_values[1].Replace('.', ',');
                    float solde = float.Parse(balance);

                    // remplacer le . par , pour eviter des bug dans le traitement en windows francais

                    if (Tableau_Comptes.ContainsKey(numero))
                    {
                        Console.WriteLine($" {numero}:{solde} console1");
                        // dictionaire dictionnaire[clé] = valeur
                        Tableau_Comptes[solde].Add(float.Parse(number));
                        //Tableau_Comptes[column_values[1]].Add(float.Parse(column_values[2]));
                    }
                    else
                    {
                        Console.WriteLine($" {numero}{balance} console2");
                        Tableau_Comptes.Add(matiere, new List<float>() { float.Parse(note) });
                        //Tableau_Comptes[column_values[1]].Add(float.Parse(column_values[2]));
                    }

                }
                streamReader.Dispose();
            }
        }

        public void Deposer(double montant)
        {
            solde = solde + montant;
            Console.Out.WriteLine("Opération bien effectuée");
        }

        public void Deposer(BankAccount c, double montant)                     //une deuxiéme méthode Crediter(..) avec des paramétres différents (surcharge des méthodes)
        {
            if (c.solde >= montant)                                             // (BankAccount.solde >= montant)
            {
                //c.solde -= montant;
                solde = solde + montant;
                Console.Out.WriteLine("Opération bien effectuée");
            }
            else
                Console.Out.WriteLine("Solde de compte insuffisant");
        }

        /*
            public void Retirer(double montant)
            {
                if (solde >= montant)
                {
                    solde -= montant;
                    Console.Out.WriteLine("Opération bien effectuée");
                }
                else
                    Console.Out.WriteLine("Solde insuffisant");
            }
        */

        public void Retirer(BankAccount c, double montant)                      //une deuxiéme méthode Debiter(..) avec des paramétres différents (surcharge des méthodes)
        {                                                                           // Retirer(BankAccount c, double montant)
           
            if ((solde >= montant) && (montant <= 1000))
            {
                solde = solde - montant;
                // c.solde = c.solde + montant;
                Console.Out.WriteLine("Opération bien effectuée");
            }
            else
            {
                Console.Out.WriteLine("Solde insuffisant");
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

                /*
                    public Client Proprietaire
                    {
                        get { return proprietaire; }
                        set { proprietaire = value; }
                    }
                    */

                /*
                public Compte(Client proprietaire)
                {
                    nombre_comptes++;
                    number = nombre_comptes;
                    this.proprietaire = proprietaire;
                }
                */

    }
}
