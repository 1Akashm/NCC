using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{

    public class Question1
    {
        private string cs;

        public Question1(string cs)
        {
            this.cs = cs;
        }

        public void Insert()
        {

            try
            {


                Console.WriteLine("Enter the ID : ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the name : ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Department : ");
                string department = Console.ReadLine();

                Console.WriteLine("Enter the Address : ");
                string address = Console.ReadLine();

                Console.WriteLine("Enter the Email : ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter the Position : ");
                string position = Console.ReadLine();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Insert into tbl_employee(id,name,department,address,email,position) values (@id,@name,@department,@address,@email,@position)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@position", position);
                    con.Open();

                    int row = cmd.ExecuteNonQuery();

                    if (row > 0)
                    {
                        Console.WriteLine("Inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert.");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : of insert " + ex.Message);
            }
        }

        public void display()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Select id,name,department,address,email,position from tbl_employee";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool datafound = false; // flag to check the data

                    while (reader.Read())
                    {
                        datafound = true; //check if data
                        int id = (int)reader["id"];
                        string name = (string)reader["name"];
                        string department = (string)reader["department"];
                        string email = (string)reader["email"];
                        string address = (string)reader["address"];
                        string position = (string)reader["position"];

                        Console.WriteLine($"ID = {id}, Name = {name}, department = {department}, email= {email}, Address = {address}, Position = {position}");

                    }
                    
                    if(!datafound) // if false run this line of code 
                    {
                        Console.WriteLine("No data to display");
                    }

                    reader.Close();
                    
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : of display " + ex.Message);
            }
        }

        public void delete()
        {
            try
            {
                Console.WriteLine("Enter the ID to delete : ");
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Delete from tbl_employee where id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);

                    int row = cmd.ExecuteNonQuery();

                    if (row > 0)
                    {
                        Console.WriteLine("Record deletd for id " + @id);
                    }

                    else
                    {
                        Console.WriteLine("no record found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errror : of delete " + ex.Message);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                string cs = "Data Source= AKASH\\SQLEXPRESS;Initial Catalog = tbl_std;Integrated Security=true";
                Question1 que = new Question1(cs);

                string choice, ch;
                do
                {
                    Console.WriteLine("1. Insert ");
                    Console.WriteLine("2. Display ");
                    Console.WriteLine("3. Delete");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter you choice : ");
                    choice = Console.ReadLine().ToLower();

                    switch (choice)
                    {
                        case "1":
                            que.Insert();
                            break;
                        case "2":
                            que.display();
                            break;
                        case "3":
                            que.delete();
                            break;
                        case "4":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    Console.WriteLine("Do you want to continue : ");
                    ch = Console.ReadLine();
                }
                while (ch.ToLower() == "y");

            }
        }
    }
}