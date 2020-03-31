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

        public bool Equals(ContactData otherFirstName)
        {
            if (Object.ReferenceEquals(otherFirstName, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, otherFirstName))
            {
                return true;
            }

            return FirstName == otherFirstName.FirstName;
        }

        public int CompareTo(ContactData otherFirstName)
        {
            if (Object.ReferenceEquals(otherFirstName, null))
            {
                return 1;
            }

            return FirstName.CompareTo(otherFirstName.FirstName);
        }

        public ContactData(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }


        public bool Equals(ContactData otherFirstName, ContactData otherLastName)
        {
            if ((Object.ReferenceEquals(otherFirstName, null)) &
               (Object.ReferenceEquals(otherLastName, null)))
            {
                return false;
            }

            if ((Object.ReferenceEquals(this.FirstName, otherFirstName)) &
               (Object.ReferenceEquals(this.LastName, otherLastName)))
            {
                return true;
            }

            return LastName == otherLastName.LastName
                 & FirstName == otherFirstName.FirstName;
        }


        public override int GetHashCode()
        {
            return (LastName.GetHashCode())
                 & (LastName.GetHashCode());
        }

        public override string ToString()
        {
            return LastName + " " + FirstName;

        }

        public int CompareTo(ContactData otherFirstName, ContactData otherLastName)
        {
            if ((Object.ReferenceEquals(otherFirstName, null)) &
                (Object.ReferenceEquals(otherLastName, null)))
            {
                return 1;
            }

            return FirstName.CompareTo(otherFirstName.FirstName) 
                 & LastName.CompareTo(otherLastName.LastName);
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }
    }
}
