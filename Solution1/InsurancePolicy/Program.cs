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

                Policy policy3 = new Policy(1, "Akshata", PolicyType.Life, new DateTime(2025, 12, 1), new DateTime(2029, 1, 2));

                Console.WriteLine(repo.ViewByIdDB(1));
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(repo.ViewAllPolicy());
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine(repo.ViewByIdDB(20));
                Console.WriteLine("-------------------------------------------------------");


                //Console.WriteLine(repo.DeleteByIdDB(2));
                //Console.WriteLine("-------------------------------------------------------");

                //Console.WriteLine(repo.UpdatePolicyDB(1, policy3));
                //Console.WriteLine("-------------------------------------------------------");

                //Console.WriteLine(repo.ViewByIdDB(2));
                //Console.WriteLine("-------------------------------------------------------");

                //Console.WriteLine(repo.ViewByIdDB(1));

                //Console.WriteLine("-------------------------------------------------------");



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

