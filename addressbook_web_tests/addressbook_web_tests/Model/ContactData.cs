using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return LastName == other.LastName && 
                   FirstName == other.FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other.LastName, this.LastName))
            {
                FirstName.CompareTo(other.FirstName);
                return 1;
            }
            return LastName.CompareTo(other.LastName);
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode()
                 & FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return LastName + " " + FirstName;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }
    }
}
