using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
namespace RamParkQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=ram-park-sql-server.database.windows.net;Initial Catalog=RamParkDatabase;Persist Security Info=True;User ID=Garavuso;Password=Vinny1234");
            
            SimplePriorityQueue<User> priorityQueue = new SimplePriorityQueue<User>();

            //Get all users in DB for demo
            string query = "SELECT * FROM USERS";
            var command = new SqlCommand(query, myConnection);
            myConnection.Open();
            var reader = command.ExecuteReader();
            User u;
            Console.WriteLine("Order of users being added to queue: \n");
            while(reader.Read())
            {
                u = new User();
                u.RAM_ID = Int32.Parse(Convert.ToString(reader[0]));
                u.FirstName = Convert.ToString(reader[1]);
                u.LastName = Convert.ToString(reader[2]);
                u.Email = Convert.ToString(reader[3]);
                u.RAM_Points = Int32.Parse(Convert.ToString(reader[4]));
                ////u.Employee = Convert.ToString(reader[5]);
                u.Password = Convert.ToString(reader[6]);
                u.Phone = Convert.ToString(reader[7]);
                Console.WriteLine(u.ToString());
                //Add all users to queue and display add order
                priorityQueue.Enqueue(u, u.RAM_Points);
            }
            reader.Close();

            Console.WriteLine("\n\nOrder of users in the Queue: \n");
            displayQueue(priorityQueue);
            Console.WriteLine("\n\nDequeue first: " + priorityQueue.Dequeue());
            Console.WriteLine("\n\nCurrent Queue: \n");
            displayQueue(priorityQueue);
            Console.WriteLine("\n\nDequeue next: " + priorityQueue.Dequeue());
            Console.WriteLine("\n\nCurrent Queue: \n");
            displayQueue(priorityQueue);
            Console.WriteLine("\n\nDequeue next: " + priorityQueue.Dequeue());
            Console.WriteLine("\n\nCurrent Queue: \n");
            displayQueue(priorityQueue);
            //Display Queue
            //Dequeue first
            //Display Queue
        }
        private static void displayQueue(SimplePriorityQueue<User> priorityQueue)
        {
            foreach (User u in priorityQueue)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}
