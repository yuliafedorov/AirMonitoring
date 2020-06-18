using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{

    public class Director
        : User
    {
        public Director(int userId, string name, int stationId)
            : base(userId, name, stationId, nameof(Director))
        {
        }
    }
}

