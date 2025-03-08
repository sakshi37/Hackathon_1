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

            repo.ViewAllPolicy();
            Policy policy = new Policy(1, "Sakshi", PolicyType.Health, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
           
            repo.AddPolicy(policy);
            Policy policy1 = new Policy(2, "Bhushan", PolicyType.Vehicle, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
            repo.AddPolicy(policy1); 

            try
            {
                repo.AddPolicy(policy1);
            } catch(PolicyAlreadyExistsException ex) {
                Console.WriteLine("OHHHH NOOOOO EROOORSSSSSS");
            }


            string display = repo.ViewAllPolicy();
            Console.WriteLine(display);

            var policy3 = new Policy(1,"Sakshi",PolicyType.Property,new DateTime(2027,1,5), new DateTime(2045, 4, 10));
            repo.UpdatePolicy(policy3.PolicyID,policy3);

           
            Console.WriteLine(repo.ViewAllPolicy());

            try
            {
                repo.UpdatePolicy(100, policy3);
            } catch(PolicyNotFoundException ex)
            {
                Console.WriteLine("ohh noooo againn!!");
            }








        }


    }
}


