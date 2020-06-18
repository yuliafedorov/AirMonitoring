using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    
        public abstract class User
        {
            public User(int userId, string name, int stationId, string userType)
            {
                UserId = userId;
                Name = name;
                OSBBID = stationId;
                UserType = userType;
            }
            public int UserId { get; }
            public string Name { get; }
            public int OSBBID { get; }
            protected string UserType { get; }
        }
    
}
