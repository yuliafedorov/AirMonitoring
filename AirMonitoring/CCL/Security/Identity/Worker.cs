using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Worker
          : User
    {
        public Worker(int userId, string name, int stationId)
            : base(userId, name, stationId, nameof(Worker))
        {
        }
    }
   
}
