using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Exceptions;
using InsurancePolicy.Interface;
using InsurancePolicy.Model;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Data;

namespace InsurancePolicy.Repo
{
    public class PolicyRepo : IPolicyRepo
    {
        Dictionary<int, Policy> policies = new Dictionary<int, Policy>();
        
        
        public Policy AddPolicyToDB(Policy input)
        {
            string connstring = "something";
            SqlConnection connection = new SqlConnection(connstring);
            string query = "Insert into Policies (PolicyId, PolicyHolderName, Type, StartDate,  EndDate)"+
                            "Values (@PolicyId, @PolicyHolderName, @Type, @StartDate, @EndDate)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = input.PolicyID;
            cmd.Parameters.Add("@PolicyHolderName",SqlDbType.VarChar).Value = input.PolicyHolderName;
            cmd.Parameters.Add("@Type", SqlDbType.).Value = input.Type;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = input.StartDate;
            cmd.Parameters.Add("@EndDate",SqlDbType.DateTime).Value=input.EndDate;

            connection.Open();
                cmd.ExecuteNonQuery();
            connection.Close();


               
            
            

            
            
            
        }
       

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

        public Policy ViewById(int id)
        {
            if (policies.ContainsKey(id))
            {
                return policies[id];
            }
            else
            {
                throw new PolicyNotFoundException("Not found");
            }
        }
        public Policy DeleteById(int id)
        {
            if (policies.ContainsKey(id))
            {
                Policy deletedpolicy = policies[id];
                policies.Remove(id);
                return deletedpolicy;
            }
            else
            {
                throw new PolicyNotFoundException("id does not exist");
            }
        }
    }
}
