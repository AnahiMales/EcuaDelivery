using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcuaDelivery;

namespace EcuaDelivery.Controllers
{
    public class USUARIOController : Controller
    {
        private Entities db = new Entities();

        // GET: USUARIO
        public ActionResult Index()
        {
            var uSUARIOs = db.USUARIOs.Include(u => u.DIRECION);
            return View(uSUARIOs.ToList());
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.DIR_ID = new SelectList(db.DIRECIONs, "DIR_ID", "DIR_CALLE_P");
            return View();
        }

        // POST: USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USU_ID,DIR_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOs.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DIR_ID = new SelectList(db.DIRECIONs, "DIR_ID", "DIR_CALLE_P", uSUARIO.DIR_ID);
            return View(uSUARIO);
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.DIR_ID = new SelectList(db.DIRECIONs, "DIR_ID", "DIR_CALLE_P", uSUARIO.DIR_ID);
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USU_ID,DIR_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DIR_ID = new SelectList(db.DIRECIONs, "DIR_ID", "DIR_CALLE_P", uSUARIO.DIR_ID);
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            db.USUARIOs.Remove(uSUARIO);
            db.SaveChanges();
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
