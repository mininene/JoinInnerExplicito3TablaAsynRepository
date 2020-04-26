using BaseDatos.Models;
using BaseDatos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Services.Repository.QueryRepository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        
        Task<List<Join>> ListaJoin();
    }
}
