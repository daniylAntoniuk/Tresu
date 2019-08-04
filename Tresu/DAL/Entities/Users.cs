using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUser")]
    class Users
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress,Required]
        public string Email { get; set; }

        [StringLength(100),Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        //public virtual ICollection<UserFriends> UserFriends { get; set; }

        public virtual ICollection<UserGames> UserGames { get; set; }
    }
}
