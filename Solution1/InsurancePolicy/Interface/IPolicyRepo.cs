using InsurancePolicy.Model;



namespace InsurancePolicy.Interface
{
    interface IPolicyRepo
    {
        //string ViewAllPolicy();

        Policy UpdatePolicyDB(int id, Policy updatedPolicy);


        Policy DeleteByIdDB(int id);
        void EnsureDeleted();
        void EnsureCreated();
        Policy AddPolicyToDB(Policy input);

        Policy ViewByIdDB(int id);

    }

}