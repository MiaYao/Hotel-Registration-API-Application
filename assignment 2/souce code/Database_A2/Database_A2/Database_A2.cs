using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Database_A2
{
    class Database_A2
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("**************************************");
                System.Console.WriteLine("***   Hotel Management System      ***");
                System.Console.WriteLine("***                                ***");
                System.Console.WriteLine("***   Command list:                ***");
                System.Console.WriteLine("***   1: New Booking               ***");
                System.Console.WriteLine("***   2: Searching available room  ***");
                System.Console.WriteLine("***   3: Guest Registration        ***");
                System.Console.WriteLine("***   0: Quit System               ***");
                System.Console.WriteLine("***                                ***");
                System.Console.WriteLine("**************************************");
                System.Console.Write("Please enter command number: ");
                string i = System.Console.ReadLine();

                if (i == "1")
                {
                    Booking_Registration.Registration_Booking();
                }
                else if(i == "2")
                {
                    Booking_query.Query_Booking();
                }
                else if (i == "3")
                {
                    Guest_Registration.Registration_Guest();
                }
                else if (i == "0")
                {
                    Console.Clear();
                    System.Console.WriteLine("Thank you for using this system.");
                    break;
                }
                else
                {
                    Console.Clear();
                    MessageBox.Show("Error: Wrong Command!");
                }
            }
        }
    }
}
