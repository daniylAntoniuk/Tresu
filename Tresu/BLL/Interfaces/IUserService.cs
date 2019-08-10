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
        void ForgotPassword(int id, UserRegisterModel user);
         IEnumerable<Users> GetUsers();
    }
}
