﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFYP.Core.Contracts;
using MyFYP.Core.Models;
using MyFYP.Core.ViewModels;
using MyFYP.DataAccess.InMemory;

namespace MyFYP.WebUI.Controllers
{
    //Adapted from -https://www.udemy.com/course/better-web-development-pro-techniques-for-success/learn/lecture/8533944?start=975#overview

    public class ProductManagerController : Controller
    {
        
            IRepository<Product> context;
            IRepository<ProductCategory> productCategories;

            public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
            {
                context = productContext;
                productCategories = productCategoryContext;
            }
            // GET: ProductManager
            public ActionResult Index()
            {
                List<Product> products = context.Collection().ToList();
                return View(products);
            }

            public ActionResult Create()
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();

                viewModel.Product = new Product();
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);
            }

            [HttpPost]
            public ActionResult Create(Product product, HttpPostedFileBase file)
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {

                    if (file != null)
                    {
                        product.Image = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                    }

                    context.Insert(product);
                    context.Comit();

                    return RedirectToAction("Index");
                }

            }

            public ActionResult Edit(string Id)
            {
                Product product = context.Find(Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ProductManagerViewModel viewModel = new ProductManagerViewModel();
                    viewModel.Product = product;
                    viewModel.ProductCategories = productCategories.Collection();

                    return View(viewModel);
                }
            }

            [HttpPost]
            public ActionResult Edit(Product product, string Id, HttpPostedFileBase file)
            {
                Product productToEdit = context.Find(Id);

                if (productToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View(product);
                    }

                    if (file != null)
                    {
                        productToEdit.Image = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                    }

                    productToEdit.Category = product.Category;
                    productToEdit.Description = product.Description;
                    productToEdit.Name = product.Name;
                    productToEdit.Price = product.Price;

                    context.Comit();

                    return RedirectToAction("Index");
                }
            }

            public ActionResult Delete(string Id)
            {
                Product productToDelete = context.Find(Id);

                if (productToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(productToDelete);
                }
            }

            [HttpPost]
            [ActionName("Delete")]
            public ActionResult ConfirmDelete(string Id)
            {
                Product productToDelete = context.Find(Id);

                if (productToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Delete(Id);
                    context.Comit();
                    return RedirectToAction("Index");
                }
            }
        }
    
}