using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_3
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            Voter voter= new Voter();
            VoterModel model= new VoterModel();
            VoterController controller= new VoterController();

            Console.WriteLine("\n\t\t**************************************************");
            Console.WriteLine("\t\t* -----Welcome to Online Voting Application----- *");
            Console.WriteLine("\t\t**************************************************");

            while (true)
            {
                Console.WriteLine("\n*********************************************************************************");
                Console.WriteLine("*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("*What function/service do you want to Perform?                       \t\t*");
                Console.WriteLine("*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("*Press 1==> To Add a new voter in Database and VoterList\t\t\t*");
                Console.WriteLine("*Press 2==> To Delete an existing voter from Database and VoterList\t\t*");
                Console.WriteLine("*Press 3==> To view the List of all existing Voters\t\t\t\t*");
                Console.WriteLine("*Press 4==> To view a specific Record from Database using ID\t\t\t*");
                Console.WriteLine("*Press any other Number==> To again go to main menu\t\t\t\t*");
                Console.WriteLine("*Press 5==> To exit Program\t\t\t\t\t\t\t*");
                Console.WriteLine("*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("*********************************************************************************");

                int userDemand = Convert.ToInt32(Console.ReadLine());


                switch (userDemand)
                {
                    case 1:
                        //Add Voter Implementation
                        controller.Add();
                        break;

                    case 2:
                        //Delete Voter Implementation
                        controller.Delete();
                        break;

                    case 3:
                        //Diplaying the list of all Voters in Database/List
                        controller.GetAll();
                        break;

                    case 4:
                        //Displaying a specific user
                        controller.GetID();
                        break;

                }
                if (userDemand == 5)
                    break;
                else
                    continue;
            }
        }
    }
}
