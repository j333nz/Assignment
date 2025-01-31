using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class LWTTFlight : Flight
    {
        public double RequestFee { get; set; }
        public LWTTFlight() { }
        public LWTTFlight(string f, string o, string d, DateTime e) : base(f, o, d, e){}

        public override double CalculateFees()
        {
            double additionalfee = 500;
            return base.CalculateFees() + additionalfee;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
