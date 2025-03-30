using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Models {
    [Table("Users")]
    public class User {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string password { get; set; }
    }
}
