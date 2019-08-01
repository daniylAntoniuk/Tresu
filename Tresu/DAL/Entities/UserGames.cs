using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserGames")]
    class UserGames
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserOf")]
        public int UserId { get; set; }

       
        [ForeignKey("UserSkinOf")]
        public int UserSkinId { get; set; }

        public virtual Users UserOf { get; set; }

        public virtual UserSkins SkinsOf { get; set; }
    }
}
