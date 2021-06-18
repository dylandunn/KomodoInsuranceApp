using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.Library
{
    public class DeveloperRepo
    {
        private List<Developer> _listofDevelopers = new List<Developer>();

        //Create
        public void AddDeveloperToList(Developer developer)
        {
            _listofDevelopers.Add(developer);
        }

        

     
        
        //Read
        public List<Developer> GetDeveloperList()
        {
            return _listofDevelopers;
        }

        //Update
        public bool UpdateExistingDeveloper(int originalIdNumber, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByIDNumber(originalIdNumber);
            if (oldDeveloper != null)
            {
                oldDeveloper.IdNumber = newDeveloper.IdNumber;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.HasAccessToPluralsight = newDeveloper.HasAccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        

        //Delete
        public bool RemoveDeveloperFromList(int idNumber)
        {
            Developer developer = GetDeveloperByIDNumber(idNumber);

            if (developer == null)
            {
                return false;
            }

            int initialCount = _listofDevelopers.Count;
            _listofDevelopers.Remove(developer);

            if(initialCount > _listofDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }
        

        //Helper method
        public Developer GetDeveloperByIDNumber(int idNumber)
        {
            foreach(Developer developer in _listofDevelopers)
            {
                if(developer.IdNumber == idNumber)
                {
                    return developer;
                }
            }

            return null;
        }
    }
}
