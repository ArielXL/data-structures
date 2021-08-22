using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    public class SegmentTree
    {
        int[] array;
        int[] st;

        public SegmentTree(int[] array)
        {
            this.array = array;
            st = new int[4 * array.Length];

            Build(1, 0, array.Length - 1);
        }

        private int Operation(int a, int b)
        {
            return Math.Min(a, b);
        }

        private void Build(int nodo, int inicio, int final)
        {
            if (inicio == final)
                st[nodo] = array[inicio];
            else
            {
                int medio = (inicio + final) / 2;

                Build(2 * nodo, inicio, medio);
                Build(2 * nodo + 1, medio + 1, final);

                st[nodo] = Operation(st[2 * nodo], st[2 * nodo + 1]);
            }
        }

        public void Update(int indice, int valor)
        {
            Update(1, 0, array.Length - 1, indice, valor);
        }

        private void Update(int nodo, int inicio, int final, int indice, int valor)
        {
            if (inicio == final && inicio == indice)
            {
                array[indice] = valor;
                st[nodo] = valor;
            }
            else
            {
                int medio = (inicio + final) / 2;

                if (indice <= medio)
                    Update(nodo * 2, inicio, medio, indice, valor);
                else
                    Update(nodo * 2 + 1, medio + 1, final, indice, valor);

                st[nodo] = Operation(st[nodo * 2], st[nodo * 2 + 1]);
            }
        }

        private int Null()
        {
            return int.MaxValue;
        }

        public int Query(int i, int j)
        {
            return Query(1, 0, array.Length - 1, i, j);
        }

        private int Query(int nodo, int inicio, int final, int i, int j)
        {
            if (final < i || j < inicio)
                return Null();
            if (i <= inicio && j >= final)
                return st[nodo];

            int medio = (inicio + final) / 2;

            int izquierdo = Query(nodo * 2, inicio, medio, i, j);
            int derecho = Query(2 * nodo + 1, medio + 1, final, i, j);

            return Operation(izquierdo, derecho);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 8, 1, 90, -3 };

            SegmentTree segment_tree = new SegmentTree(array);

            Console.WriteLine(segment_tree.Query(0, 3));
        }
    }
}
