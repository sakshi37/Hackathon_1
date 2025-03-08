using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Interface;
using InsurancePolicy.Model;

namespace InsurancePolicy.Repo
{
    public class PolicyRepo:IPolicyRepo
    {
        Dictionary<int, Policy> policies = new Dictionary<int, Policy> ();

        public void AddPolicy(Policy input)
        {
            if (policies.ContainsKey(input.PolicyID))
            {
                Console.WriteLine("policy with this id already Exist");
            }
            else
            {
                policies.Add(input.PolicyID,input);
            }
        }
    }
}
