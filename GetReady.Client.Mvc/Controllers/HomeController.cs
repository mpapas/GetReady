using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetReady.Client.Mvc.Models;
using GetReady.Domain;

namespace GetReady.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IGetReadyProcessor _processor;

        public HomeController(IGetReadyProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Index()
        {
            return View(new GetReadyViewModel());
        }

        [HttpPost]
        public ActionResult ProcessGetReadyCommand(GetReadyViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                inputModel.OutputResult = _processor.GetReady(inputModel.InputCommandString);
                return View("index", inputModel);
            }
            else
            {
                return View("Index");
            }
        }

    }
}