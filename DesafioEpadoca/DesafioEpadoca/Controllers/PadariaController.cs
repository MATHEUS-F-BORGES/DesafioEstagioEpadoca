using DesafioEpadoca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioEpadoca.Controllers
{
    public class PadariaController : Controller
    {

        
        // GET: Padaria
        public ActionResult Index()
        {
            using (PadariaDAO model = new PadariaDAO())
            {
                List<Padaria> lista = model.Read();
                return View(lista);
            }
           
        }

        public ActionResult NomeExistente()
        {
            
            {
                
                return View();
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Padaria padaria = new Padaria();
            
            padaria.Nome = form["Nome"];
            padaria.Endereco = form["Endereco"];

            using (PadariaDAO model = new PadariaDAO())
            {

              String nomeDoBanco = model.ExisteNome(padaria.Nome);
              
                if (nomeDoBanco != null)
                {
                    return RedirectToAction("NomeExistente");

                }
                else
                {
                    model.Create(padaria);
                    return RedirectToAction("Index");
                }

            }
        }
    }
}