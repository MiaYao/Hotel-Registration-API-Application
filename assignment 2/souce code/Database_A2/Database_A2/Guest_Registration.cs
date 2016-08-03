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
    class Guest_Registration
    {

        public static string GenerateRandomNumber()
        {
            Random ro = new Random();
            StringBuilder RandomNum = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                RandomNum.Append(ro.Next(0, 9));
            }
            return Convert.ToString(RandomNum);
        }
        public static void Registration_Guest()
        {
            string guestName;
            string guestAddress;

            Console.Clear();
            System.Console.WriteLine("Please enter following information:");
            System.Console.Write("Guest Name: ");
            guestName = System.Console.ReadLine();
            System.Console.Write("Guest Address: ");
            guestAddress = System.Console.ReadLine();
            string RandomNumber = GenerateRandomNumber();
            string guestInsert = "insert into Guest values('" + RandomNumber + "','" + guestName + "','" + guestAddress + "','')";
            Loading.Inserting_Loading();
            if (DataOperation.execSQL(guestInsert))
            {
                System.Console.WriteLine("Data executing successful!");
                System.Console.WriteLine("Please waiting...");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                System.Console.WriteLine("Data executing failure!");
            }
        }
    }
}

