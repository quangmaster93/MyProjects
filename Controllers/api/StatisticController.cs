using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DotNetNuke.Web.Api;
using MVCModule.Components;
using MVCModule.Models;

namespace MVCModule.Controllers.api
{
    public class StatisticController : DnnApiController
    {
        [System.Web.Http.HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public IHttpActionResult Update(Statistic statistic)
        {
            if (statistic.StatisticId == 0)
            {
                StatisticManager.Instance.CreateStatistic(statistic);
            }
            else
            {
                StatisticManager.Instance.UpdateStatistic(statistic);
            }
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Delete(Statistic statistic)
        {
            StatisticManager.Instance.DeleteStatisticById(statistic.StatisticId);
            return Ok();
        }
    }
}
