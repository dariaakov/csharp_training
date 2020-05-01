using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string dataType = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                if (dataType == "contacts")
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        LastName = TestBase.GenerateRandomString(100)
                    });
                }
                else if (dataType == "groups")
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                else
                {
                    Console.Out.Write("Unrecognized data type " + dataType);
                }
            }
            if (format == "xml" && dataType == "groups")
            {
                writeGroupsToXMLFile(groups, writer);
            }
            else if (format == "json" && dataType == "groups")
            {
                writeGroupsToJsonFile(groups, writer);
            }
            else if (format == "xml" && dataType == "contacts")
            {
                writeContactsToXMLFile(contacts, writer);
            }
            else if (format == "json" && dataType == "contacts")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
        }



        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));

        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.FirstName, contact.LastName));
            }
        }

        static void writeContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);

        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));

        }
    }
}
