using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class PersonDetail
    {
        public PersonDetail()
        {

        }
        [Key]
        public int Id { get; set; }
        public string PersonCity { get; set; }
        public DateTime BirhDay { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
