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
        public string Status { get; set; } = "Unassigned";
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
            if (Origin == "Singapore (SIN)")
            {
                return 800;
            }
            else if (Destination == "Singapore (SIN)")
            {
                return 500;
            }
            else
            {
                return 0;
            }
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

