using Questao2.DAL;
using Questao2.Models;
using Questao2.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Questao2.Controllers
{
    public class SalesOrderController : Controller
    {

        private AppDbContext db;

        public SalesOrderController()
        {
            db = new AppDbContext();
        }
        //
        // GET: /SalesOrder/

        public ActionResult Index()
        {
            // TODO: Retornar a coleção de pedidos de vendas (SalesOrder).
            //var list = new List<Foo>() 
            //{ 
            //    new Foo()
            //    {
            //        Title = "Title 1",
            //        Description = "Description"
            //    },
            //    new Foo()
            //    {
            //        Title = "Title 2",
            //        Description = "Description"
            //    },
            //    new Foo()
            //    {
            //        Title = "Title 3",
            //        Description = "Description"
            //    },
            //    new Foo()
            //    {
            //        Title = "Title 4",
            //        Description = "Description"
            //    },
            //    new Foo()
            //    {
            //        Title = "Title 5",
            //        Description = "Description"
            //    }
            //};
            var sales = db.SalesOrder.ToList();
            return View(sales);
            
        }

        //
        // GET: /SalesOrder/Create

        public ActionResult Create()
        {
            var model = new SalesOrder();
            return View(model);
        } 

        //
        // POST: /SalesOrder/Create

        [HttpPost]
        public ActionResult Create(SalesOrder model)
        {

            if (ModelState.IsValid)
            {
                var salesOrderNovo = new SalesOrder();
                var user = db.Users.Find(1);
                salesOrderNovo.Title = model.Title;
                salesOrderNovo.Description = model.Description;
                salesOrderNovo.Value = model.Value;
                salesOrderNovo.User = user;

                db.SalesOrder.Add(salesOrderNovo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        //
        // GET: /SalesOrder/Edit/5
 
        public ActionResult Edit(int id)
        {
            // TODO: Implementação.
            return View();
        }

        //
        // POST: /SalesOrder/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // TODO: Implementação.
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // POST: /SalesOrder/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // TODO: Implementação.
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
