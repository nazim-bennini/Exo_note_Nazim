using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class PhoneBook
    {
        private Dictionary<string, string> _annuaire;

        public PhoneBook()                                     //constructeur
        {
            _annuaire = new Dictionary<string, string>();    // initialization du dictionnaire
        }


        private bool IsValidPhoneNumber(string phoneNumber)
        {

            if ((phoneNumber[0] == '0' && phoneNumber[1] != '0') && (phoneNumber.Length == 10))
            {
                return true;
            }
            else
            {
                return false;
            }


            /*Accepts only 10 digits, no more no less. (Like Mike's answer)
              Regex pattern = new Regex(@"(?<!\d)\d{10}(?!\d)"); */

            //ANCIENNEMENT le regex

            //Regex pattern = new Regex(@"^[0][1-9]\d{8}$");

            //if (pattern.IsMatch(phoneNumber))
            //{
            //    // tentative d'exclure les numeros consecutifs se ressemblant, mais surement pas comme ca
            //    //get { return phoneNumber; }
            //    //set { phoneNumber = !string.IsNullOrWhiteSpace(value) ? Regex.Replace(value, @"[^0-9]", "") : null; }

            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }

        public bool ContainsPhoneContact(string phoneNumber)
        {

            return _annuaire.ContainsKey(phoneNumber);
            
           // equivalent a ci-dessous
           /* 
            if (_annuaire.ContainsKey(phoneNumber))
            {
                return t;
            }
            else
            {
                return false;
            }
           */
        }


        public void PhoneContact(string phoneNumber)
        {
            if (ContainsPhoneContact(phoneNumber) == true)
            {
                Console.WriteLine($" contact correspond a {phoneNumber} | {_annuaire[phoneNumber]}");
                //_annuaire.Contains(phoneNumber);
                // afficher si present dans le dictionnaire
                // sinon gerer exception
            }
            else
            {
                throw new ArgumentException("pas de contact associé a ce numeron dans l'annuaire");
            }
        }

        public bool AddPhoneNumber(string phoneNumber, string name)
        {
            if (IsValidPhoneNumber(phoneNumber) || ContainsPhoneContact(phoneNumber))
            {
                _annuaire.Add(phoneNumber, name);
                return true;
            }
            else
            {
                //throw new Exception("format de numero invalide pour ajouter a l'annuaire");     //impossibl de laisser cette ligne avec un return derriere
                return false;
            }

        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            if (IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine($"le numero {phoneNumber} est supprimé de l'annuaire");
                _annuaire.Remove(phoneNumber);              
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DisplayPhoneBook()
        {
            Console.WriteLine("le numero est supprimé de l'annuaire");
            foreach (KeyValuePair<string, string> kvp in _annuaire)
            {
                Console.WriteLine($" {kvp.Key} | {kvp.Value}");  // par key pour la premiere colonne par value pour la deuxieme.
            }                                                    // pas de keyvaluePair si plus de deux colonnes et pas identification juste par key et value 

            /*
             foreach (string kvp in _annuaire.Value)
            {
                Console.WriteLine($" {nom_variable}")
            }
            */
        }
    }
}
