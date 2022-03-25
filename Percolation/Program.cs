using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Console.ReadLine("Entrez taille de la grille ");
            Percolation.Percolation(N);

            Random aleatoire = new Random();
            int entier = aleatoire.next();                  //Génère un entier aléatoire positif
            int entieri = aleatoire.next(_size);    //Génère un entier compris entre 0 et _size-1
            int entierj = aleatoire.next(_size);    //Génère un entier compris entre 0 et _size-1

            Percolation.Open(entieri, entierj);
        }
    }
}
