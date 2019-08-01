using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table ("tblGames")]
    class Games
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100), Required]
        public string Price { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Skins> Skins { get; set; }
    }
}
