using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaseDatos.Models;
using BaseDatos.Models.ViewModel;
using BaseDatos.Services.Repository.QueryRepository;

namespace BaseDatos.Controllers
{
    public class TableJoinController : Controller
    {
        private IUsuarioRepository repositorio = null;

        public TableJoinController()
        {
            this.repositorio = new UsuarioRepository();
        }

        public TableJoinController(IUsuarioRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: TableJoin
        public async Task <ActionResult> Index()
        {

            //CocheEntities3 db = new CocheEntities3();
            //List<Usuario> usuarioListx = db.Usuario.ToList();
            //List<Coche> cocheListx = db.Coche.ToList();
            //List<Departamento> departamentoListx = db.Departamento.ToList();

            //var usuarioListx = await repositorio.usuarioListxt();
            //var cocheListx = await repositorio.chocheListxt();
            //var departamentoListx = await repositorio.departamentoListxt();

            //var multiple = from e in usuarioListx
            //               join d in departamentoListx on e.IdDepartamento equals d.Id into table1
            //               from d in table1.DefaultIfEmpty()
            //               join i in cocheListx on e.IdCoche equals i.Id into table2
            //               from i in table2.DefaultIfEmpty()
            //               select new Join
            //               {
            //                   usuarioList = e,
            //                   departamentoList = d,
            //                   cocheList = i
            //               };
            //return View(multiple);

            var lista = await repositorio.ListaJoin();
            return View( lista);


        }

        public async Task<ActionResult> Indexo()
        {

            //var lista = repositorio.ListadoOrdenadoCoche();
            var lista = await repositorio.ListadoOrdenadoCoche();
            return View(lista );


        }
    }
}