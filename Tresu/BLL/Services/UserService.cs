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
        private readonly IUserRepository _repository;
        public UserService()
        {
            _repository = new UserRepository(_context);
        }

        public UserModel FindByEmail(string email)
        {
            var temp= _repository.FindByEmail(email);
            UserModel model = new UserModel()
            {
                Id = temp.Id,
                Balance = temp.Balance,
                Login = temp.Login
            };
            return model;
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
        public IEnumerable<UserGames> GetUserGames(int id)
        {
            return _repository.GetUserGames(id);
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
            var lockTemp=_repository.GetUserLocks(id).FirstOrDefault(l => l.UnlockTime > DateTime.Now);
            var lockTemp2 = _repository.GetUserLocks(id).FirstOrDefault(l => l.UnlockTime < DateTime.Now);
            if (lockTemp != null)
            {
                return lockTemp.Reason;
            }
            else if (lockTemp2 !=null)
            {
                return "date";
            }
            else
            {
                return null;
            }
        }

        public int LoginTrue(UserLoginModel user)
        {
            int id = _repository.GetUsers().FirstOrDefault(
                 u => u.Email == user.Email &&
                 u.Password == user.Password)?.Id ?? -1;
            return id;
        }

        public Games GetGamesById(int id)
        {
            var temp = _repository.GetGamesById(id).FirstOrDefault(t => t.Id == id);
            Games g = new Games
            {
                Name = temp.Name,
                Photo = temp.Photo,
                Description = temp.Description
            };
            return  g;
        }

        public void Donate(int sum, int id)
        {
            _repository.Donate(sum, id);
            
        }

        public IEnumerable<Games> GetGames()
        {
            return _repository.GetGames();
        }
    }
}
