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
    public class CocheController : Controller
    {
        private CocheEntities3 db = new CocheEntities3();


        // GET: Coche
        public async Task<ActionResult> Index()
        {
            var coche = db.Coche.Include(c => c.Marca).Include(c => c.Modelo);
            return View(await coche.ToListAsync());
        }

        // GET: Coche/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = await db.Coche.FindAsync(id);
            if (coche == null)
            {
                return HttpNotFound();
            }
            return View(coche);
        }

        // GET: Coche/Create
        public ActionResult Create()
        {
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "NombreMarca");
            ViewBag.IdModelo = new SelectList(db.Modelo, "Id", "NombreModelo");
            return View();
        }

        // POST: Coche/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Matricula,IdMarca,IdModelo")] Coche coche)
        {
            if (ModelState.IsValid)
            {
                db.Coche.Add(coche);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "NombreMarca", coche.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "Id", "NombreModelo", coche.IdModelo);
            return View(coche);
        }

        // GET: Coche/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = await db.Coche.FindAsync(id);
            if (coche == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "NombreMarca", coche.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "Id", "NombreModelo", coche.IdModelo);
            return View(coche);
        }

        // POST: Coche/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Matricula,IdMarca,IdModelo")] Coche coche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coche).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdMarca = new SelectList(db.Marca, "Id", "NombreMarca", coche.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelo, "Id", "NombreModelo", coche.IdModelo);
            return View(coche);
        }

        // GET: Coche/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coche coche = await db.Coche.FindAsync(id);
            if (coche == null)
            {
                return HttpNotFound();
            }
            return View(coche);
        }

        // POST: Coche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Coche coche = await db.Coche.FindAsync(id);
            db.Coche.Remove(coche);
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
