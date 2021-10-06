using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_UnitTest
{
    public class ClaimsRepository
    {
        Queue<ClaimsClass> _claimsRepository = new Queue<ClaimsClass>();



        public Queue<ClaimsClass> DisplayClaims()
        {
            return _claimsRepository;
        }


        

        public bool AddClaim(ClaimsClass claim)
        {
            int startingCount = _claimsRepository.Count();
            _claimsRepository.Enqueue(claim);

            if(_claimsRepository.Count > startingCount)
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
