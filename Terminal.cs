using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Terminal
    {
        public string TerminalName { get; set }
        public Dictionary<string, Airline> airlineDict { get; set; } = new Dictionary<string, Airline> ();
        public Dictionary<string, Flight> flightsDict { get; set; } = new Dictionary<string, Flight>();
        public Dictionary<string, BoardingGates> boardinggateDict { get; set; } = new Dictionary<string, BoardingGates> ();
        public Disctionary<string, double> gatefeesDict { get; set; } = new Disctionary<string, double> ();

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
            if (airlineDict.ContainsKey(f.FlightNumber))
            {
                return airlineDict[f.FlightNumber];
            }
            return null;
        }
        public void PrintAirlineFees()
        {
            foreach (KeyValuePair<>)
        }
        public override string ToString()
        {
            return TerminalName;
        }
    }
}
