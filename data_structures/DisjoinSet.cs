using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSet
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
                count[i] = 0;
            }
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

    static void ImprimeArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Disjoint_Set conjuntosDisjuntos = new Disjoint_Set(5);

            conjuntosDisjuntos.Merge(1, 2);

            ImprimeArray(conjuntosDisjuntos.Indices);
            ImprimeArray(conjuntosDisjuntos.Count);
        }
    }
}
