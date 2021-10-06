using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Trie
    {
        public char Value { get; private set; }
        public Trie[] Childrens { get; private set; }
        public int End { get; private set; }
        private int count { get; set; }

        public Trie()
        {
            Value = '^';
            Childrens = new Trie[26];
            End = 0;
            count = 1;
        }

        public Trie(char n)
        {
            Value = n;
            Childrens = new Trie[26];
            End = 0;
            count = 1;
        }

        /// <summary>
        /// Inserta el string s una cantidad n de veces en el trie.
        /// </summary>
        public void Insert(string s, int n)
        {
            Trie temp = this;
            for (int i = 0; i < s.Length; i++)
            {
                int pos = GetPosition(s[i]);
                if (temp.Childrens[pos] == null)
                    temp.Childrens[pos] = new Trie(s[i]);
                temp.count += n;
                temp = temp.Childrens[pos];
            }
            temp.End += n;
            temp.count += n;
        }

        private int GetPosition(char c)
        {
            return c - 'a';
        }

        /// <summary>
        /// Devuelve cuantas veces se encuentra el string s en el trie.
        /// </summary>
        public int Count(string s)
        {
            Trie temp = this;
            for (int i = 0; i < s.Length; i++)
            {
                int pos = GetPosition(s[i]);
                if (temp.Childrens[pos] == null)
                    return 0;
                temp = temp.Childrens[pos];
            }
            return temp.End;
        }

        /// <summary>
        /// Elimina el string s una cantidad n de veces del trie.
        /// </summary>
        public void Delete(string s, int n)
        {
            n = Math.Min(n, Count(s));
            if (n == 0)
                return;
            Trie temp = this;
            for (int i = 0; i < s.Length; i++)
            {
                int pos = GetPosition(s[i]);
                temp.count -= n;
                if (temp.Childrens[pos].count == n)
                {
                    temp.Childrens[pos] = null;
                    return;
                }
                temp = temp.Childrens[pos];
            }
            temp.End -= n;
            temp.count -= n;
        }

        /// <summary>
        /// Devuelve el mayor prefijo del string s que se encuentra en el trie.
        /// </summary>
        public string Prefix(string s)
        {
            Trie temp = this;
            string r = "";
            for (int i = 0; i < s.Length; i++)
            {
                int pos = GetPosition(s[i]);
                temp = temp.Childrens[pos];
                if (temp == null)
                    break;
                r += s[i];
            }
            return r;
        }
    }

    class Program
    {
        public static void PrintTrie(Trie trie, string s)
        {
            if (trie.End > 0)
            {
                for (int i = 0; i < trie.End; i++)
                {
                    Console.WriteLine(s);
                }
                return;
            }
            else
            {
                for (int i = 0; i < trie.Childrens.Length; i++)
                {
                    if (trie.Childrens[i] != null)
                    {
                        s += trie.Childrens[i].Value;
                        PrintTrie(trie.Childrens[i], s);
                    }
                }
                return;
            }
        }

        static void Main(string[] args)
        {
            Trie trie = new Trie();

            trie.Insert("aaaaa", 1);
            trie.Insert("abbb", 2);
            trie.Insert("aba", 2);

            PrintTrie(trie, "");
        }
    }
}
