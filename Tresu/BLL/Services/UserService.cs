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
using System.Windows;

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

            //bool IsBanned = _repository.GetUsers().FirstOrDefault(
            //   u => u.IsLocked == false).IsLocked;//?.IsLocked?? true;
            
            int id = _repository.GetUsers().FirstOrDefault(
                  u => u.Email == user.Email &&
                  u.IsLocked==false &&
                  u.Password == user.Password)?.Id ?? -1;

            //int id = _repository.GetUsers().FirstOrDefault(
            //   u => u.Email == user.Email &&
            //   u.Password == user.Password)?.Id ?? -1;
           
            //if (id > 0)
            //{
            //}
            //else
            //{
                //MessageBox.Show("Inccorect Email or Password !");
            //}
            return id;
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
        public IEnumerable<Users> GetUsers()
        {
            return _repository.GetUsers();
        }

        public void ForgotPassword(int id, UserRegisterModel user)
        {
            
            _repository.Edit(id, new Users
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password

            });
        }

        public string GetLockReason(int id)
        {
            string res = _repository.GetLocks().FirstOrDefault(
                  l => l.UserId == id &&
                  l.UnlockTime > DateTime.Now)?.Reason ;
            if(_repository.GetLocks().FirstOrDefault(
                   l => l.UserId == id)?.UnlockTime < DateTime.Now)
            {
                res = "date";
            }
            return res;
        }

        public int LoginTrue(UserLoginModel user)
        {
            int id = _repository.GetUsers().FirstOrDefault(
                 u => u.Email == user.Email &&
                 u.Password == user.Password)?.Id ?? -1;
            return id;
        }
    }
}
