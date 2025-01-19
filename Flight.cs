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
        public double CalculateFees()
        {

        }
        public override string ToString()
        {
            return FlightNumber + "\t" + Origin + "\t" + Destination + "\t" ExpectedTime + "\t" Status;
        }
    }
}

