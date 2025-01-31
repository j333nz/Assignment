using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class CFFTFlight : Flight
    {
        public double RequestFee { get; set; }
        public CFFTFlight() { }
        public CFFTFlight(string f, string o, string d, DateTime e) : base(f, o, d, e) { }

        public override double CalculateFees()
        {
            double additionalfee = 150;
            return base.CalculateFees() + additionalfee;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
