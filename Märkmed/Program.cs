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

                //Lugemine
                if (cmd == "1")
                {
                    var märkmed = new List<Märge>();
                    var serializer = new XmlSerializer(typeof(List<Märge>));
                    using (var reader = XmlReader.Create("../.../märkmed.xml"))
                    {
                        märkmed = (List<Märge>)serializer.Deserialize(reader);
                    }

                    foreach (var märge in märkmed)
                    {
                        Console.WriteLine("Pealkiri: " + märge.Pealkiri + " || Sisu: " + märge.Sisu);
                    }
                }
                //Kirjutamine
                if (cmd == "2")
                {
                    var märkmed = new List<Märge>();
                    Console.WriteLine("Pealkiri: ");
                    string pealkiri = Console.ReadLine();
                    Console.WriteLine("Sisu: ");
                    string sisu = Console.ReadLine();
                    var märge = new Märge() { Pealkiri = pealkiri, Sisu = sisu };
                    märkmed.Add(märge);
                    var serializer = new XmlSerializer(märkmed.GetType());
                    if (!File.Exists("../.../märkmed.xml"))
                    {
                        using (var writer = XmlWriter.Create("../.../märkmed.xml"))
                        {
                            serializer.Serialize(writer, märkmed);
                        } 
                    }
                    else if (File.Exists("../.../märkmed.xml"))
                    {
                        var doc = new XmlDocument();
                        doc.Load("../.../märkmed.xml");
                        var rootNode = doc.GetElementsByTagName("Märge")[0];
                        var nav = rootNode.CreateNavigator();
                        var emptyNamespaces = new XmlSerializerNamespaces(new[] {
                        XmlQualifiedName.Empty });

                        using (var writer = nav.AppendChild())
                        {
                            writer.WriteWhitespace("");
                            serializer.Serialize(writer, märkmed, emptyNamespaces);
                        }
                    }
                }
                //Kustutamine
                if (cmd == "3")
                {
                    File.Delete("../.../märkmed.xml");
                }
                //Exit
                if (cmd == "4")
                {
                    Environment.Exit(0);
                } 
            }
        }
    }
}
