using InsurancePolicy.Model;
using InsurancePolicy.Repo;

namespace InsurancePolicyApp
{
    class Program
    {

        static void Main(string[] args)
        {
            PolicyRepo repo = new PolicyRepo();

            try
            {


                repo.EnsureCreated();


                Policy policy = new Policy(1, "Sakshi", PolicyType.Health, new DateTime(2025, 12, 01), new DateTime(2028, 12, 01));
                string display = policy.ToString();
                Console.WriteLine(display);

                repo.AddPolicyToDB(policy);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                repo.EnsureDeleted();
            }
        }


    }
}

