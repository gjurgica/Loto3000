using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserRepository : IRepository<UserDbo>
    {
        private readonly LotoAppDbContext _context;
        public UserRepository(LotoAppDbContext context)
        {
            _context = context;
        }

        public void Add(UserDbo entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(UserDbo entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<UserDbo> GetAll()
        {
            return _context.Users;
        }

        public void Update(UserDbo entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
