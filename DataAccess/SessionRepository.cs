using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class SessionRepository : IRepository<SessionDbo>
    {
        private readonly LotoAppDbContext _context;
        public SessionRepository(LotoAppDbContext context)
        {
            _context = context;
        }
        public void Add(SessionDbo entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(SessionDbo entity)
        {
            _context.Sessions.Remove(entity); ;
            _context.SaveChanges();
        }

        public IEnumerable<SessionDbo> GetAll()
        {
            return _context.Sessions;
        }

        public void Update(SessionDbo entity)
        {
            _context.Sessions.Update(entity);
            _context.SaveChanges();
        }
    }
}
