using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Märkmed
{
    ///<summary>
    /// Contains the writing part of the note application.
    /// Done with XmlSerializer.
    /// </summary>
    class Kirjutamine
    {
        public void Kirjutaja()
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
                using (var reader = XmlReader.Create("../.../märkmed.xml"))
                {
                    märkmed = (List<Märge>)serializer.Deserialize(reader);
                }

                var märge2 = new Märge() { Pealkiri = pealkiri, Sisu = sisu };
                märkmed.Add(märge2);

                using (var writer = XmlWriter.Create("../.../märkmed.xml"))
                {
                    serializer.Serialize(writer, märkmed);
                }
            }
        }
    }
}
