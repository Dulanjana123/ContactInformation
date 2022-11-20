using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Information.Model
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        public string Country { get; set; }
        //public List<Countries> Contacts { get; set; }
    }
}
