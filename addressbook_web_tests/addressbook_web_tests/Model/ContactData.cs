﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;
        public string allEmails;
        public string allInformations;

        public ContactData()
        {
        }

        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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

            return FirstName == other.FirstName && 
                   LastName == other.LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
                return FirstName.CompareTo(other.FirstName);

            return LastName.CompareTo(other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode()
                 & LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstName=" + FirstName + "\nlastName=" + LastName;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                
                
                }
            
            }

            set
            {
                allPhones = value;
            }
        
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();


                }

            }

            set
            {
                allEmails = value;
            }

        }

        public string AllInformations
        {
            get
            {
                return (CleanUp(allInformations).Trim());
            }

            set
            {
                allInformations = value;
            }

        }



        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

    }
}
