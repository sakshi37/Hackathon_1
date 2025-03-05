using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Exceptions
{
    public class PolicyNotFoundException: Exception
    {
        public PolicyNotFoundException(string msg): base(msg) { }

       

    }
}
