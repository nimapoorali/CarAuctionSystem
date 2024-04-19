using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SeedWork
{
    //General BrokenBusinessRule used directly with an exception message for writing less code and keeping DRY
    internal class BrokenBusinessRule : IBusinessRule
    {
        private string _message;
        public string Message => _message;

        public BrokenBusinessRule(string message)
        {
            _message = message;
        }

        public bool IsBroken()
        {
            //A BrokenBusinessRule is always broken
            return true;
        }
    }
}
