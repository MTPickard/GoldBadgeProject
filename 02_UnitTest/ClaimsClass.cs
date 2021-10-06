﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_UnitTest
{
    public class ClaimsClass
    {
        public ClaimsClass() { }

        public ClaimsClass(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }


        public bool IsValid
        {
            get
            {
                TimeSpan span = DateOfClaim - DateOfIncident;
                if(span < TimeSpan.FromDays(30))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
    }

    



    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
}
