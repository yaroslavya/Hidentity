using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hidentity.Web.Models;

namespace Hidentity.Web.Controllers
{
    /// <summary>
    /// Shows different scenarios for id hiding with hidentity.
    /// </summary>
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        /// <summary>
        /// Just showing the list of demos, nothing more.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleIdHiding(int id)
        {
            var model = new UserModel() { Id=id, Name="John"};

            return View(model);
        }

    }
}
