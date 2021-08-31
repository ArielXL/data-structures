using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingCommunities
{
    class DisjointSet
    {
        int[] indices;
        int[] count;

        public DisjointSet(int n)
        {
            indices = new int[n];
            count = new int[n];

            for (int i = 0; i < n; i++)
            {
                indices[i] = i;
                count[i] = 1;
            }
        }

        public int Cantidad(int i)
        {
            return count[SetOf(i)];
        }

        public int SetOf(int i)
        {
            if (indices[i] == i)
                return i;
            else
                return indices[i] = SetOf(indices[i]);
        }

        public void Merge(int i, int j)
        {
            int x = SetOf(i);
            int y = SetOf(j);

            if (x == y)
                return;

            if (count[x] < count[y])
            {
                indices[x] = y;
                count[y] += count[x];
                count[x] = 0;
            }
            else
            {
                indices[y] = x;
                count[x] += count[y];
                count[y] = 0;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] linea = Console.ReadLine().Split();

            int n = int.Parse(linea[0]);
            int preguntas = int.Parse(linea[1]);

            DisjointSet conjuntosDisjuntos = new DisjointSet(n);

            while (preguntas > 0)
            {
                linea = Console.ReadLine().Split();
                char c = char.Parse(linea[0]);

                if (c == 'M')
                {
                    int i = int.Parse(linea[1]);
                    int j = int.Parse(linea[2]);
                    conjuntosDisjuntos.Merge(i - 1, j - 1);
                }
                else
                {
                    int i = int.Parse(linea[1]);
                    Console.WriteLine(conjuntosDisjuntos.Cantidad(i - 1));
                }

                preguntas--;
            }
        }
    }
}
