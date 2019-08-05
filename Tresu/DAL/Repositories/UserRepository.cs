using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace DAL.Repositories
{
    public class UserRepository : ITresuRepository<Users>
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

        public bool Edit(int id, Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
