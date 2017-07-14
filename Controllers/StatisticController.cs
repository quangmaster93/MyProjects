using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using MVCModule.Components;
using MVCModule.Models;

namespace MVCModule.Controllers
{
    [DnnHandleError]
    public class StatisticController : DnnController
    {
        // GET: Statistic
        public ActionResult Index()
        {
            var statistics = StatisticManager.Instance.GetAllStatistics();
            return View(statistics);
        }
    }
}