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


                Policy policy = new Policy(1, "Sakshi", PolicyType.Health, new DateTime(2025, 12, 1), new DateTime(2028, 12, 1));
                repo.AddPolicyToDB(policy);

                Policy policy2 = new Policy(2, "Bhushan", PolicyType.Vehicle, new DateTime(2002, 1, 3), new DateTime(2030, 12, 12));
                repo.AddPolicyToDB(policy2);


                repo.ViewByIdDB(2);

                repo.DeleteByIdDB(2);

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

