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
            return true;
        }
        public double CalculateFees()
        {
            double totalFees = 0;
            double totalDiscounts = 0;
            foreach (Flight flight in flightsDict.Values)
            {
                totalFees += flight.CalculateFees();
            }
            if (flightsDict.Count() > 5)
            {
                double discount = totalFees * 0.10;
                totalFees -= discount;
            }
            // first promotion: For every 3 flights arriving/departing, airlines will receive a discount
            int firstDiscount = flightsDict.Count() / 3;
            totalDiscounts += firstDiscount * 350;

            // second promotion: For each flight arriving/departing before 11am or after 9pm
            foreach (Flight flight in flightsDict.Values)
            {
                if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21)
                {
                    totalDiscounts += 110;
                }
            }

            // third promotion: For each flight with the Origin of Dubai (DXB), Bangkok (BKK) or Tokyo (NRT)
            string[] originsWithDiscounts = { "Dubai (DXB)", "Bangkok (BKK)", "Tokyo (NRT)" };
            foreach (Flight flight in flightsDict.Values)
            {
                if (originsWithDiscounts.Contains(flight.Origin))
                {
                    totalDiscounts += 25;
                }
            }

            // fourth promotion: For each flight not indicating any Special Request Codes
            foreach (Flight flight in flightsDict.Values)
            {
                if (flight is NORMFlight)
                {
                    totalDiscounts += 50;
                }
            }

            // fifth promotion: For each airline with more than 5 flights arriving/departing, the airline will receive an additional discount
            if (flightsDict.Count() > 5)
            {
                    double totalFeesBeforeDiscounts = 0;
                    foreach (Flight flight in flightsDict.Values)
                    {
                        totalFeesBeforeDiscounts += flight.CalculateFees();
                    }
                    totalDiscounts += totalFeesBeforeDiscounts * 0.03;
                }
                totalFees -= totalDiscounts;
                return totalFees;
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
            return "Name: " + Name + "\nCode: " + Code;
        }
    }
}
