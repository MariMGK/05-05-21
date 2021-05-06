using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrud.Models
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required]
        public String FullName { get; set; }

    }
}
