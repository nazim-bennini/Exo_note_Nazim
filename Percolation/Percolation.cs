using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        private bool IsOpen(int i, int j)
        {

            throw new NotImplementedException();
        }

        private bool IsFull(int i, int j)
        {
            if (!IsOpen)
            {
                if (i < 0 || j<0 || i>= _size || j>= _size)
                {
                    throw new NotImplementedException($"la case {i}, {j} est hors de la grille");    
                }
                else
                {
                    return false
                }
                    
            }
            else
            {
                if ((i==1) && (IsOpen))
                {
                    return true;
                }
                else 
                {
                     if CloseNeighbors(i, j) != IsFull      // condition que un des close neighbors soit rempli
                     {
                          return false;

                     }
                        
                }
            }
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            // var a = CloseNeighbors(i, j);

            int key = 0;

            for (i = 1; _size; i++)
            {
                for (j = 1; _size; j++)
                {
                    if ((i > 1) && (i < _size))
                    {
                        n_up(i, j) = [i, j - 1];
                        n_down(i, j) = [i, j+1];
                        n_left(i, j) = [i - 1, j];
                        n_right(, j) = [i + 1, j];
                    }

                    if (i == 1)  // premiere ligne
                    {
                        
                    }

                    if (i==_size && j==_size)  // coin bas-droite
                    {
                        n_up = [i - 1, j];
                        n_left = [1, j - 1];
                    }

                    if (i == _size && j = 1)   // coin bas-gauche
                    {
                        n_up = [i - 1, j];
                        n_right = [i, j - 1];
                    }

                    if (i == _size && 1 < j < _size)   // ligne du bas
                    {
                        n_up = [i, j-1];
                        n_left = [i, j-1];
                        n_right = [i, j+1];
                    }
                }
            }

            return new List<KeyValuePair<DateTime, DateTime>> (cle, valeur);



            throw new NotImplementedException();
        }

        private void Open(int i, int j)
        {
            if (!IsOpen)
            {
                IsOpen(i, j);
            }

            throw new NotImplementedException();
        }
    }
}
