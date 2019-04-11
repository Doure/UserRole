using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string Email { get; set; }
        [Required, MaxLength(50), MinLength(3)]
        public string UserName { get; set; }
        [Required]
        public DateTime DateBirthday { get; set; }
        public int? JobTitleId { get; set; }
    }
}
