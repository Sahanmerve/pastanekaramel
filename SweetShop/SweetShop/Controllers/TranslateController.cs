using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    public class TranslateController : Controller
    {
        // GET: Translate
        public ActionResult Index(string id, string url)
        {
            HttpCookie langCookie = new HttpCookie("lang");
            langCookie.Value = id;
            Response.Cookies.Add(langCookie);
            return Redirect(url);
        }
    }
}