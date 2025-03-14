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

            string checkPolicyExistQuery = "select PolicyId from Policies where PolicyId == @PolicyId ";
            SqlCommand selectPolicyCmd = new SqlCommand(checkPolicyExistQuery, connection);

            selectPolicyCmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = input.PolicyID;

            connection.Open();

            SqlDataReader reader = selectPolicyCmd.ExecuteReader();
            if (reader.HasRows)
            {
                connection.Close();
                throw new PolicyAlreadyExistsException();
            }
            connection.Close();
            

            string insertQuery = "Insert into Policies (policy_id, policy_holder_name, type, start_date,  end_date)" +
                            "Values (@PolicyId, @PolicyHolderName, @Type, @StartDate, @EndDate)";
            SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
            insertCmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = input.PolicyID;
            insertCmd.Parameters.Add("@PolicyHolderName", SqlDbType.VarChar).Value = input.PolicyHolderName;
            insertCmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = input.Type;
            insertCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = input.StartDate;
            insertCmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = input.EndDate;

            connection.Open();
            
            insertCmd.ExecuteNonQuery();

            connection.Close();

            return input;
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
