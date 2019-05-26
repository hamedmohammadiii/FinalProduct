using FinalProduct.DAL;
using FinalProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProduct.Controllers
{
    public class ProductController : Controller
    {
        private readonly FinalProductDBContext db;

        public ProductController()
        {
            db = new FinalProductDBContext();
        }

        public ActionResult Index()
        {
            var list = new List<Product>();
            list = db.Products.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Categories = db.Categories.ToList();
            var selectlist = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectlist;

            var Companies = db.Companies.ToList();
            var selectlist1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectlist1;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product Entity)
        {
            if(!ModelState.IsValid)
            {

            }

            if(db.Products.Any(x =>x.Id == Entity.Id))
            {
                ViewBag.Message = "این کالا ثبت شده است.";
                return View(Entity);
            }

            db.Products.Add(Entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var Entirty = db.Products.Find(Id);

            if(Entirty == null)
            {
                ViewBag.Message = "محصول مورد نظر یافت نشد.";
                return RedirectToAction("Index");
            }

            var Categories = db.Categories.ToList();
            var selectlist = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectlist;

            var Companies = db.Companies.ToList();
            var selectlist1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectlist1;

            return View(Entirty);
        }

        [HttpPost]
        public ActionResult Edit(Product Entity)
        {
            var Categories = db.Categories.ToList();
            var selectlist = new SelectList(Categories, "Id", "Name");
            ViewBag.Categories = selectlist;

            var Companies = db.Companies.ToList();
            var selectlist1 = new SelectList(Companies, "Id", "PersianName");
            ViewBag.Companies = selectlist1;

            db.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int code)
        {
            var Entity = db.Products.FirstOrDefault(x => x.Id == code);

            if(Entity == null)
            {
                ViewBag.Message = "یافت نشد.";
                return RedirectToAction("Index");
            }

            db.Products.Remove(Entity);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}