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


                Console.WriteLine("Enter the roll number : ");
                int roll = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the name : ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the Phone : ");
                string phone = Console.ReadLine();

                Console.WriteLine("Enter the Faculty : ");
                string faculty = Console.ReadLine();

                Console.WriteLine("Enter the Address : ");
                string address = Console.ReadLine();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Insert into Std_tbl(roll,name,phone,faculty,address) values (@roll,@name,@phone,@faculty,@address)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@roll", roll);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@faculty", faculty);
                    cmd.Parameters.AddWithValue("@address", address);
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
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        public void display()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Select roll,name,phone,faculty,address from Std_tbl";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        int roll = (int)reader["roll"];
                        string name = (string)reader["name"];
                        string phone = (string)reader["phone"];
                        string faculty = (string)reader["faculty"];
                        string address = (string)reader["address"];

                        Console.WriteLine($"Roll = {roll}, Name = {name}, phone = {phone}, Faculty = {faculty}, Address = {address}");
                        
                    }
                    reader.Close();
                    Console.WriteLine("No data to display");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("Error : " +ex.Message);
            }
        }

        public void delete()
        {
            try
            {
                Console.WriteLine("Enter the name to delete : ");
                string name = Console.ReadLine();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "Delete from Std_tbl where name = @name";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);

                    int row = cmd.ExecuteNonQuery();

                    if(row > 0)
                    {
                        Console.WriteLine("Record deletd for name " + @name);
                    }

                    else
                    {
                        Console.WriteLine("no record found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errror : " + ex.Message);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                string cs = "Data Source= AKASH\\SQLEXPRESS;Initial Catalog = tbl_std;Integrated Security=true";
                Question1 que = new Question1(cs);

                string choice,ch;
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