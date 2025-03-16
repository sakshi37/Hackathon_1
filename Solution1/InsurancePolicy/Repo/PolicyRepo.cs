using System.Data;
using System.Data.SqlClient;
using InsurancePolicy.Exceptions;
using InsurancePolicy.Interface;
using InsurancePolicy.Model;

namespace InsurancePolicy.Repo
{



    public class PolicyRepo : IPolicyRepo
    {
        Dictionary<int, Policy> policies = new Dictionary<int, Policy>();

        string connstring = "Server=DESKTOP-03V0C0B;Database=insurance_policy;Trusted_Connection=True";
        SqlConnection connection;
        public PolicyRepo()
        {
            connection = new SqlConnection(connstring);
        }
        public void EnsureCreated()
        {
            string createQuery = "Create table policies(policy_id int,  policy_holder_name varchar(20), type varchar(20), start_date DateTime,  end_date DateTime)";
            SqlCommand createCmd = new SqlCommand(createQuery, connection);
            connection.Open();
            createCmd.ExecuteNonQuery();
            connection.Close();
        }
        public void EnsureDeleted()
        {
            string deleteQuery = "drop table policies";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
            connection.Open();
            deleteCmd.ExecuteNonQuery();
            connection.Close();

        }

        public Policy AddPolicyToDB(Policy input)
        {



            string checkPolicyExistQuery = "select policy_id from policies where policy_id = @PolicyId ";
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


            string insertQuery = "Insert into policies (policy_id, policy_holder_name, type, start_date,  end_date)" +
                            "Values (@PolicyId, @PolicyHolderName, @Type, @StartDate, @EndDate)";
            SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
            insertCmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = input.PolicyID;
            insertCmd.Parameters.Add("@PolicyHolderName", SqlDbType.VarChar, 20).Value = input.PolicyHolderName;
            insertCmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = input.Type;
            insertCmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = input.StartDate;
            insertCmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = input.EndDate;

            connection.Open();

            insertCmd.ExecuteNonQuery();

            connection.Close();

            return input;
        }


        public Policy ViewByIdDB(int id)
        {
            string selectQuery = "select policy_id, policy_holder_name, type, start_date, end_date from policies where policy_id = @PolicyId";
            SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
            selectCmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = id;
            connection.Open();
            SqlDataReader reader = selectCmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                int policyId = (int)reader[0];
                string policyHolderName = (string)reader[1];
                string type = (string)reader[2];
                DateTime startdate = (DateTime)reader[3];
                DateTime endtdate = (DateTime)reader[4];

                Policy policy = new Policy(policyId, policyHolderName, type, startdate, endtdate);

                connection.Close();
                return policy;
            }

            connection.Close();
            throw new PolicyNotFoundException("Policy not found");
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


        public Policy DeleteByIdDB(int id)
        {

            Policy policy = this.ViewByIdDB(id);

            string deleteQuery = "Delete from policies where policy_id = @PolicyID";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);

            connection.Open();
            deleteCmd.ExecuteNonQuery();
            connection.Close();

            return policy;

        }
    }
}
