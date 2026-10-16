using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Lab_3_HD2
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            // Load XML file into XmlDocument Instance
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\..\..\books.xml");

            // Get list of nodes whose name is Book
            var nodelist = xmlDoc.DocumentElement.SelectNodes("/catalog/book");

            foreach (XmlNode node in nodelist)
            {
                // Read attribute value
                var isbn = node.Attributes["ISBN"].Value;

                // Read child node value
                var title = node.SelectSingleNode("title").InnerText;
                var price = node.SelectSingleNode("price").InnerText;

                // Read the descendant node value
                var firstName = node.SelectSingleNode("author/first-name").InnerText;
                var lastName = node.SelectSingleNode("author/last-name").InnerText;

                Console.WriteLine("{0,-15}{1,-50}{2,-15}{3,-15}{4,6}",
                    isbn, title, firstName, lastName, price);
            }
        }

    }
}
