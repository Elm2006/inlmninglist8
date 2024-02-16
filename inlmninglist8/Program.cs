using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hur många koder vill du skriva in?");
        int gånger = int.Parse(Console.ReadLine());
        Dictionary<char,char> koder = new Dictionary<char,char>();
        for (int i = 0; i < gånger; i++)
        {
            string svar = Console.ReadLine().ToLower();
            koder.Add(svar[0], svar[2]);
        }
        Console.WriteLine("Skriv in ditt hemliga ord");
        string hOrd = Console.ReadLine().ToLower();
        char[] bokstäver = new char[hOrd.Length];
        for (int i = 0; i<hOrd.Length; i++)
        {
            if (koder.ContainsKey(hOrd[i]))
            {
                bokstäver[i] += koder[hOrd[i]];
                for (int j = 0; j < gånger-1; j++)
                {
                    if (koder.ContainsKey(bokstäver[i]))
                    {
                        bokstäver[i] = koder[bokstäver[i]];
                    }
                }
            }
            else
            {
                bokstäver[i] += hOrd[i];
            }
        }
        Console.WriteLine("Här är din avkodade kod");
        for (int i =0; i<bokstäver.Length; i++)
        {
            Console.Write(bokstäver[i]);
        }
        Console.WriteLine();
    }
}