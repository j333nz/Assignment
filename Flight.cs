using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    abstract class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public Flight() { }
        public Flight(string f, string o, string d, DateTime e, string s)
        {
            FlightNumber = f;
            Origin = o;
            Destination = d;
            ExpectedTime = e;
            Status = s;
        }
        public abstract double CalculateFees();
        /*{
            List<DateTime> timings = new List<DateTime>();
            string[] time = ExpectedTime.ToString().Split(':');
            foreach (string t in time)
            {
                DateTime dt = DateTime.Phrase(t);
                timings.Add(dt);
            }
            timings.Sort();
            double final_fee = 0;
            double total_fee = 0;
            double base_fee = 300;
            if (Destination == "Singapore (SIN)")
            {
                total_fee = base_fee += 500;
            }
            else if (Origin == "Singapore (SIN)")
            {
                total_fee = base_fee += 800;
            }
            else
            {
                total_fee = base_fee;
            }

            if (ExpectedTime.Hour >= 21 || ExpectedTime.Hour <= 11)
            {
                final_fee = total_fee - 110;
            }
            else if (Origin == "Dubai (DXB)" || Origin == "Bangkok (BKK)" || Origin == "Tokyo (NRT)")
            {
                final_fee = total_fee - 20;
            }
        }*/
            // these i havent done yet, not quite sure
            // For every 3 flights arriving/departing, airlines will receive a discount 
            // For each airline with more than 5 flights arriving/departing, the airline will
            //receive an additional discount
        public override string ToString()
        {
            return "Flight Number: " + FlightNumber + 
                "\nOrigin: " + Origin + 
                "\nDestination: " + Destination +
                "\nExpected Time" + ExpectedTime + 
                "\nStatus:" + Status;
        }
    }
}

