//Adapted code repository skeleton from Bret Hargreaves (2019) https://github.com/completecoder/MyShop
using MyFYP.Core.Models;
using MyFYP.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyFYP.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    //Authorize at class level
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Analytics()
        {
            return View();
        }

        //Adapted from https://www.youtube.com/watch?v=m9QqMXbp0Zs&t=975s
        public ActionResult GetData()
        {
            DataContext context = new DataContext();
            var data = context.OrderItems.Include("ProductName").ToList();
            var query = context.OrderItems.Include("ProductName")
                .GroupBy(p => p.ProductName)
                .Select(g => new { name = g.Key, count = g.Sum(w =>w.Quantity)}).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }


    }