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
    public class HomeSliderController : Controller
    {
        SweetShopContext db = new SweetShopContext();
        // GET: HomeSlider
        public ActionResult Index()
        {
            return View(db.HomeSliders.ToList());
        }
        [HttpGet]
        public ActionResult SliderCreate2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderCreate2(HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength != null)
            {
                // Resmi olduğu gibi /Uploads/Sliders/Large klasörüne kaydedelim
                // REsmi Croplayıp /Uploads/Sliders/Thumb klasörüne kaydedelim
                string path = Server.MapPath("/Uploads/HomeSlider/");
                string thumbpath = path + "Thumb/";
                string largepath = path + "Large/";
                ImageFile.SaveAs(largepath + ImageFile.FileName);

                Image i = Image.FromFile(largepath + ImageFile.FileName);
                Size s = new Size(380, 100);
                Image Small = Helper.ResizeImage(i, s);
                Small.Save(thumbpath + ImageFile.FileName);
                i.Dispose();

                HomeSlider slider = new HomeSlider();
                slider.HomeLargeImageUrl = "/Uploads/HomeSlider/Large/" + ImageFile.FileName;
                slider.HomeThumbnaiURL = "/Uploads/HomeSlider/Thumb/" + ImageFile.FileName;

                db.HomeSliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult DeleteSlider(int id)
        {
            HomeSlider slider = db.HomeSliders.Find(id);
            var path = Server.MapPath("/");
            var lg = path + slider.HomeLargeImageUrl;
            var sm = path + slider.HomeThumbnaiURL;
            System.IO.File.Delete(lg);
            System.IO.File.Delete(sm);
            db.HomeSliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}