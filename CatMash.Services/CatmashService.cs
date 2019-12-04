using CatMash.Repository;
using CatMash.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Services
{
    public class CatMashService : ICatmashService
    {
        private readonly CatMashDbContext _context;

        public CatMashService(CatMashDbContext context)
        {
            _context = context;
            //_logger = logger;
        }
        public async Task<Cats> GetByIdAsync(int id)
        {
            return await _context.Set<Cats>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.CatMashId == id);
        }
        public Cats GetRandomCat()
        {
            var rand = new Random();
            var cats = _context.Cats.ToList();
            return cats.ElementAt(rand.Next(cats.Count));
        }
        public IList<Cats> GetAll()
        {
            return _context.Set<Cats>().AsNoTracking().ToList();
        }
        public Cats GetById(object id)
        {
            return _context.Set<Cats>().Find(id);
        }
        public void Add(Cats obj)
        {
            _context.Set<Cats>().Add(obj);
            Save();
        }
        public void AddRange(IEnumerable<Cats> cats)
        {
            _context.Set<Cats>().AddRange(cats);
            Save();
        }
        public void Update(Cats obj)
        {
            _context.Set<Cats>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(object id)
        {
            Cats existing = _context.Set<Cats>().Find(id);
            _context.Set<Cats>().Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }

    public interface ICatmashService
    {
        public IList<Cats> GetAll();
        public Task<Cats> GetByIdAsync(int id);
        public void Delete(object id);
        public void Save();
        public void AddRange(IEnumerable<Cats> cats);
        public void Update(Cats obj);
        public void Add(Cats obj);
        public Cats GetById(object id);
        public Cats GetRandomCat();
    }
}
