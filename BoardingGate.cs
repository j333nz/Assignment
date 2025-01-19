using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class BoardingGate
    {
        public string GetName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; }
        public BoardingGate() { }
        public BoardingGate(string g, bool c, bool d, bool l, Flight f)
        {
            GetName = g;
            SupportsCFFT = c;
            SupportsDDJB = d;
            SupportsLWTT = l;
            Flight = f;
        }
        public double CalculateFees()
        {
            double basefee = 300;
        }
        public override string ToString()
        {
            return GetName;
        }
    }
}
