//Adapted code repository skeleton from Bret Hargreaves (2019) https://github.com/completecoder/MyShop
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFYP.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    //Authorize at class level
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

    }
}