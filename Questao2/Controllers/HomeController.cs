using Questao2.DAL;
using Questao2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 *  Questão 2
 *  Faça um crud básico com listagem, edição e remoção de itens. 
 *  Crie as views que achar necessário. Modele as classes da maneira que achar mais interessante e como você faria no seu dia a dia. 
 *  Como listagem, deixamos por padrão o GridMVC, mas você pode usar outro que tenha mais facilidade.
 */
namespace Questao2.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;

        public HomeController()
        {
            db = new AppDbContext();
        }

        public ActionResult Index()
        {
            
            ViewBag.Message = "Olá, candidato!";
            var itens = db.Items.ToList();
            return View(itens);
           
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Item();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                var itemNovo = new Item();
                itemNovo.CodigoItem = item.CodigoItem;
                itemNovo.Nome = item.Nome;
                itemNovo.Descricao = item.Descricao;
                itemNovo.Preco = item.Preco;

                db.Items.Add(itemNovo);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
           
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoItem,Nome,Descricao,Preco")] Item model)
        {
            if (ModelState.IsValid)
            {
                var itemEditar = db.Items.Find(model.Id);
                if (itemEditar == null)
                {
                    return RedirectToAction("Index");
                }
                itemEditar.CodigoItem = model.CodigoItem;
                itemEditar.Nome = model.Nome;
                itemEditar.Descricao = model.Descricao;
                itemEditar.Preco = model.Preco;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
           
            return View(item);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
