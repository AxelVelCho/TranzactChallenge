using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Models;

namespace TranzactChallenge.Controllers
{
    [Route("premium")]
    [ApiController]
    public class PremiumCalculatorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseEntity>> GetPremium(RequestEntity requestEntity)
        {
            var list = await GetParameters();

            int month = Convert.ToDateTime(requestEntity.DateOfBirth).Month;

            ParameterEntity result = list.Find(x => (x.State == requestEntity.State || x.State == "*") &&
                                                    (x.MontOfBirth == month || x.MontOfBirth == -1) &&
                                                    (x.AgeFrom <= requestEntity.Age && x.AgeTo >= requestEntity.Age));
            ResponseEntity res = new ResponseEntity() { Premium = result.Premium };
            return res;
        }

        private async Task<List<ParameterEntity>> GetParameters()
        {
            var paramTable = new List<ParameterEntity>()
            {
                new ParameterEntity(){State = "NY", MontOfBirth = 8, AgeFrom = 18, AgeTo = 45, Premium = 150},
                new ParameterEntity(){State = "NY", MontOfBirth = 1, AgeFrom = 46, AgeTo = 65, Premium = 200.50},
                new ParameterEntity(){State = "NY", MontOfBirth = -1, AgeFrom = 18, AgeTo = 65, Premium = 120.99},
                new ParameterEntity(){State = "AL", MontOfBirth = 11, AgeFrom = 18, AgeTo = 65, Premium = 85.5},
                new ParameterEntity(){State = "AL", MontOfBirth = -1, AgeFrom = 18, AgeTo = 65, Premium = 100},
                new ParameterEntity(){State = "AK", MontOfBirth = 12, AgeFrom = 65, AgeTo = 200, Premium = 175.20},
                new ParameterEntity(){State = "AK", MontOfBirth = 12, AgeFrom = 18, AgeTo = 64, Premium = 125.16},
                new ParameterEntity(){State = "AK", MontOfBirth = 0, AgeFrom = 18, AgeTo = 65, Premium = 100.80},
                new ParameterEntity(){State = "*", MontOfBirth = -1, AgeFrom = 18, AgeTo = 65, Premium = 90},
            };
            // In MonthOfBirth, -1 means *

            return paramTable;
        }
    }
}
