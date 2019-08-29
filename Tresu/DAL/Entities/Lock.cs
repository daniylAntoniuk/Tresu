using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblLock")]
    public class Lock
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Reason { get; set; }
        [ForeignKey("UserOf")]
        public int UserId { get; set; }

        public Users UserOf { get; set; }

        [Required]
        public DateTime LockTime { get; set; }

        [Required]
        public DateTime UnlockTime { get; set; }
    }
}
