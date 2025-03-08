using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Exceptions;
using InsurancePolicy.Interface;
using InsurancePolicy.Model;

namespace InsurancePolicy.Repo
{
    public class PolicyRepo : IPolicyRepo
    {
        Dictionary<int, Policy> policies = new Dictionary<int, Policy>();

        public Policy AddPolicy(Policy input)
        {
            
                if (policies.ContainsKey(input.PolicyID))
                {

                    throw new PolicyAlreadyExistsException();
                }


                else
                {
                    policies.Add(input.PolicyID, input);
                    return policies[input.PolicyID];
                }

                       
            
        }

        public void ViewAllPolicy()
        {
            if (policies.Count > 0)
            {
                foreach (var policy in policies)
                {
                    Console.WriteLine(policy);
                }
            }
        }

        

    }
}

