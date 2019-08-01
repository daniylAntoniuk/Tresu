using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserSkins")]
    class UserSkins
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserGamesOf")]
        public int UserGamesId { get; set; }

        [ForeignKey("SkinOf")]
        public int SkinId { get; set; }

        public virtual UserGames UserGamesOf { get; set; }

        public virtual Skins SkinsOf { get; set; }
    }
}
