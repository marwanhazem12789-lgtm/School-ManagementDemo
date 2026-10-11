using Microsoft.EntityFrameworkCore;
using School_ManagementDemo.Genarics;
using School_ManagementDemo.Models;

namespace School_ManagementDemo.Generics
{
    public class GenericRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly Context _context;

        public GenericRepo(Context context)
        {
            _context = context;
        }

        public async Task add(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void remove(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}