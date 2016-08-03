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
    class Booking_Registration
    {
        public static string GenerateRandomNumber()
        {
            Random ro = new Random();
            StringBuilder RandomNum = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                RandomNum.Append(ro.Next(0, 9));
            }
            return Convert.ToString(RandomNum);
        }
        public static void Registration_Booking()
        {
            string startDate = "";
            string endDate = "";
            string hotelID = "";
            string guestID = "";
            string roomNo = "";

            Console.Clear();
            System.Console.WriteLine("Please enter following information:");
            System.Console.Write("Hotel ID: ");
            hotelID = System.Console.ReadLine();
            System.Console.Write("Room Number: ");
            roomNo = System.Console.ReadLine();
            System.Console.Write("Guest ID: ");
            guestID = System.Console.ReadLine();
            System.Console.Write("Start Date: ");
            startDate = System.Console.ReadLine();
            System.Console.Write("End Date: ");
            endDate = System.Console.ReadLine();

            if (startDate.CompareTo("") == 0 && endDate.CompareTo("") == 0 && hotelID.CompareTo("") == 0 && roomNo.CompareTo("") == 0 && guestID.CompareTo("") == 0)
            {
                Console.Clear();
                MessageBox.Show("Error: All Input Cannot Empty!","Error");
                return;
            }
            try
            {
                if (startDate.CompareTo("") != 0 && endDate.CompareTo("") != 0 && hotelID.CompareTo("") != 0 && roomNo.CompareTo("") != 0 && guestID.CompareTo("") != 0)
                {
                    string sql = "insert into Booking values('"+hotelID+"','"+roomNo+"','"+guestID+"','"+startDate+"','"+endDate+"')";
                    string booking_reference_num=GenerateRandomNumber();
                    Loading.Searching_Loading();
                    if (DataOperation.execSQL(sql))
                    {
                        System.Console.WriteLine("Data executing successful!");
                        System.Console.WriteLine("Please waiting...");
                        Thread.Sleep(2000);
                        System.Console.WriteLine("Thank you!");
                        System.Console.WriteLine("Your Booking Reference Number is :" + booking_reference_num);
                        System.Console.WriteLine("Press any button to quit!");
                        System.Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        MessageBox.Show("There is no available room in hotel:\t" + hotelID + "\n time between:\t" + startDate + "\t and \t" + endDate,"Notice");
                        Console.Clear();
                    }
                    return;
                }
                else
                {
                    Console.Clear();
                    MessageBox.Show("Error: All Input Cannot Empty!", "Error");
                    return;
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                MessageBox.Show("Error: Wrong!", "Notice");
            }
        }
    }
}
