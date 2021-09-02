using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suma_de_LCP
{
    class Program
    {
        public static int prefijo_comun_mas_largo = 0;

        class Trie
        {
            char value;
            int cant;
            int fin;
            Trie[] child;

            public Trie()
            {
                value = '^';
                cant = 1;
                fin = 0;
                child = new Trie[26];
            }

            public Trie(char n)
            {
                value = n;
                fin = 0;
                cant = 0;
                child = new Trie[26];
            }

            public void Insert(string s)
            {
                Trie temp = this;
               
                for (int i = 0; i < s.Length; i++)
                {
                    if (temp.child[GetPosition(s[i])] == null)
                        temp.child[GetPosition(s[i])] = new Trie(s[i]);
                    temp = temp.child[GetPosition(s[i])];
                    temp.cant++;
                    prefijo_comun_mas_largo += temp.cant;
                }
                
                temp.fin++;
            }

            private int GetPosition(char c)
            {
                return c - 'a';
            }
        }

        static void Main()
        {
            Trie trie = new Trie();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                trie.Insert(s);
            }

            Console.WriteLine(prefijo_comun_mas_largo);
        }
    }
}
