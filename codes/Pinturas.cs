using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinturas
{
    class Program
    {
        static void Main()
        {
            string[] s = Console.ReadLine().Split();
            string[,] paint = new string[int.Parse(s[0]), int.Parse(s[1])];
            string q;
            int c = 0;
            for(int i = 0 ;i < paint.GetLength(0) ;i++)
            {
                q = Console.ReadLine();
                for (int j = 0; j < paint.GetLength(1); j++)
                {
                    paint[i, j] = q.Substring(j, 1);
                    if (paint[i, j] == "*")
                        c++;
                }
            }
            Disjoin_Set d = new Disjoin_Set(paint.GetLength(0) * paint.GetLength(1));
            for (int i = 0; i < paint.GetLength(0); i++)
                for (int j = 0; j < paint.GetLength(1); j++)
                {
                    if (paint[i, j] == "*")
                    {
                        if (j + 1 < paint.GetLength(1) && paint[i, j + 1] == "*" && d.Merge(i*paint.GetLength(1)+j, i * paint.GetLength(1) + j+1))
                            c--;
                        if (i + 1 < paint.GetLength(0) && paint[i + 1, j] == "*" && d.Merge(i * paint.GetLength(1) + j, (i + 1) * paint.GetLength(1) + j))
                            c--;
                        if (i + 1 < paint.GetLength(0) && j + 1 < paint.GetLength(1) && paint[i + 1, j + 1] == "*" && d.Merge(i * paint.GetLength(1) + j, (i+1) * paint.GetLength(1) + j+1))
                            c--;
                        if (i + 1 < paint.GetLength(0) && j - 1 >= 0 && paint[i + 1, j - 1] == "*" && d.Merge(i * paint.GetLength(1) + j, (i + 1) * paint.GetLength(1) + j - 1))
                            c--;
                    }

                }
            Console.WriteLine(c);
        }
    }
    class Disjoin_Set
    {
        int[] Count;
        int[] Index;
        public Disjoin_Set(int n)
        {
            Count = new int[n];
            Index = new int[n];
            for (int i = 0; i < n; i++)
            {
                    Index[i] = i;
                    Count[i] = 1;
            }
        }
        public int SetOf(int i)
        {
            return Index[i] == i ? i : SetOf(Index[i]);
        }
        public bool Merge(int i, int j)
        {
            int x = SetOf(i);
            int y = SetOf(j);
            if (x == y) return false;
            if (Count[x] < Count[y])
            {
                Count[y] += Count[x];
                Index[x] = y;
            }
            else
            {
                Count[x] += Count[y];
                Index[y] = x;
            }
            return true;
        }
    }
}
