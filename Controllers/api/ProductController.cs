using System.Web.Http;
using DotNetNuke.Web.Api;
using DotNetNuke.Web.Api.Internal;
using MVCModule.Components;
using MVCModule.Models;

namespace MVCModule.Controllers.api
{
    public class ProductController : DnnApiController
    {
        [DnnAuthorize]
        [HttpPost]
        [DnnPageEditor]
        public IHttpActionResult Delete(Product product)
        {
            ProductManager.Instance.DeleteProductById(product.ProductId);
            return Ok();
        }
    }
}
