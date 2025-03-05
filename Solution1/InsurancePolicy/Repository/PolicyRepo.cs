using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Interface;
using InsurancePolicy.Model;

namespace InsurancePolicy.Repository
{
    public class PolicyRepo : IPolicyInsurance
    {
        private Dictionary<int, Policy> policies = new Dictionary<int, Policy>();

        
        public void AddPolicy(Policy policy)
        {
            if (!policies.ContainsKey(policy.PolicyID))
            {
                policies.Add(policy.PolicyID, policy);
                Console.WriteLine($"Policy {policy.Type} added successfully!");
            }
            else
            {
                Console.WriteLine($"[ERROR] Policy with ID {policy.PolicyID} already exists.");
                throw new Exceptions.PolicyAlreadyExistsException($"Policy with ID {policy.PolicyID} already exists.");
            }
        }
 
        public void UpdatePolicy(int policyID, Policy updatedPolicy)
        {
            
            if (policies.ContainsKey(policyID))
            {
                Policy existing = policies[policyID];

                
                existing.PolicyHolderName = updatedPolicy.PolicyHolderName;
                existing.Type = updatedPolicy.Type;
                existing.StartDate = updatedPolicy.StartDate; 
                existing.EndDate = updatedPolicy.EndDate;

                Console.WriteLine("Your policy has been updated successfully");
            }
            else
            {
                Console.WriteLine("No policy found with that ID");
            }
        }
        public Policy GetPolicyById(int policyID)
        {
            if (policies.ContainsKey(policyID))  
            {
                Policy policy = policies[policyID];  
                Console.WriteLine(policy);  
                return policy;
            }
            else
            {
                Console.WriteLine("Policy with ID " + policyID + " not found.");
                return null;
            }
        }



        public void viewallpolicy()
        {
            if (policies.Count > 0)
            {
                Console.WriteLine("List of all policy");

                foreach(var policy in policies)
                {
                    Console.WriteLine(policy);
                }
            }
        }

        public void DeletePolicy(int policyID)
        {
            if (policies.ContainsKey(policyID))
            {
                policies.Remove(policyID);
                Console.WriteLine("Your policy is deleteted");
            }
            else
                Console.WriteLine("id not found");
        }

       public Dictionary<int, Policy> GetAllPolicies()  
        {
            return policies;  
        }

        public bool PolicyExists(int policyID)
        {
            return policies.ContainsKey(policyID);
        }

        public List<Policy> GetActivePolicies()
        {
            DateTime today = DateTime.Today;

            return policies.Values
                           .Where(p => p.StartDate <= today && p.EndDate >= today)
                           .ToList();
        }

        public void ShowActivePolicies(PolicyRepo policyRepo)
        {
            List<Policy> activePolicies = policyRepo.GetActivePolicies();

            if (activePolicies.Count == 0)
            {
                Console.WriteLine("No active policies found.");
                return;
            }

            Console.WriteLine("\nActive Policies:");
            foreach (Policy policy in activePolicies)
            {
                Console.WriteLine($"ID: {policy.PolicyID}, Holder: {policy.PolicyHolderName}, Type: {policy.Type}, Start: {policy.StartDate:yyyy-MM-dd}, End: {policy.EndDate:yyyy-MM-dd}");
            }
        }

    }
}
