using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Part_I
{
    public class BankAccount
    {

        public string Number { get; set; }
        public float Balance { get; set; }

        public BankAccount(string number, float balance)    //constructeur
        {
            Number = number;
            Balance = balance;
        }



        public static List<BankAccount> ReadAccounts(string acctPath)             // etait en static mais il ne vaut mieux pas
        {
            List<BankAccount> data_fic_comptes = new List<BankAccount>();
            using (StreamReader streamReader = new StreamReader(acctPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] column_values = line.Split(';');

                    string number = column_values[0];
                    int numero = int.Parse(number);

                    string balance = column_values[1].Replace('.', ',');
                    float solde;
                    float.TryParse(balance, out solde);
                    // remplacer le . par , pour eviter des bug dans le traitement en windows francais

                    BankAccount x = new BankAccount(number, solde);    // number parce que en string contrairement a numero int
                    //BankAccount x = new BankAccount(column_values[0],column_values[1]);

                    data_fic_comptes.Add(x);
                    // rajouter le compte x qui vient d'etre lu a notre Liste

                }
                streamReader.Dispose();
            }

            return data_fic_comptes;          // List<BankAccount> ReadAccounts va retourner ce qui est ici.
        }                                     // faire appel a cette fonction veut dire avoir data_fic_comptes en sortie 

        
    }
}

//***************************************************************************************************************
//***************************************************************************************************************

/*
private string number;                                      //int number; numero de compte
private string balance;                                     //balance;  ; attribut de depart chiffre a virgule
private static int nombre_comptes = 0;                      // potentiellement pour la partie II ou III

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
        }
        streamReader.Dispose();
    }
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


/*     condition superflue a streamreader
 if (!(Tableau_Comptes.ContainsKey(numero)))
            {
                Console.WriteLine($" {numero}:{solde} console1");                                  

                Tableau_Comptes[numero] = solde;
                //Tableau_Comptes[column_values[1]].Add(float.Parse(column_values[2]));
            }
            else
            {
                Console.WriteLine($" {numero}{balance} console2");
                Tableau_Comptes.Add(matiere, new List<float>() { float.Parse(note) });
                //Tableau_Comptes[column_values[1]].Add(float.Parse(column_values[2]));
            } 
 */