using DotNetNuke.Web.Api;

namespace MVCModule.Controllers
{
    public class RouterMapper:IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("MVCModule", "default", "{controller}/{action}", new[] { "MVCModule.Controllers.api" });
        }
    }
}