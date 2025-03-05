using System;
using System.Collections.Generic;
using InsurancePolicy.Model;
using InsurancePolicy.Repository;
using InsurancePolicy.Exceptions;

namespace InsurancePolicyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PolicyRepo repopolicy = new PolicyRepo();

            while (true)
            {
                Console.WriteLine("\n--- Insurance Policy Management System ---");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. serched Policy");
                Console.WriteLine("3. View All Policies");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Exit");

                int choice = GetValidIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        AddPolicy(repopolicy);
                        break;
                    case 2:
                        ShowActivePolicies(repopolicy);
                        break;
                    case 3:
                        ViewAllPolicies(repopolicy);
                        break;
                    case 4:
                        UpdatePolicy(repopolicy);
                        break;
                    case 5:
                        DeletePolicy(repopolicy);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void ShowActivePolicies(object policyRepo)
        {
            throw new NotImplementedException();
        }

        static PolicyType GetValidPolicyType()
        {
            while (true)
            {
                Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                string input = Console.ReadLine().Trim().ToLower();

                switch (input)
                {
                    case "life":
                        return PolicyType.Life;
                    case "health":
                        return PolicyType.Health;
                    case "vehicle":
                        return PolicyType.Vehicle;
                    case "property":
                        return PolicyType.Property;
                    default:
                        Console.WriteLine("Invalid policy type. Please enter one of the following: Life, Health, Vehicle, Property.");
                        break;
                }
            }
        }

      
        static int GetValidIntegerInput(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        
        static DateTime GetValidDateInput(string message)
        {
            DateTime date;
            while (true)
            {
                Console.Write(message);
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                Console.WriteLine("Invalid date format. Please enter a valid date in yyyy-mm-dd format.");
            }
        }

        static void AddPolicy(PolicyRepo policyRepo)
        {
            int policyID;

            
            while (true)
            {
                policyID = GetValidIntegerInput("Enter Policy ID: ");

                if (!policyRepo.PolicyExists(policyID))
                {
                    break;
                }
                Console.WriteLine($"Policy with ID {policyID} already exists. Please enter a different ID.\n");
            }

            Console.Write("Enter Policy Holder Name: ");
            string policyHolderName = Console.ReadLine();

            PolicyType type = GetValidPolicyType();

            DateTime startDate = GetValidDateInput("Enter Start Date (yyyy-mm-dd): ");
            DateTime endDate = GetValidDateInput("Enter End Date (yyyy-mm-dd): ");

            Policy newPolicy = new Policy(policyID, policyHolderName, type, startDate, endDate);
            policyRepo.AddPolicy(newPolicy);

            Console.WriteLine("Policy added successfully!");
        }

        static void ViewAllPolicies(PolicyRepo policyRepo)
        {
            try
            {
                policyRepo.viewallpolicy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdatePolicy(PolicyRepo policyRepo)
        {
            int policyID = GetValidIntegerInput("Enter Policy ID to update: ");

            Console.Write("Enter New Policy Holder Name: ");
            string newPolicyHolderName = Console.ReadLine();

            PolicyType newType = GetValidPolicyType();

            DateTime newEndDate = GetValidDateInput("Enter New End Date (yyyy-mm-dd): ");

            try
            {
                Policy updatedPolicy = new Policy(policyID, newPolicyHolderName, newType, DateTime.Now, newEndDate);
                policyRepo.UpdatePolicy(policyID, updatedPolicy);
                Console.WriteLine("Policy updated successfully!");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeletePolicy(PolicyRepo policyRepo)
        {
            int policyID = GetValidIntegerInput("Enter Policy ID to delete: ");

            try
            {
                policyRepo.DeletePolicy(policyID);
                Console.WriteLine("Policy deleted successfully!");
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
