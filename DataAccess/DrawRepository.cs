using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DrawRepository : IRepository<DrawDbo>
    {
        private readonly LotoAppDbContext _context;
        public DrawRepository(LotoAppDbContext context)
        {
            _context = context;
        }
        public void Add(DrawDbo entity)
        {
            _context.Draws.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(DrawDbo entity)
        {
            _context.Draws.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<DrawDbo> GetAll()
        {
            return _context.Draws;
        }

        public void Update(DrawDbo entity)
        {
            _context.Draws.Update(entity);
            _context.SaveChanges();
        }
    }
}
