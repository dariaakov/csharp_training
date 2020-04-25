using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10))
                {
                    LastName = GenerateRandomString(30),
                });

            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contacts)
        {

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contacts);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contacts);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        //[Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
