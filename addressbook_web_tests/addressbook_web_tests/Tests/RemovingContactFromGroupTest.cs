using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {
            app.Groups.GroupIsPresent();
            app.Contacts.ContactIsPresent();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = ContactData.GetAll();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
