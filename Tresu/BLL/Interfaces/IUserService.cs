using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Register(UserRegisterModel user);
        int Login(UserLoginModel user);
        int LoginTrue(UserLoginModel user);
        void ForgotPassword(int id, UserRegisterModel user);
        IEnumerable<Users> GetUsers();
        string GetLockReason(int id);
        UserModel FindByEmail(string email);
        IEnumerable<UserGames> GetUserGames(int id);
        IEnumerable<Games> GetGames();
        Games GetGamesById(int id);
        void Donate(int sum,int id);
    }
}
