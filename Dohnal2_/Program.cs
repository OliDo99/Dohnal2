using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Xml.Linq;

namespace Dohnal2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "subor1.dta", "subor2.dta" };
            int[] pocty = { 10, 10 };
            int[] minMax = { 0, 100 };
            Zapisujem(names, pocty, minMax);
            Vypisujem(names[0]);
            Console.WriteLine();
            Vypisujem(names[1]);
            ViacParnych(names);

            Console.ReadLine();
        }
        static void Zapisujem(string[] names,int[] pocty, int[] minMax)
        {
            Random rand = new Random();
            for(int i  = 0; i < names.Length; i++)
            {
                using (Stream stream = new FileStream(names[i], FileMode.Create, FileAccess.Write))
                using (BinaryWriter bWriter = new BinaryWriter(stream))
                {
                    for (int x = 0; x < pocty[i]; x++)
                    { 
                        bWriter.Write(rand.Next(minMax[0], minMax[1] + 1));
  
                    }
                }
            }
        }
        static void Vypisujem(string name)
        {
            using (Stream stream = new FileStream(name, FileMode.Open, FileAccess.Read))
            using (BinaryReader bReader = new BinaryReader(stream))
            {
                while (stream.Position < stream.Length)
                {
                    Console.WriteLine(bReader.ReadInt32());
                }
            }
        }
        static void ViacParnych(string[] names) 
        {
            int[] viac = { 0,0 };
            for (int i = 0; i < names.Length; i++)
            {
                using (Stream stream = new FileStream(names[i], FileMode.Open, FileAccess.Read))
                using (BinaryReader bReader = new BinaryReader(stream))
                {
                    while (stream.Position < stream.Length)
                    {
                        if (Convert.ToInt32(bReader.ReadInt32()) % 2 == 0)
                        {
                            viac[i]++;
                        }
                    }
                }
            }
            if (viac[0] > viac[1])
            {
                Console.WriteLine(names[0] + " ma viac parnych");
            }
            else if(viac[0] < viac[1])
            {
                Console.WriteLine(names[1] + " ma viac parnych");
            }
            else
            {
                Console.WriteLine(names[0] + " a " + names[1] + " maju rovnako vela parnych");
            }
        }
    }
}
