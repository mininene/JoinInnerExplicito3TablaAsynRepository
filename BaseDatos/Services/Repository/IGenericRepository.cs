using BaseDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(object id);
        Task Save();

        Task<IEnumerable<Usuario>> usuarioListxt();
        Task<IEnumerable<Coche>> chocheListxt();
        Task<IEnumerable<Departamento>> departamentoListxt();
        Task<IEnumerable<Marca>> marcaListxt();
        Task<IEnumerable<Modelo>> modeloListxt();
        
    }
}
