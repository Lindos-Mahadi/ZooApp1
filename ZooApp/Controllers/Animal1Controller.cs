using System.Net;
using System.Web.Mvc;
using ZooApp.DAL;
using ZooApp.Models;

namespace ZooApp.Controllers
{
    public class Animal1Controller : Controller
    {
        private ZooContext db = new ZooContext();
        AnimalService service = new AnimalService();
        // GET: Animal
        public ActionResult Index()
        {
            
            var viewAnimals = service.GetAnimals();

            return View(viewAnimals);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            //save
            //if (ModelState.IsValid)
            //{
            //    bool save = service.Save(animal);
            //    return RedirectToAction("Index");
            //}
            bool save = service.Save(animal);
            return RedirectToAction("Index");
            return View(animal);
        }

        public ActionResult Details(int id)
        {
            ViewAnimal animal = service.GetAnimal(id);
            return View(animal);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Animal animal = service.GetDbAnimal(id);
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            bool save = service.Update(animal);
            return RedirectToAction("Index");
            return View(animal);
        }

        //[HttpGet]
        //public ActionResult Delete()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Delete(Animal animal)
        //{
        //    bool save = service.Delete(animal);
        //    return RedirectToAction("Index");
        //    //return View(animal);
        //}

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: /Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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