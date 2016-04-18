using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ScheduleApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/
        public ActionResult Index()
        {
            return View();
        }
	}
}