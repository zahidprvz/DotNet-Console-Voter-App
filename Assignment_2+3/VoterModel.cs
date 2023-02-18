using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Collections.Immutable;

namespace Assignment_2_3
{
    
    public class VoterModel
    {
        SqlConnection con = new SqlConnection("Data Source=ZAHIDPARVIZ;Initial Catalog=ZahidDB;User ID=sa;Password=abc123");

        private List<Voter> voters = new List<Voter>();

        public void Add(Voter voter)
        {
            voter.Id = voters.Count + 1;
            voters.Add(voter);
            // save the voter to the database

            try
            {
                con.Open();

                Console.Write("Connected to Database..!");


                string insertStatement = "INSERT INTO VoterTable (Name, Age, Address, City, DOB, Religion, Gender, MaritalStatus, Nationality, Country, Email, phoneNumber, jobStatus) VALUES (@Name, @Age, @Address, @City, @DOB, @Religion, @Gender, @MaritalStatus, @Nationality, @Country, @Email, @phoneNumber, @jobStatus)";

                SqlCommand command = new SqlCommand(insertStatement, con);

                foreach (Voter voter1 in voters)
                {
                    command.Parameters.AddWithValue("@Name", voter.Name);
                    command.Parameters.AddWithValue("@Age", voter.Age);
                    command.Parameters.AddWithValue("@Address", voter.Address);
                    command.Parameters.AddWithValue("@City", voter.City);
                    command.Parameters.AddWithValue("@DOB", voter.DOB);
                    command.Parameters.AddWithValue("@Religion", voter.Religion);
                    command.Parameters.AddWithValue("@Gender", voter.Gender);
                    command.Parameters.AddWithValue("@MaritalStatus", voter.MaritalStatus);
                    command.Parameters.AddWithValue("@Nationality", voter.Nationality);
                    command.Parameters.AddWithValue("@Country", voter.Country);
                    command.Parameters.AddWithValue("@Email", voter.Email);
                    command.Parameters.AddWithValue("@phoneNumber", voter.phoneNumber);
                    command.Parameters.AddWithValue("@jobStatus", voter.jobStatus);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("pervaizzahid55@gmail.com");
                    msg.To.Add(voter.Email);
                    msg.Subject = "Pakistan Election Commission";
                    msg.Body = "Hello " + voter.Name + "\n\nWelcome to PEC.\nYou have been registered as a Verified Voter!\nNow you can give your vote to any of the Political Party";

                    SmtpClient smt = new SmtpClient();
                    smt.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential ntcd = new NetworkCredential();
                    ntcd.UserName = "pervaizzahid55@gmail.com";
                    ntcd.Password = "qdnjjecciqgnscfa";
                    smt.Credentials = ntcd;
                    smt.EnableSsl = true;
                    smt.Port = 587;
                    smt.Send(msg);

                    Console.WriteLine("\nYour Mail is sended");
                }
                catch (Exception ex)
                {

                    Console.Write(ex.ToString());
                }

                Console.Write("\n\nNew Voter Added in Database successfully...");
            }
            catch (Exception exx)
            {

                Console.Write(exx.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void Delete(int id)
        {
                // delete the voter from the database
                try
                {
                    con.Open();
                
                    Console.WriteLine("Successfully connected to Database!");

                    string deleteStatement = "DELETE FROM VoterTable WHERE Id = " + id;

                    SqlCommand command = new SqlCommand(deleteStatement, con);

                    int rowsAffected = command.ExecuteNonQuery();




            }
            catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            Console.WriteLine("Voter Deleted Successfully..!");
        }


        public List<Voter> GetAll()
        {
            // retrieve all voters from the database

            try
            {
                con.Open();

                Console.Write("\nSuccessfully connected to Database!\n\n");

                string selectStatement = "SELECT Id, Name, Age, Address, City, DOB, Religion, Gender, MaritalStatus, Nationality, Country, Email, phoneNumber, jobStatus FROM VoterTable";

                SqlCommand command = new SqlCommand(selectStatement, con);

           
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Voter voter = new Voter();
                    voter.Id = Convert.ToInt32(reader["Id"]);
                    voter.Name = reader["Name"].ToString();
                    voter.Age = reader["Age"].ToString();
                    voter.Address = reader["Address"].ToString();
                    voter.City = reader["City"].ToString();
                    voter.DOB = reader["DOB"].ToString();
                    voter.Religion = reader["Religion"].ToString();
                    voter.Gender = reader["Gender"].ToString();
                    voter.MaritalStatus = reader["MaritalStatus"].ToString();
                    voter.Nationality = reader["Nationality"].ToString();
                    voter.Country = reader["Country"].ToString();
                    voter.Email = reader["Email"].ToString();
                    voter.phoneNumber = reader["phoneNumber"].ToString();
                    voter.jobStatus = reader["jobStatus"].ToString();

                    voters.Add(voter);
                }
                reader.Close();


            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
            finally 
            { 
                con.Close();
            }
            return voters;
        }

        public List<Voter> GetID()
        {
            //Retreive data of a specific voter through ID
            Console.WriteLine("Enter #Id to fetch data of that Voter:");
            int voterId = Convert.ToInt32(Console.ReadLine());

            try
            {
                con.Open();

                Console.Write("\nSuccessfully connected to Database!\n\n");

                string selectStatement = "SELECT Id, Name, Age, Address, City, DOB, Religion, Gender, MaritalStatus, Nationality, Country, Email, phoneNumber, jobStatus FROM VoterTable where Id = " + voterId;

                SqlCommand command = new SqlCommand(selectStatement, con);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Voter voter = new Voter();
                    voter.Id = Convert.ToInt32(reader["Id"]);
                    voter.Name = reader["Name"].ToString();
                    voter.Age = reader["Age"].ToString();
                    voter.Address = reader["Address"].ToString();
                    voter.City = reader["City"].ToString();
                    voter.DOB = reader["DOB"].ToString();
                    voter.Religion = reader["Religion"].ToString();
                    voter.Gender = reader["Gender"].ToString();
                    voter.MaritalStatus = reader["MaritalStatus"].ToString();
                    voter.Nationality = reader["Nationality"].ToString();
                    voter.Country = reader["Country"].ToString();
                    voter.Email = reader["Email"].ToString();
                    voter.phoneNumber = reader["phoneNumber"].ToString();
                    voter.jobStatus = reader["jobStatus"].ToString();

                    voters.Add(voter);
                }
                reader.Close();


            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return voters;
            
        }
    }

}
