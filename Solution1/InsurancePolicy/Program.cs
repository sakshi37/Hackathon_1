using System;
using System.Collections.Generic;
using InsurancePolicy.Model;
using InsurancePolicy.Repo;
using InsurancePolicy.Exceptions;
using System.ComponentModel;

namespace InsurancePolicyApp
{
    class Program
    {

        public void Main(string[] args)
        {

            PolicyRepo repo = new PolicyRepo();

            


            Policy policy = new Policy(1, "Sakshi", PolicyType.Health, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));

            
            string display = policy.ToString();
            Console.WriteLine(display);

            repo.AddPolicy(policy);
            Policy policy1 = new Policy(2, "Bhushan", PolicyType., new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
            repo.AddPolicy(policy1);







        }


    }
}


