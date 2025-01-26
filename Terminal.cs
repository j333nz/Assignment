using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Terminal
    {
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> airlineDict { get; set; } = new Dictionary<string, Airline> ();
        public Dictionary<string, Flight> flightsDict { get; set; } = new Dictionary<string, Flight>();
        public Dictionary<string, BoardingGate> boardinggateDict { get; set; } = new Dictionary<string, BoardingGate> ();
        public Dictionary<string, double> gatefeesDict { get; set; } = new Dictionary<string, double> ();

        public Terminal() { }
        public Terminal(string n)
        {
            TerminalName = n;
        }
        public bool AddAirline(Airline a)
        {
            if (airlineDict.ContainsKey(a.Code))
            {
                return false;
            }
            airlineDict.Add(a.Code, a);
            return true;
        }
        public bool AddBoardingGate(BoardingGate b)
        {
            if (boardinggateDict.ContainsKey(b.GateName))
            {
                return false;
            }
            boardinggateDict.Add(b.GateName, b);
            return true;
        }
        public Airline GetAirlineFromFlight(Flight f)
        {
            foreach (KeyValuePair<string, Airline> kvp in airlineDict)
            {
                if (kvp.Value.flightsDict.ContainsKey(f.FlightNumber))
                {
                    return kvp.Value;
                }
            }
            return null;
        }
        public void PrintAirlineFees()
        {
            foreach (KeyValuePair<string, Airline> kvp in airlineDict)
            {
                Console.WriteLine($"Airline: {kvp.Value.Name}\nTotal Fees: {kvp.Value.CalculateFees()}");
            }
        }
        public override string ToString()
        {
            return TerminalName;
        }
    }
}
