using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, int stationId)
            : base(userId, name, stationId, nameof(Admin))
        {
        }
    }
}
