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

        static void Main(string[] args)
        {

            PolicyRepo repo = new PolicyRepo();

            


            Policy policy = new Policy(1, "Sakshi", PolicyType.Health, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
            string display = policy.ToString();
            Console.WriteLine(display);

            repo.AddPolicy(policy);
            Policy policy1 = new Policy(2, "Bhushan", PolicyType.Vehicle, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
            repo.AddPolicy(policy1);



            string display2 = policy1.ToString();
            Console.WriteLine(display2);


            //repo.ViewAllPolicy();
            try
            {
                repo.AddPolicy(policy1);
            } catch(PolicyAlreadyExistsException ex) {
                Console.WriteLine("OHHHH NOOOOO EROOORSSSSSS");
            }

            repo.AddPolicy(policy1);




        }


    }
}


