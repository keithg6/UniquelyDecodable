using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquelyDecodable
{
    class Program
    {
        //TEST VALUES {"02", "12", "120", "20", "21"}
        //TEST VALUES { "0", "01", "011" };

        public static HashSet<string> values = new HashSet<string>();
        public static HashSet<string> cinfinite = new HashSet<string>();
        public static int count = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter values for C.");
            string ans = Console.ReadLine();
            string[] nums = ans.Split(' ');
            HashSet<string> C = new HashSet<string>();
            foreach (string i in nums)
            {
                C.Add(i);
            }

            Console.Write("C: ");
            foreach (string i in C) { Console.Write(i + " "); }
            Console.WriteLine();
            compute(C, C);
            Console.WriteLine();
            HashSet<string> unique = new HashSet<string>(C);
            unique.IntersectWith(cinfinite);
            if (unique.Count == 0) { Console.WriteLine("C is uniquely decodable because C and C∞ are mutually disjoint."); }
            else
            {
                Console.Write("C is not uniquely decodable because the element(s)");
                foreach (string i in unique) { Console.Write(" " + i); }
                Console.Write(" are in both C and C∞");
            }
            Console.Read();
        }

        public static HashSet<String> compute(HashSet<string> C, HashSet<string> C1)
        {
            HashSet<string> Cn = new HashSet<string>();
            foreach (string i in C)
            {
                foreach (string j in C1)
                {
                    if (j.Length < i.Length)
                    {
                        if (i.Substring(0, j.Length) == j)
                        {
                            Cn.Add(i.Substring(j.Length, i.Length - j.Length));
                        }
                    }
                }
            }
            Cn.Remove("");
            String vals = "";
            foreach (string i in Cn)
            {
                vals += i + " ";
                cinfinite.Add(i);
            }
            if (values.Contains(vals) || Cn.Count == 0)
            {
                Console.Write("C" + count + ":");
                foreach (string i in Cn) { Console.Write(i + " "); };
                Console.WriteLine();
                Console.Write("C infinite: ");
                foreach (string i in cinfinite)
                {

                    Console.Write(i + " ");
                };
                return Cn;
            }
            else
            {
                Console.Write("C" + count + ":");
                foreach (string i in Cn) { Console.Write(i + " "); };
                Console.WriteLine();
                count++;
                values.Add(vals);
                return compute(C, Cn);
            }

        }
    }
}
