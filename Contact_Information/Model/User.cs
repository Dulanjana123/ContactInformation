using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Information.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
