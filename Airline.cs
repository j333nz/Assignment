using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Airline
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Dictionary<string, Flight> flightsDict { get; set; } = new Dictionary<string, Flight>();
        public Airline() { }
        public Airline(string n, string c)
        {
            Name = n;
            Code = c;
        }
        public bool AddFlight(Flight f)
        {
            if (flightsDict.ContainsKey(f.FlightNumber))
            {
                return false;
            }
            flightsDict.Add(f.FlightNumber, f);
        }
        public double CalculateFees()
        {
            return 0; //idk what to put
        }
        public bool RemoveFlight(Flight f)
        {
            if (flightsDict.ContainsKey(f.FlightNumber))
            {
                flightsDict.Remove(f.FlightNumber);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Name" + "\t" + "Code" +
                "\n" + Name + "\t" + Code;
        }
    }
}
