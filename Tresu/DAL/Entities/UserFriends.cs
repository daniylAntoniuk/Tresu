using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserFriends")]
    class UserFriends
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("UserOf")]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("FriendOf")]
        public int FriendId { get; set; }

        public virtual Users UserOf { get; set; }

        public virtual Users FriendOf { get; set; }
    }
}
