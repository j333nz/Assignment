using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    abstract class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; } = "Scheduled";
        public Flight() { }
        public Flight(string f, string o, string d, DateTime e)
        {
            FlightNumber = f;
            Origin = o;
            Destination = d;
            ExpectedTime = e;
        }
        public virtual double CalculateFees()
        {
            double baseFee = 300;
            double originDestinationFee = 0;
            if (Origin == "Singapore (SIN)")
            {
                originDestinationFee = 800;
                return originDestinationFee;
            }
            else if (Destination == "Singapore (SIN)")
            {
                originDestinationFee = 800;
                return originDestinationFee;
            }
            return baseFee + originDestinationFee;
        }

        public int CompareTo(Flight other)
        {
            if (ExpectedTime < other.ExpectedTime) return -1;
            else if (other.ExpectedTime == ExpectedTime) return 0;
            else return 1;
        }

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

