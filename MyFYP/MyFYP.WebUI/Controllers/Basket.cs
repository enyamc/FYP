using MyFYP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFYP.WebUI.Controllers
{
    public class Basket : Controller
    {
        IBasketService basketService;

        public Basket(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);

            return RedirectToAction("Index");
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return View();
        }

        public PartialViewResult BasketSummery()
        {
            var basketSummery = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummery);
        }
    }
}