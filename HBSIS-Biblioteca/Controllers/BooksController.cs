using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Books;
using HBSIS_Biblioteca.Models.Books;

namespace HBSIS_Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            return View(new IndexModel());
        }


        public ActionResult Create()
        {
            return View(new CreateModel());
        }

        [HttpPost]
        public ActionResult Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                Books_BO bo = new Books_BO();
                if (bo.Create(model.obj) > 0)
                {
                    ViewBag.successMessage = bo.message;
                    model = new CreateModel();
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.erroMessage = bo.message;
                }
            }


            return View(model);
        }

        public ActionResult Update(int id)
        {
            return View(new UpdateModel(id));
        }

        [HttpPost]
        public ActionResult Update(UpdateModel model)
        {
            if (ModelState.IsValid)
            {
                Books_BO bo = new Books_BO();
                if (bo.Update(model.obj) > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    model = new UpdateModel(model.obj.id);
                    ViewBag.erroMessage = bo.message;
                }
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Books_BO bo = new Books_BO();
            bo.Delete(id);

            return RedirectToAction("index");
        }

   

    }
}