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
    class Booking_query
    {
        public static void ExecuteData(string sql,string hn)
        {
            SqlDataReader myreader = DataOperation.getRow(sql);
            Loading.Searching_Loading();
            int pdinfo = 0;
            System.Console.WriteLine("\tH_ID\tH_Name\tH_City\t\tR_No\tR_Price\tR_Type");
            while (myreader.Read())
            {
                pdinfo++;
                System.Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", pdinfo, myreader["hotelID"], myreader["hotelName"], myreader["city"], myreader["roomNo"], myreader["price"], myreader["type"]);
            }
            if (pdinfo == 0)
            {
                Console.Clear();
                MessageBox.Show("There is no available room in hotel:\t" + hn,"Notice");

            }
            else
            {
                System.Console.WriteLine("Thank you!");
                System.Console.WriteLine("Press any button to quit!");
                System.Console.ReadKey();
                Console.Clear();
            }
        }
        public static void Query_Booking()
        {
            string startDate = "";
            string endDate = "";
            string hotelName = "";
            string city = "";
            string price = "";
            string type = "";

            Console.Clear();
            System.Console.WriteLine("Please enter following information:");
            System.Console.Write("Hotel Name: ");
            hotelName = System.Console.ReadLine();
            System.Console.Write("City Name: ");
            city = System.Console.ReadLine();
            System.Console.Write("Price: ");
            price = System.Console.ReadLine();
            System.Console.Write("Room Type: ");
            type = System.Console.ReadLine();
            System.Console.Write("Start Date: ");
            startDate = System.Console.ReadLine();
            System.Console.Write("End Date: ");
            endDate = System.Console.ReadLine();

            if (startDate.CompareTo("") == 0 && endDate.CompareTo("") == 0 && hotelName.CompareTo("") == 0 && city.CompareTo("") == 0 && price.CompareTo("") == 0 && type.CompareTo("") == 0)
            {
                Console.Clear();
                MessageBox.Show("Error: All inputs are blank!","Error");
                return;
            }
            try
            {
                if (startDate.CompareTo("") != 0 && endDate.CompareTo("") != 0 && hotelName.CompareTo("") != 0 && city.CompareTo("") != 0 && price.CompareTo("") != 0 && type.CompareTo("") != 0)
                {
                    string sql = "select h.hotelID,hotelName,city,roomNo,price,type from Hotel h,Room r where h.hotelID=r.hotelID and h.hotelName='" + hotelName + "' and h.city='" + city + "' and r.type='" + type + "' and r.price='" + price + "' and concat(r.hotelID,r.roomNo) not in (select concat(hotelID,roomNo) from Booking where (startDate between '" + startDate + "' and '" + endDate + "') OR (startdate<'" + startDate + "' and endDate>'" + startDate + "'))";
                    ExecuteData(sql,hotelName);
                    return;
                }
                if (hotelName.CompareTo("") != 0)
                {
                    string sql = "select h.hotelID,hotelName,city,roomNo,price,type from Hotel h,Room r where h.hotelID=r.hotelID and h.hotelName='" + hotelName + "'";
                    ExecuteData(sql,hotelName);
                    return;
                }
                if (city.CompareTo("") != 0)
                {
                    string sql = "select h.hotelID,hotelName,city,roomNo,price,type from Hotel h,Room r where h.hotelID=r.hotelID and h.city='" + city + "'";
                    ExecuteData(sql, hotelName);
                    return;
                }
                if (price.CompareTo("") != 0)
                {
                    string sql = "select h.hotelID,hotelName,city,roomNo,price,type from Hotel h,Room r where h.hotelID=r.hotelID and r.price='" + Convert.ToDouble(price) + "'";
                    ExecuteData(sql, hotelName);
                    return;
                }
                if (type.CompareTo("") != 0)
                {
                    string sql = "select h.hotelID,hotelName,city,roomNo,price,type from Hotel h,Room r where h.hotelID=r.hotelID and r.type='" + type + "'";
                    ExecuteData(sql, hotelName);
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
