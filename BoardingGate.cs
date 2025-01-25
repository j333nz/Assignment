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
            if (SupportsDDJB)
            {
                return baseFee + 300;
            }
            else if (SupportsCFFT)
            {
                return baseFee + 150;
            }
            else if (SupportsLWTT)
            {
                return baseFee+ 500;
            }
            else
            {
                return baseFee;
            }
        }
        public override string ToString()
        {
            return GateName;
        }
    }
}
