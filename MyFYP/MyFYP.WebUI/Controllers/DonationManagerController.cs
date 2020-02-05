﻿//using MyFYP.Core.Contracts;
//using MyFYP.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MyFYP.WebUI.Controllers
//{
//    //Adapted from -https://www.udemy.com/course/better-web-development-pro-techniques-for-success/learn/lecture/8533944?start=975#overview
//    [Authorize(Roles = "Admin")]
//    public class DonationManagerController : Controller
//    {

//        IRepository<Donation> context;
//        IRepository<ProductCategory> productCategories;

//        public DonationManagerController(IRepository<Donation> donationContext, IRepository<ProductCategory> productCategoryContext)
//        {
//            context = donationContext;
//            productCategories = productCategoryContext;
//        }
//        // GET: ProductManager
//        public ActionResult Index()
//        {
//            List<Product> products = context.Collection().ToList();
//            return View(products);
//        }

//        public ActionResult Create()
//        {
//            DonationManagerViewModel viewModel = new DonationManagerViewModel();

//            viewModel.Donation = new Donation();
//            viewModel.ProductCategories = productCategories.Collection();
//            return View(viewModel);
//        }

//        [HttpPost]
//        public ActionResult Create(Donation donation, HttpPostedFileBase file)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(donation);
//            }
//            else
//            {

//                if (file != null)
//                {
//                    donation.Image = donation.Id + Path.GetExtension(file.FileName);
//                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + donation.Image);
//                }

//                context.Insert(donation);
//                context.Comit();

//                return RedirectToAction("Index");
//            }

//        }

//        public ActionResult Edit(string Id)
//        {
//            Product product = context.Find(Id);
//            if (product == null)
//            {
//                return HttpNotFound();
//            }
//            else
//            {
//                ProductManagerViewModel viewModel = new ProductManagerViewModel();
//                viewModel.Product = product;
//                viewModel.ProductCategories = productCategories.Collection();

//                return View(viewModel);
//            }
//        }

//        [HttpPost]
//        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file)
//        {
//            Product productToEdit = context.Find(Id);

//            if (productToEdit == null)
//            {
//                return HttpNotFound();
//            }
//            else
//            {
//                if (!ModelState.IsValid)
//                {
//                    return View(product);
//                }

//                if (file != null)
//                {
//                    productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
//                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
//                }

//                productToEdit.Category = product.Category;
//                productToEdit.Description = product.Description;
//                productToEdit.Name = product.Name;
//                productToEdit.Price = product.Price;

//                context.Comit();

//                return RedirectToAction("Index");
//            }
//        }

//        public ActionResult Delete(string Id)
//        {
//            Product productToDelete = context.Find(Id);

//            if (productToDelete == null)
//            {
//                return HttpNotFound();
//            }
//            else
//            {
//                return View(productToDelete);
//            }
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        public ActionResult ConfirmDelete(string Id)
//        {
//            Product productToDelete = context.Find(Id);

//            if (productToDelete == null)
//            {
//                return HttpNotFound();
//            }
//            else
//            {
//                context.Delete(Id);
//                context.Comit();
//                return RedirectToAction("Index");
//            }
//        }
//    }
//}