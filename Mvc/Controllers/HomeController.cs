using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "A set of SEO tools for everybody";

            return View();
        }

        public ActionResult About() {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult KwPosition() {


            return View();
        }

        public ActionResult PlagiarismChecker() {

            return View();
        }

        public ActionResult GooglePageRankChecker() {

            return View();
        }

    }
}
