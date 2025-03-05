using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePolicy.Model
{
     
    public enum PolicyType
    {
        Life,
        Health,
        Vehicle,
        Property


    }
    public class Policy
    {
        public int PolicyID { get; set; }
        public String PolicyHolderName { get; set; }
        public PolicyType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Policy(int id, String name,PolicyType type,  DateTime startDate, DateTime endDate)
        {
            PolicyID = id;
            PolicyHolderName = name;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Policy()
        {
        }

        public override string ToString()
        {
            return $"PolicyId:{PolicyID}\nName:{PolicyHolderName}\nType:{Type}\nStartDate:{StartDate}" +
                $"\nEndDate:{EndDate}";
        }

       
    }
}



