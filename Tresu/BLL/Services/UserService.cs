using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public  class UserService : IUserService
    {
        private readonly EFContext _context = new EFContext();
        private readonly ITresuRepository<Users> _repository;
        public UserService()
        {
            _repository = new UserRepository(_context);
        }

        public int Login(UserLoginModel user)
        {
            throw new NotImplementedException();
        }

        public void Register(UserRegisterModel user)
        {
            _repository.Add(new Users
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
                
            });
            
        }
    }
}
