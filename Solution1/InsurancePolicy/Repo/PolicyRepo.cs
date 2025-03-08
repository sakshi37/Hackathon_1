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

        public string ViewAllPolicy()
        {
            string policyString = "";
            if (policies.Count > 0)
            {
                foreach (var kv in policies)
                {
                    Policy policy = kv.Value;
                    string stringForm = policy.ToString();
                    policyString += stringForm;
                    policyString += "\n \n";
                }

                return policyString;
            }

            else
            {
                Console.WriteLine("No policy exist");
                return policyString;
            }
        }

        public Policy UpdatePolicy(int id, Policy updatedPolicy)
        {
            if (policies.ContainsKey(id))
            {
                policies[id] = updatedPolicy;
                return policies[id];

            }
            else
            {
                throw new PolicyNotFoundException("Policy does not exist");
            }


        }




    }
}

