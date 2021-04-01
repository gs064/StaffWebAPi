using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StaffWebAPi.Models
{
    public class StaffName
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
