using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class EFContext:DbContext
    {
        public EFContext() : base("TresuConnection")
        {

        }
        public DbSet<Users> Users { get; set; }
        //public DbSet<UserFriends> UserFriends { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Skins> Skins { get; set; }
        public DbSet<UserGames> UserGames { get; set; }
        public DbSet<UserSkins> UserSkins { get; set; }
    }
}
