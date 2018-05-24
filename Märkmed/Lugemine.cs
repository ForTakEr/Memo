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
    ///Contains the reading part for the note application.
    ///Done with XmlSerializer.
    /// </summary>
    class Lugemine
    {
        /// <summary>
        /// Uses XmlSerializer to read the xml file and output it to the console.
        /// </summary>
        public void Luger()
        {
           if (!File.Exists("../.../märkmed.xml"))
           {
               Console.WriteLine("Faili, millest märkmeid lugeda pole olemas.");
           }
           else
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
        }
    }
}
