using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
