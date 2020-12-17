using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsLibrary
{

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
   
    public class Claims
    {
        

        public int ClaimId { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }


        public Claims()
        {

        }

        public Claims(int claimId, ClaimType claimType,string description,double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfClaim = DateOfClaim;
            DateOfIncident = dateOfIncident;
            IsValid = isValid;

        }

        public Claims(int claimId, ClaimType type, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = type;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfClaim = DateOfClaim;
            DateOfIncident = dateOfIncident;
            

        }
    }

    
}
