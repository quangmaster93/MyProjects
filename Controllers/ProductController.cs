/*
' Copyright (c) 2017 Dnn Software
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using MVCModule.Components;
using MVCModule.Models;

namespace MVCModule.Controllers
{
    [DnnHandleError]
    public class ProductController : DnnController
    {

        //public ActionResult Delete(int itemId)
        //{
        //    ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
        //    return RedirectToDefaultRoute();
        //}

        //public ActionResult Edit(int itemId = -1)
        //{
        //    DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

        //    var userlist = UserController.GetUsers(PortalSettings.PortalId);
        //    var users = from user in userlist.Cast<UserInfo>().ToList()
        //                select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

        //    ViewBag.Users = users;

        //    var item = (itemId == -1)
        //         ? new Item { ModuleId = ModuleContext.ModuleId }
        //         : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

        //    return View(item);
        //}

        //[HttpPost]
        //[DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        //public ActionResult Edit(Item item)
        //{
        //    if (item.ItemId == -1)
        //    {
        //        item.CreatedByUserId = User.UserID;
        //        item.CreatedOnDate = DateTime.UtcNow;
        //        item.LastModifiedByUserId = User.UserID;
        //        item.LastModifiedOnDate = DateTime.UtcNow;

        //        ItemManager.Instance.CreateItem(item);
        //    }
        //    else
        //    {
        //        var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
        //        existingItem.LastModifiedByUserId = User.UserID;
        //        existingItem.LastModifiedOnDate = DateTime.UtcNow;
        //        existingItem.ItemName = item.ItemName;
        //        existingItem.ItemDescription = item.ItemDescription;
        //        existingItem.AssignedUserId = item.AssignedUserId;

        //        ItemManager.Instance.UpdateItem(existingItem);
        //    }

        //    return RedirectToDefaultRoute();
        //}
        

        public ActionResult Create(int productId=0)
        {
            Product product;
            if (productId==0)
            {
                product = new Product();
                product.ProductId = productId;
            }
            else
            {
                product = ProductManager.Instance.GetProductById(productId);
            }
            
            return View("Edit",product);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            if (product.ProductId==0)
            {
                ProductManager.Instance.CreateProduct(product);
            }
            else
            {
                ProductManager.Instance.UpdateProduct(product);
            }
            return RedirectToDefaultRoute();
        }

        public ActionResult Delete(int productId)
        {
            ProductManager.Instance.DeleteProductById(productId);
            return RedirectToDefaultRoute();
        }
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var products = ProductManager.Instance.GetAllProducts();
            return View(products);
        }
    }
}
