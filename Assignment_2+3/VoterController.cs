using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_3
{
    public class VoterController
    {
        private VoterModel model = new VoterModel();

        public void Add()
        {
            Console.WriteLine("Enter Voter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Voter Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Voter Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Voter City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Voter DOB ( as DD/MM/YYYY ):");
            string dob = Console.ReadLine();
            Console.WriteLine("Enter Voter Religion:");
            string religion = Console.ReadLine();
            Console.WriteLine("Enter Voter Gender:");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter Voter MaritalStatus:");
            string maritalstatus = Console.ReadLine();
            Console.WriteLine("Enter Voter Nationality:");
            string nationality = Console.ReadLine();
            Console.WriteLine("Enter Voter Country:");
            string country = Console.ReadLine();
            Console.WriteLine("Enter Voter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Voter PhoneNumber:");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Enter Voter JobStatus:");
            string jobstatus = Console.ReadLine();

            Voter voter = new Voter { Name = name, Age = age, Address = address, City = city, DOB = dob, Religion = religion, Gender = gender, MaritalStatus = maritalstatus, Nationality = nationality, Country = country, Email = email, phoneNumber = phonenumber, jobStatus = jobstatus };
            model.Add(voter);
        }

        public void Delete()
        {
            Console.WriteLine("Enter Voter ID:");
            int id = int.Parse(Console.ReadLine());

            model.Delete(id);
        }

        public void GetAll()
        {

            List<Voter> voters = model.GetAll();

            if (voters.Count == 0)
            {
                Console.WriteLine("No voters found!");
            }
            else
            {
                foreach (Voter voter in voters)
                {
                    Console.WriteLine($"Id: {voter.Id}, Name: {voter.Name}, Age: {voter.Age}, Address: {voter.Address}, City: {voter.City}, DOB: {voter.DOB}, Religion: {voter.Religion}, Gender: {voter.Gender}, MaritalStatus: {voter.MaritalStatus}, Nationality: {voter.Nationality}, Country: {voter.Country}, Email: {voter.Email}, phoneNumber: {voter.phoneNumber}, jobStatus: {voter.jobStatus}");
                    Console.WriteLine("");
                }
            }

            voters.Clear();
        }

        public void GetID()
        {
            List<Voter> voters = model.GetID();

            if (voters.Count == 0)
            {
                Console.WriteLine("No voters found!");
            }
            else
            {
                foreach (Voter voter in voters)
                {
                    Console.WriteLine($"Id: {voter.Id}, Name: {voter.Name}, Age: {voter.Age}, Address: {voter.Address}, City: {voter.City}, DOB: {voter.DOB}, Religion: {voter.Religion}, Gender: {voter.Gender}, MaritalStatus: {voter.MaritalStatus}, Nationality: {voter.Nationality}, Country: {voter.Country}, Email: {voter.Email}, phoneNumber: {voter.phoneNumber}, jobStatus: {voter.jobStatus}");
                    Console.WriteLine("");
                }
            }
            voters.Clear();
        }
    }

}
