using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseDatos.Models;

namespace BaseDatos.Controllers
{
    public class UsuarioController : Controller
    {
        private CocheEntities3 db = new CocheEntities3();

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuario = db.Usuario.Include(u => u.Coche).Include(u => u.Departamento);
            return View(await usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdCoche = new SelectList(db.Coche, "Id", "Matricula");
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "Id", "NombreDepartamento");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Apellido,IdCoche,IdDepartamento")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCoche = new SelectList(db.Coche, "Id", "Matricula", usuario.IdCoche);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "Id", "NombreDepartamento", usuario.IdDepartamento);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCoche = new SelectList(db.Coche, "Id", "Matricula", usuario.IdCoche);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "Id", "NombreDepartamento", usuario.IdDepartamento);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Apellido,IdCoche,IdDepartamento")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCoche = new SelectList(db.Coche, "Id", "Matricula", usuario.IdCoche);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "Id", "NombreDepartamento", usuario.IdDepartamento);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
