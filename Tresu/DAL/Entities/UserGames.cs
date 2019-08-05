using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserGame")]
    class UserGames
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserOf")]
        public int UserId { get; set; }

        [ForeignKey("GameOf")]
        public int GameId { get; set; }

        public virtual Games GameOf { get; set; }

        
        public virtual Users UserOf { get; set; }

      
    }
}
