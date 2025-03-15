using InsurancePolicy.Model;



namespace InsurancePolicy.Interface
{
    interface IPolicyRepo
    {
        Policy AddPolicy(Policy policy);
        string ViewAllPolicy();

        Policy UpdatePolicy(int id, Policy updatedPolicy);

        Policy ViewById(int id);
        Policy DeleteById(int id);
        void EnsureDeleted();
        void EnsureCreated();
        Policy AddPolicyToDB(Policy input)


     }

}