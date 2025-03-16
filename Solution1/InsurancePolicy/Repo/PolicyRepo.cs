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
            string createQuery = "Create table policies(policy_id int,  policy_holder_name varchar(20), type int, start_date DateTime,  end_date DateTime)";
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
            insertCmd.Parameters.Add("@Type", SqlDbType.Int).Value = input.Type;
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

            if (reader.Read())
            {
                int policyId = (int)reader[0];
                string policyHolderName = (string)reader[1];
                PolicyType type = (PolicyType)reader[2];
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
            string selectQuery = "select policy_id, policy_holder_name, type, start_date, end_date from policies ";
            SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
            connection.Open();
            SqlDataReader reader = selectCmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader[0];
                string name = (string)reader[1];
                PolicyType type = (PolicyType)reader[2];
                DateTime startDate = (DateTime)reader[3];
                DateTime endDate = (DateTime)reader[4];
                Policy policy = new Policy(id, name, type, startDate, endDate);
                string policySt = policy.ToString();
                policyString += policySt;
                policyString += "\n \n";


            }
            connection.Close();


            return policyString;


        }

        public Policy UpdatePolicyDB(int id, Policy updatedPolicy)
        {
            this.ViewByIdDB(id);

            string updateQuery = "Update policies set policy_holder_name = @PolicyHolderName,type = @Type, end_date = @EndDate where policy_id = @PolicyId";
            SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
            updateCmd.Parameters.Add("PolicyId", SqlDbType.Int).Value = id;
            updateCmd.Parameters.Add("@PolicyHolderName", SqlDbType.VarChar, 20).Value = updatedPolicy.PolicyHolderName;
            updateCmd.Parameters.Add("@Type", SqlDbType.Int).Value = updatedPolicy.Type;
            updateCmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = updatedPolicy.EndDate;

            connection.Open();
            updateCmd.ExecuteNonQuery();
            connection.Close();
            return updatedPolicy;

        }




        public Policy DeleteByIdDB(int id)
        {

            Policy policy = this.ViewByIdDB(id);

            string deleteQuery = "Delete from policies where policy_id = @PolicyID";
            SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
            deleteCmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = id;

            connection.Open();
            deleteCmd.ExecuteNonQuery();
            connection.Close();

            return policy;

        }
    }
}
