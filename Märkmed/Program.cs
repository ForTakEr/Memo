using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Märkmed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Märkmete salvestamine
            
            while (true)
            {
                Console.WriteLine("\nPalun valige, mida soovite teha" +
                   "\n1. Lugeda märkmeid" +
                   "\n2. Kirjutada märkmeid" +
                   "\n3. Kustutada kõik märkmed" +
                   "\n4. Väljuda programmist");
                var cmd = Console.ReadLine();
                Console.WriteLine();

                if (cmd == "1")
                {
                    Lugemine lugemine = new Lugemine();
                    lugemine.Luger();
                }
                if (cmd == "2")
                {
                    Kirjutamine kirjutamine = new Kirjutamine();
                    kirjutamine.Kirjutaja();
                }
                if (cmd == "3")
                {
                    File.Delete("../.../märkmed.xml");
                }
                if (cmd == "4")
                {
                    Environment.Exit(0);
                } 
            }
        }
    }
}
