﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePolicy.Model;



namespace InsurancePolicy.Interface
{
       interface IPolicyRepo
    {
        Policy AddPolicy(Policy policy);
        string ViewAllPolicy();
    
        Policy UpdatePolicy(int id , Policy updatedPolicy);

        Policy ViewById(int id);
        Policy DeleteById(int id);

        




        }

 }
