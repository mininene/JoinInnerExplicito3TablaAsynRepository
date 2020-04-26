using BaseDatos.Models;
using BaseDatos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BaseDatos.Services.Repository.QueryRepository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public async Task<IEnumerable<Coche>> ListadoOrdenadoCoche()
        {

            var cocheListx = await chocheListxt();  //sustituo el _context.Coche sincrono por lista sincrona
            var query =  cocheListx.OrderBy(x=>x.Modelo.NombreModelo).Where(a=>a.IdModelo==1);
                        
            return query;
        }

        public async Task<List<Join>> ListaJoin()
        {

            var usuarioListx = await usuarioListxt();
            var cocheListx = await chocheListxt();
            var departamentoListx = await departamentoListxt();

            var nuevaLista = new List<Join>();
            var multiple = from e in usuarioListx
            join d in departamentoListx on e.IdDepartamento equals d.Id into table1
            from d in table1.DefaultIfEmpty()
            join i in cocheListx on e.IdCoche equals i.Id into table2
                           from i in table2.DefaultIfEmpty()
                           select new Join
                           {
                               usuarioList = e,
                               departamentoList = d,
                               cocheList = i
                           };

            foreach (var item in multiple)
            {
                var nuevoTx = new Join();
                nuevoTx.cocheList = item.cocheList;
                nuevoTx.usuarioList = item.usuarioList;
                nuevoTx.departamentoList = item.departamentoList;
                nuevaLista.Add(nuevoTx);
            }

           return nuevaLista;

        }
    }
}