using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Whiteboard.DAL;
using Whiteboard.Models;

namespace Whiteboard.Controllers
{
    public class TaggedWhiteboardController : Controller
    {
        private WhiteboardContext db = new WhiteboardContext();

        // GET: TaggedWhiteboard
        public ActionResult Index()
        {
            var taggedWhiteboards = db.TaggedWhiteboards.Include(t => t.Tag).Include(t => t.WhiteboardItem);
            return View(taggedWhiteboards.ToList());
        }

        // GET: TaggedWhiteboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaggedWhiteboard taggedWhiteboard = db.TaggedWhiteboards.Find(id);
            if (taggedWhiteboard == null)
            {
                return HttpNotFound();
            }
            return View(taggedWhiteboard);
        }

        // GET: TaggedWhiteboard/Create
        public ActionResult Create()
        {
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName");
            ViewBag.WhiteboardItemID = new SelectList(db.WhiteboardItems, "WhiteboardItemID", "ImageURL");
            return View();
        }

        // POST: TaggedWhiteboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaggedWhiteboardID,TagID,WhiteboardItemID")] TaggedWhiteboard taggedWhiteboard)
        {
            if (ModelState.IsValid)
            {
                db.TaggedWhiteboards.Add(taggedWhiteboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", taggedWhiteboard.TagID);
            ViewBag.WhiteboardItemID = new SelectList(db.WhiteboardItems, "WhiteboardItemID", "ImageURL", taggedWhiteboard.WhiteboardItemID);
            return View(taggedWhiteboard);
        }

        // GET: TaggedWhiteboard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaggedWhiteboard taggedWhiteboard = db.TaggedWhiteboards.Find(id);
            if (taggedWhiteboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", taggedWhiteboard.TagID);
            ViewBag.WhiteboardItemID = new SelectList(db.WhiteboardItems, "WhiteboardItemID", "ImageURL", taggedWhiteboard.WhiteboardItemID);
            return View(taggedWhiteboard);
        }

        // POST: TaggedWhiteboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaggedWhiteboardID,TagID,WhiteboardItemID")] TaggedWhiteboard taggedWhiteboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taggedWhiteboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagID = new SelectList(db.Tags, "TagID", "TagName", taggedWhiteboard.TagID);
            ViewBag.WhiteboardItemID = new SelectList(db.WhiteboardItems, "WhiteboardItemID", "ImageURL", taggedWhiteboard.WhiteboardItemID);
            return View(taggedWhiteboard);
        }

        // GET: TaggedWhiteboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaggedWhiteboard taggedWhiteboard = db.TaggedWhiteboards.Find(id);
            if (taggedWhiteboard == null)
            {
                return HttpNotFound();
            }
            return View(taggedWhiteboard);
        }

        // POST: TaggedWhiteboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaggedWhiteboard taggedWhiteboard = db.TaggedWhiteboards.Find(id);
            db.TaggedWhiteboards.Remove(taggedWhiteboard);
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
