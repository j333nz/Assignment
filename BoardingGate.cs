using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class BoardingGate
    {
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; }
        public BoardingGate() { }
        public BoardingGate(string g, bool c, bool d, bool l)
        {
            GateName = g;
            SupportsCFFT = c;
            SupportsDDJB = d;
            SupportsLWTT = l;
        }
        public double CalculateFees()
        {
            double baseFee = 300;
            return baseFee;
        }
        public override string ToString()
        {
            return "Gate Name: " + GateName + "\nSupports CFFT: " + SupportsCFFT + "\nSupports DDJB: " + SupportsDDJB + "\nSupports LWTT: " + SupportsLWTT;
        }
    }
}
