using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Whiteboard;
using Whiteboard.DAL;
using Whiteboard.Models;

namespace Whiteboard.Controllers
{
    public class WhiteboardItemController : Controller
    {
        private WhiteboardContext db = new WhiteboardContext();

        // GET: WhiteboardItem
        public ActionResult Index()
        {
            var whiteboardItems = db.WhiteboardItems.Include(w => w.User);
            return View(whiteboardItems.ToList());
        }

        // GET: WhiteboardItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhiteboardItem whiteboardItem = db.WhiteboardItems.Find(id);
            if (whiteboardItem == null)
            {
                return HttpNotFound();
            }
            return View(whiteboardItem);
        }

        // GET: WhiteboardItem/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: WhiteboardItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WhiteboardItemID,ImageURL,UserID,UploadDate")] WhiteboardItem whiteboardItem)
        {
            if (ModelState.IsValid)
            {
                whiteboardItem.UploadDate = DateTime.Now;
                db.WhiteboardItems.Add(whiteboardItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", whiteboardItem.UserID);
            return View(whiteboardItem);
        }

        // GET: WhiteboardItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhiteboardItem whiteboardItem = db.WhiteboardItems.Find(id);
            if (whiteboardItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", whiteboardItem.UserID);
            return View(whiteboardItem);
        }

        // POST: WhiteboardItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WhiteboardItemID,ImageURL,UserID,UploadDate")] WhiteboardItem whiteboardItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whiteboardItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", whiteboardItem.UserID);
            return View(whiteboardItem);
        }

        // GET: WhiteboardItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhiteboardItem whiteboardItem = db.WhiteboardItems.Find(id);
            if (whiteboardItem == null)
            {
                return HttpNotFound();
            }
            return View(whiteboardItem);
        }

        // POST: WhiteboardItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhiteboardItem whiteboardItem = db.WhiteboardItems.Find(id);
            db.WhiteboardItems.Remove(whiteboardItem);
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
