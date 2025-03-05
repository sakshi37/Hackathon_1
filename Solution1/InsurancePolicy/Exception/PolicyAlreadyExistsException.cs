using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Exceptions
{
    public class PolicyAlreadyExistsException: Exception
    {
        public PolicyAlreadyExistsException() : base("Policy already exists.") { }

        public PolicyAlreadyExistsException(string msg) : base(msg) { }

        public PolicyAlreadyExistsException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
