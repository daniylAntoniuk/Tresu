using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserSkin")]
    class UserSkins
    {
        [Key]
        public int Id { get; set; }

        

        [ForeignKey("SkinOf")]
        public int SkinId { get; set; }

        

        public virtual Skins SkinOf { get; set; }

        public virtual ICollection<UserGames> UserGames { get; set; }
    }
}
