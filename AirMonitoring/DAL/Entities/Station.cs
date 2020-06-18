using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Station
    {
        public int StationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Director { get; set; }

        public IEnumerable<Region> Region { get; set; }
    }
}
