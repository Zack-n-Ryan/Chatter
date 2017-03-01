using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chatter.Models;

namespace Chatter.Controllers
{
    public class ChatFeedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChatFeeds
        public ActionResult Index()
        {
            return View(db.ChatFeeds.ToList());
        }

        // GET: ChatFeeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatFeed chatFeed = db.ChatFeeds.Find(id);
            if (chatFeed == null)
            {
                return HttpNotFound();
            }

            string identa = User.Identity.Name;

            var viewModel = new ChatViewModel
            {
                

                ChatFeed = chatFeed,
                ApplicationUser02 = (from a in db.Users
                                   where a.UserName == identa
                                   select a).First()
                
            };

            return View(viewModel);

            //return View(chatFeed);
        }

        // GET: ChatFeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TweetID,TweetContent,TweetDate,ApplicationUser02_Id")] ChatFeed chatFeed)
        {
            if (ModelState.IsValid)
            {
                db.ChatFeeds.Add(chatFeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatFeed);
        }

        // GET: ChatFeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatFeed chatFeed = db.ChatFeeds.Find(id);
            if (chatFeed == null)
            {
                return HttpNotFound();
            }
            return View(chatFeed);
        }

        // POST: ChatFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TweetID,TweetContent,TweetDate,UserName")] ChatFeed chatFeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatFeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatFeed);
        }

        // GET: ChatFeeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatFeed chatFeed = db.ChatFeeds.Find(id);
            if (chatFeed == null)
            {
                return HttpNotFound();
            }
            return View(chatFeed);
        }

        // POST: ChatFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatFeed chatFeed = db.ChatFeeds.Find(id);
            db.ChatFeeds.Remove(chatFeed);
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
