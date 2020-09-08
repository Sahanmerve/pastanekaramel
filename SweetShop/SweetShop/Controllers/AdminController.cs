using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        SweetShopContext db = new SweetShopContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slider()
        {
            return View(db.Sliders.ToList());
        }
        [HttpGet]
        public ActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderCreate(HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength != null)
            {
                // Resmi olduğu gibi /Uploads/Sliders/Large klasörüne kaydedelim
                // REsmi Croplayıp /Uploads/Sliders/Thumb klasörüne kaydedelim
                string path = Server.MapPath("/Uploads/Slider/");
                string thumbpath = path + "Thumb/";
                string largepath = path + "Large/";
                ImageFile.SaveAs(largepath + ImageFile.FileName);

                Image i = Image.FromFile(largepath + ImageFile.FileName);
                Size s = new Size(380, 100);
                Image Small = Helper.ResizeImage(i, s);
                Small.Save(thumbpath + ImageFile.FileName);
                i.Dispose();

                Slider slider = new Slider();
                slider.LargeImageUrl = "/Uploads/Slider/Large/" + ImageFile.FileName;
                slider.ThumbnaiURL = "/Uploads/Slider/Thumb/" + ImageFile.FileName;

                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Slider");
            }
            return View();
        }
        public ActionResult DeleteSlider(int id)
        {
            Slider slider = db.Sliders.Find(id);
            var path = Server.MapPath("/");
            var lg = path + slider.LargeImageUrl;
            var sm = path + slider.ThumbnaiURL;
            System.IO.File.Delete(lg);
            System.IO.File.Delete(sm);
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Slider");

        }
        

    }
}