using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Person
    {
        public Person()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MyProperty { get; set; }
        public string Address { get; set; }
        [ForeignKey("Position")]
        public int Position { get; set; }
        public Position Positions { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }
        public virtual PersonDetail PersonDetail { get; set; }

    }
}
