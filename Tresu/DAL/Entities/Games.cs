using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table ("tblGame")]
    public class Games
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

       
        public string Description { get; set; }

        [StringLength(100), Required]
        public string Price { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Skins> Skins { get; set; }

       

        public virtual ICollection<UserGames> UserGames { get; set; }
    }
}
