using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class Developer
    {
        public bool HasAccessToPluralsight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }

        public Developer() { }

        public Developer(bool hasAccessToPluralsight, string firstName, string lastName, int idNumber)
        {
            HasAccessToPluralsight = hasAccessToPluralsight;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
        }
    }
}
