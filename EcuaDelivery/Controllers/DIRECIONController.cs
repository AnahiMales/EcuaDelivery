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
    public class DIRECIONController : Controller
    {
        private Entities db = new Entities();

        // GET: DIRECION
        public ActionResult Index()
        {
            var dIRECIONs = db.DIRECIONs.Include(d => d.CIUDAD);
            return View(dIRECIONs.ToList());
        }

        // GET: DIRECION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECION dIRECION = db.DIRECIONs.Find(id);
            if (dIRECION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECION);
        }

        // GET: DIRECION/Create
        public ActionResult Create()
        {
            ViewBag.CIU_ID = new SelectList(db.CIUDADs, "CIU_ID", "CIU_NOMBRE");
            return View();
        }

        // POST: DIRECION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DIR_ID,CIU_ID,DIR_CALLE_P,DIR_CALLE_S,DIR_NUM_C,DIR_DETALLE")] DIRECION dIRECION)
        {
            if (ModelState.IsValid)
            {
                db.DIRECIONs.Add(dIRECION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CIU_ID = new SelectList(db.CIUDADs, "CIU_ID", "CIU_NOMBRE", dIRECION.CIU_ID);
            return View(dIRECION);
        }

        // GET: DIRECION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECION dIRECION = db.DIRECIONs.Find(id);
            if (dIRECION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CIU_ID = new SelectList(db.CIUDADs, "CIU_ID", "CIU_NOMBRE", dIRECION.CIU_ID);
            return View(dIRECION);
        }

        // POST: DIRECION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DIR_ID,CIU_ID,DIR_CALLE_P,DIR_CALLE_S,DIR_NUM_C,DIR_DETALLE")] DIRECION dIRECION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CIU_ID = new SelectList(db.CIUDADs, "CIU_ID", "CIU_NOMBRE", dIRECION.CIU_ID);
            return View(dIRECION);
        }

        // GET: DIRECION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECION dIRECION = db.DIRECIONs.Find(id);
            if (dIRECION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECION);
        }

        // POST: DIRECION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECION dIRECION = db.DIRECIONs.Find(id);
            db.DIRECIONs.Remove(dIRECION);
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
