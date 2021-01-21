using ASPMVCShoppingCart.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ASPMVCShoppingCart.Controllers
{
    public class ManageController : Controller
    {
        private DemoDBEntities db = new DemoDBEntities();

        //
        // GET: /Manage/

        public ActionResult Index(int? page)
        {
            return View(db.tblProducts.ToList().ToPagedList(page ?? 1,15));
        }

        //
        // GET: /Manage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblProduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                db.tblProducts.Add(tblproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblproduct);
        }

        //
        // GET: /Manage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblProduct tblproduct = db.tblProducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        //
        // POST: /Manage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblProduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblproduct);
        }

        //
        // GET: /Manage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblProduct tblproduct = db.tblProducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        //
        // POST: /Manage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProduct tblproduct = db.tblProducts.Find(id);
            db.tblProducts.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}