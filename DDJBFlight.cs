using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class DDJBFlight : Flight
    {
        public double RequestFee { get; set; }
        public DDJBFlight() { }
        public DDJBFlight(double fee, string f, string o, string d, DateTime e, string s) : base(f, o, d, e, s)
        {
            RequestFee = fee;
        }
        public double CalculateFees()
        {
            return base.CalculateFees() + RequestFee;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
