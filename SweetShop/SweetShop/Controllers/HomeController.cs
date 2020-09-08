using BLL;
using DAL;
using Entity;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        SweetShopContext db = new SweetShopContext();

        public ActionResult Index()
        {
            ViewBag.Sliders = db.HomeSliders.ToList();
            return View(_uw.Categories.GetAll());
        }

        public ActionResult CategoryDetail(int id)
        {
            var a =_uw.Products.Search(x=>x.CategoryID==id);

            if (User.Identity.IsAuthenticated)
            {
                string uid = User.Identity.GetUserId();
                Customer LoggedInUser = _uw.db.Users.Find(uid);                
            }
            return View(a);
        }
        public ActionResult About()
        {
            
            return View(db.Sliders.ToList());
        }
        public ActionResult Translate(string id, string url)
        {
            HttpCookie langCookie = new HttpCookie("lang");
            langCookie.Value = id;
            Response.Cookies.Add(langCookie);
            return Redirect(url);
        }
    }
}