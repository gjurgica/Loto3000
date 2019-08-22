using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WinnerRepository : IRepository<WinnerDbo>
    {
        private readonly LotoAppDbContext _context;
        public WinnerRepository(LotoAppDbContext context)
        {
            _context = context;
        }
        public void Add(WinnerDbo entity)
        {
            _context.Winners.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(WinnerDbo entity)
        {
            _context.Winners.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<WinnerDbo> GetAll()
        {
            return _context.Winners;
        }

        public void Update(WinnerDbo entity)
        {
            _context.Winners.Update(entity);
            _context.SaveChanges();
        }
    }
}
