using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFContext _context;
        public UserRepository(EFContext context)
        {
            _context = context;
        }
        public bool Add(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(int id, Users elem)
        {
            try
            {

                var user = _context.Users.FirstOrDefault(t => t.Id == id);
                user.Login = elem.Login;
                user.Email = elem.Email;
                user.Password = elem.Password;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.AsEnumerable();
        }

        public Users FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(t => t.Email == email);
        }

        public Users FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lock> GetUserLocks(int id)
        {
            return _context.Users.FirstOrDefault(t => t.Id == id)?.Locks;
        }
        public IEnumerable<UserGames> GetUserGames(int id)
        {
            return _context.Users.FirstOrDefault(t => t.Id == id)?.UserGames;
        }
    }
}
