using CopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CopaDoMundo.Controllers
{
    public class SelecaoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(unitOfWork.SelecaoRepository.Selecoes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Selecao selecao)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SelecaoRepository.Adiciona(selecao);
                unitOfWork.Salvar();
                return RedirectToAction("Index");
            }
            return View(selecao);
        }

        public ActionResult Delete(int Id)
        {
            Selecao selecao = unitOfWork.SelecaoRepository.Buscar(Id);
            return View(selecao);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmation(int Id)
        {
            unitOfWork.SelecaoRepository.Excluir(Id);
            unitOfWork.Salvar();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


    }
}