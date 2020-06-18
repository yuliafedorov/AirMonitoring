using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Region
    {
        public int RegionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int StationID { get; set; }
        public Station Station { get; set; }
    }
}
