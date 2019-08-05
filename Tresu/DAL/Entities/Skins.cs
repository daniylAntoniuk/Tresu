using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblSkin")]
    public class Skins
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        public string Photo { get; set; }

        [StringLength(100), Required]
        public string Price { get; set; }

        [ForeignKey("GameOf")]
        public int GameId { get; set; }

        public virtual Games GameOf { get; set; }

        public virtual ICollection<UserSkins> UserSkins { get; set; }

    }
}
