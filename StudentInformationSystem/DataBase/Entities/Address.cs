using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        
    }
}
