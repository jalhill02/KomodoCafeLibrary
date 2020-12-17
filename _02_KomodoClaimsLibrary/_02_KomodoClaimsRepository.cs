using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaimsLibrary
{
    public class _02_KomodoClaimsRepository
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();


        // Create
        public void AddClaimToQueue(Claims claims)
        {
            _queueOfClaims.Enqueue(claims);
        }

        // Read
        public Queue<Claims> GetClaims()
        {
            return _queueOfClaims ;
        }
        // Update
        public bool UpdateClaimsInQueue(int oldClaimid, Claims newClaims)
        {
            Claims oldClaim = GetClaimById(oldClaimid);
            
            if (oldClaim!=null)
            {
                //now we need to update...
                newClaims.ClaimId = oldClaim.ClaimId;
                oldClaim.Description = newClaims.Description;
                oldClaim.DateOfIncident = newClaims.DateOfIncident;
                oldClaim.DateOfClaim = newClaims.DateOfClaim;
                oldClaim.IsValid = newClaims.IsValid;
                oldClaim.ClaimAmount = newClaims.ClaimAmount;
                oldClaim.ClaimType = newClaims.ClaimType;

                return true;
            }
            return false;
        }

        // Delete
        public bool RemoveClaimFromQueue()
        {
            if (_queueOfClaims.Count > 0)
            {
                _queueOfClaims.Dequeue();
                return true;

            }
            return false;
        }

        // Helper Method
        public  Claims GetClaimById(int claimId)
        {
            foreach (var claim in _queueOfClaims)
            {
                if (claim.ClaimId == claimId)
                {
                    return claim;
                }
            }
            return null;
        }

        public Claims SeeNextInQueue()
        {
            Claims claims = _queueOfClaims.Peek();
            return claims;
        }

        // Komodo allows an insurance claim to be made up to 30 days after an incident took place.If the claim is not in the proper time limit, it is not valid.

        public bool IsValidCalculaiton(DateTime DateOfIncident, DateTime DateOfClaim)
        {
            var answer = DateOfClaim - DateOfIncident ;
            var comparison = TimeSpan.FromDays(answer.Days);
            
            //this is just to check...can be deleted if you want
            Console.WriteLine($"answer ={comparison.Days}");
            if (comparison.Days <=30 && comparison.Days>0 )
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

