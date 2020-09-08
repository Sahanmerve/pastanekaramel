using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Entity;
using SweetShop.Models;

namespace SweetShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private SweetShopContext db = new SweetShopContext();
        UnitOfWork _uw = new UnitOfWork();
        // GET: Products
        
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatergoryId = _uw.Categories.GetAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()

            });

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,ProductPrice,ProductDescription,Calori,ProductImageUrl,Piece,CategoryID")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    var path = Server.MapPath("/Uploads/Products/");
                    ImageFile.SaveAs(path + ImageFile.FileName);
                    product.ProductImageUrl = ImageFile.FileName;
                }

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CatergoryId = _uw.Categories.GetAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()

            });
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.CatergoryId = _uw.Categories.GetAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()

            });
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product,HttpPostedFileBase ProductImageURL)
        {
            if (ModelState.IsValid)
            {
                var p = db.Products.Find(product.ID);
                if (ProductImageURL != null)
                {
                    var path = Server.MapPath("/Uploads/Products/");

                    if (p.ProductImageUrl != null)
                        System.IO.File.Delete(path + p.ProductImageUrl);

                    //string old = path + ;
                    string _new = path + ProductImageURL.FileName;
                    ProductImageURL.SaveAs(_new);
                    p.ProductImageUrl = ProductImageURL.FileName;

                }
                p.Calori = product.Calori;
                p.Piece = product.Piece;
                p.ProductDescription = product.ProductDescription;
                p.ProductName = product.ProductName;
                p.CategoryID = product.CategoryID;
                p.ProductPrice = product.ProductPrice;
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatergoryId = _uw.Categories.GetAll().Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.ID.ToString()

            });
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
