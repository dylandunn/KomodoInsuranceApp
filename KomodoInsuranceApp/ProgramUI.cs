using KomodoInsurance.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceApp
{
    class ProgramUI
    {
        

         private DeveloperRepo devRepo = new DeveloperRepo();
         private DevTeamRepos devTeamRepo = new DevTeamRepos();
        //Method That Runs/Starts app
        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                // Display Options To User
                Console.WriteLine("Select an option \n" +
                    "1. Create New Developer Team\n" +
                    "2. View Existing Developer Teams\n" +
                    "3. Add new Developer\n" +
                    "4. View All Developers\n" +
                    "5. View Developers by ID Number\n" +
                    "6. Update Existing Developer Team\n" +
                    "7. Remove Existing Developer Team\n" +
                    "8. Update Existing Developer\n" +
                    "9. Remove Existing Developer\n" +
                    "10. Exit");




                // Get Users Inpit
                string input = Console.ReadLine();

                // Evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Team
                        CreateNewDevTeam();
                        break;
                    case "2":
                        //View Existing Teams
                        ViewExistingDeveloperTeams();
                        break;
                    case "3":
                        // Add New Dev
                        AddNewDeveloper();
                        break;
                    case "4":
                        //View Devs
                        ViewAllDevelopers();
                        break;
                    case "5":
                        //View Dev by ID
                        ViewDevelopersByIDNumber();
                        break;
                    case "6":
                        //Update Dev Team
                        UpdateExistingDeveloperTeam();
                        break;
                    case "7":
                        //Remove Dev Team
                        RemoveExistingDeveloperTeam();
                        break;
                    case "8":
                        //Update Dev
                        UpdateExistingDeveloper();
                        break;
                    case "9":
                        //Remove Dev
                        RemoveExistingDeveloper();
                        break;
                    case "10":
                        Console.WriteLine("GoodBye!");
                        keepRunning = false;
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;

                }
                Console.WriteLine("Please Press Any Key To Continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        //Create new Dev Team
        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter Team Name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter Team ID:");
            string teamIdAsString = Console.ReadLine();
            newTeam.TeamID = int.Parse(teamIdAsString);

            Console.WriteLine("Enter ID of Developer You Want to Add to Team:");
            string devIdAsString = Console.ReadLine(); //Ask Phill
            int devIdAsInt = int.Parse(devIdAsString);
            newTeam.Devlopers.Add(devRepo.GetDeveloperByIDNumber(devIdAsInt)); // Diffcult Code, Great Refrence Point // Ask Phil

            devTeamRepo.AddDevTeamToList(newTeam);
        }
        //View Existing Teams
        private void ViewExistingDeveloperTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = devTeamRepo.GetDevTeamList();

            foreach(DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.TeamName}\n" +
                    $"Team ID: {devTeam.TeamID}\n" +
                    $"Developers: ");
                foreach (Developer developer in devTeam.Devlopers)
                {
                    Console.WriteLine($"{developer.FirstName} {developer.LastName}");

                }
            }

        }
        //Add New Developer
        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            Console.WriteLine("Enter Developer First Name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Developer Last Name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Enter Developer ID Number:");
            string idNumAsString = Console.ReadLine();
            newDev.IdNumber = int.Parse(idNumAsString);

            Console.WriteLine("Does Developer Have Access to Pluralsight? (y/n)");
            string hasAccessAsString = Console.ReadLine().ToLower();

            if (hasAccessAsString == "y")
            {
                newDev.HasAccessToPluralsight = true;
            }
            else
            {
                newDev.HasAccessToPluralsight = false;
            }

            devRepo.AddDeveloperToList(newDev);
            
        }
        // View All Developers
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = devRepo.GetDeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Has Access to Pluralsight: {developer.HasAccessToPluralsight}\n" +
                    $"----------------------");
            }
        }
        // View Developers by ID
        private void ViewDevelopersByIDNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter Developer ID Number:");

            string idNumberAsString = Console.ReadLine();
            int idNumberAsInt = int.Parse(idNumberAsString); 

            Developer developer = devRepo.GetDeveloperByIDNumber(idNumberAsInt);

            if (developer != null)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Has Access to Pluralsight: {developer.HasAccessToPluralsight}");
            }
            else
            {
                Console.WriteLine("Enter a valid developer ID");
            }
        }
        // Update Dev Team
        private void UpdateExistingDeveloperTeam()
        {
            Console.Clear();
            ViewExistingDeveloperTeams();
            Console.WriteLine("Enter name of team you would like to update");
            string oldTeam = Console.ReadLine();

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter Team Name:");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter Team ID:");
            string teamIdAsString = Console.ReadLine();
            newTeam.TeamID = int.Parse(teamIdAsString);

            Console.WriteLine("Enter ID of Developer You Want to Add to Team:");
            string devIdAsString = Console.ReadLine(); //Ask Phill
            int devIdAsInt = int.Parse(devIdAsString);
            newTeam.Devlopers.Add(devRepo.GetDeveloperByIDNumber(devIdAsInt));

            Console.WriteLine("Enter ID of developer you want to remove");
            string devIdString = Console.ReadLine(); //Ask Phill
            int devIdInt = int.Parse(devIdString);
            newTeam.Devlopers.Remove(devRepo.GetDeveloperByIDNumber(devIdInt));

            bool wasUpdate = devTeamRepo.UpdateExistingDevTeamByTeamName(oldTeam, newTeam); 
            if (wasUpdate)
            {
                Console.WriteLine("Team Updated");
            }
            else
            {
                Console.WriteLine("Could not update team");
            }

        }
        // Remove Dev Team
        private void RemoveExistingDeveloperTeam()
        {
            Console.Clear();

            ViewExistingDeveloperTeams();
            Console.WriteLine("\n Enter name of team you would like to remove:");

            string input = Console.ReadLine();

            bool wasDeleted = devTeamRepo.RemoveDevTeamFromListByTeamName(input);
            if(wasDeleted)
            {
                Console.WriteLine("The Team was deleted");
            }
            else
            {
                Console.WriteLine("Team Could not be deleted");
            }

            

        }
        // Update Developer
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            ViewAllDevelopers();

            Console.WriteLine("Enter ID of developer you would like to update");

            string oldIdNumberAsString = Console.ReadLine();
            int oldIdNumberAsInt = int.Parse(oldIdNumberAsString);

            Developer newDev = new Developer();

            Console.WriteLine("Enter Developer First Name:");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Developer Last Name:");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("Enter Developer ID Number:");
            string idNumAsString = Console.ReadLine();
            newDev.IdNumber = int.Parse(idNumAsString);

            Console.WriteLine("Does Developer Have Access to Pluralsight? (y/n)");
            string hasAccessAsString = Console.ReadLine().ToLower();

            if (hasAccessAsString == "y")
            {
                newDev.HasAccessToPluralsight = true;
            }
            else
            {
                newDev.HasAccessToPluralsight = false;
            }
            bool wasUpdate = devRepo.UpdateExistingDeveloper(oldIdNumberAsInt, newDev);
            if (wasUpdate)
            {
                Console.WriteLine("Developer successfully updated.");
            }
            else
            {
                Console.WriteLine("Developer Could not be updated");
            }

        }
        //Remove Developer
        private void RemoveExistingDeveloper()
        {
            Console.Clear();

            ViewAllDevelopers();
            Console.WriteLine("Enter The ID of Developer You Would Like To Remove");
            string inputAsString = Console.ReadLine();
            int inputAsInt = int.Parse(inputAsString);
            bool wasDeleted = devRepo.RemoveDeveloperFromList(inputAsInt);
            if (wasDeleted)
            {
                Console.WriteLine("The Developer Was Removed");
            }
            else
            {
                Console.WriteLine("Developer Could not be removed");
            }

        }
       
        //Seed Method
        private void SeedDeveloperList()
        {
            Developer dylan = new Developer(false, "Dylan", "Dunn", 082299);
            Developer phil = new Developer(true, "Phil", "Smith", 054499);
            Developer justin = new Developer(false, "Justin", "Fields", 095588);
            Developer tarik = new Developer(true, "Tarik", "Cohen", 074455);
            Developer walter = new Developer(false, "Walter", "Payton", 067782);
            Developer mike = new Developer(true, "Mike", "Ditka", 049983);

            devRepo.AddDeveloperToList(dylan);
            devRepo.AddDeveloperToList(phil);
            devRepo.AddDeveloperToList(justin);
            devRepo.AddDeveloperToList(tarik);
            devRepo.AddDeveloperToList(walter);
            devRepo.AddDeveloperToList(mike);
        }
        
        
    }
}
