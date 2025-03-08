using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Model;



namespace InsurancePolicy.Interface
{
       interface IPolicyRepo
    {
        void AddPolicy(Policy policy); 
        void UpdatePolicy(int policyID, Policy updatedPolicy);
        void DeletePolicy(int policyID);
        Policy GetPolicyById(int policyID);
        void ViewAllpolicy();


        Dictionary<int, Policy> GetAllPolicies();
       
    }

     
    }
