using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportePeso
{
    class Program
    {
        static void Build(int node, int inicio, int fin, int[] array, int[] st)
        {
            if (inicio == fin)
                st[node] = array[inicio];
            else
            {
                int medio = (inicio + fin) / 2;

                Build(2 * node, inicio, medio, array, st);
                Build(2 * node + 1, medio + 1, fin, array, st);

                st[node] = Math.Min(st[2 * node], st[2 * node + 1]);
            }
        }

        static void Update(int node, int inicio, int fin, int i, int valor, int[] array, int[] st)
        {
            if (inicio == fin && inicio == i)
            {
                st[node] = valor;
                array[inicio] = valor;
            }
            else
            {
                int medio = (inicio + fin) / 2;

                if (i <= medio)
                    Update(2 * node, inicio, medio, i, valor, array, st);
                else
                    Update(2 * node + 1, medio + 1, fin, i, valor, array, st);

                st[node] = Math.Min(st[2 * node], st[2 * node + 1]);
            }
        }

        static int min = int.MaxValue;

        static int Query(int node, int inicio, int fin, int i, int j, int[] st)
        {
            if (fin < i || inicio > j)
                return min;
            if (inicio >= i && fin <= j)
                return st[node];

            int medio = (inicio + fin) / 2;

            int l = Query(2 * node, inicio, medio, i, j, st);
            int r = Query(2 * node + 1, medio + 1, fin, i, j, st);

            return Math.Min(l, r);
        }


        static void Main(string[] args)
        {
            int[] st = new int[4 * 100005];
            int[] array = new int[100005];

            int n = int.Parse(Console.ReadLine());

            string[] s = Console.ReadLine().Split();
            for (int i = 0; i < s.Length; i++)
            {
                array[i] = int.Parse(s[i]);
            }

            Build(1, 0, n - 1, array, st);
            int q = int.Parse(Console.ReadLine());

            while (q > 0)
            {
                string[] z = Console.ReadLine().Split();
                int b = int.Parse(z[0]);
                int c = int.Parse(z[1]);

                Update(1, 0, n - 1, b - 1, c, array, st);
                Console.WriteLine(Query(1, 0, n - 1, 0, n - 1, st));
                q--;
            }
        }
    }
}
