using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository:ITresuRepository<Users>
    {
        Users FindByEmail(string email);
        IEnumerable<Lock> GetUserLocks(int id);
        IEnumerable<UserGames> GetUserGames(int id);
        IEnumerable<Games> GetGames(int id);
        void Donate(int sum,int id);
    }
}
