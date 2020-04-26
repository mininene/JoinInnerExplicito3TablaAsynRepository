using BaseDatos.DAL;
using BaseDatos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BaseDatos.Services.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CocheEntities3 _context = null;
        public DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new CocheEntities3();
            table = _context.Set<T>();
        }

        public GenericRepository(CocheEntities3 context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<Usuario>> usuarioListxt()
        {
            return await _context.Usuario.ToListAsync();
        }

        public virtual async Task<IEnumerable<Coche>> chocheListxt()
        {
            return await _context.Coche.ToListAsync();
        }

        public virtual async Task<IEnumerable<Departamento>> departamentoListxt()
        {
            return await _context.Departamento.ToListAsync();
        }

        public virtual async Task<IEnumerable<Marca>> marcaListxt()
        {
            return await _context.Marca.ToListAsync();
        }

        public virtual async Task<IEnumerable<Modelo>> modeloListxt()
        {
            return await _context.Modelo.ToListAsync();
        }

        


    }
}