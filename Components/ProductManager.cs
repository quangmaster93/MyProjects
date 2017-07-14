/*
' Copyright (c) 2015 Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using MVCModule.Models;

namespace MVCModule.Components
{
    interface IProductManager
    {
        void CreateProduct(Product p);
        void DeleteProduct(int productId, int moduleId);
        void DeleteProductById(int productId);
        void DeleteProduct(Product p);
        IEnumerable<Product> GetProducts(int moduleId);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int productId, int moduleId);
        Product GetProductById(int productId);
        void UpdateProduct(Product p);
    }

    class ProductManager : ServiceLocator<IProductManager, ProductManager>, IProductManager
    {
        public void CreateProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Insert(p);
            }
        }

        public void DeleteProduct(int productId, int moduleId)
        {
            var p = GetProduct(productId, moduleId);
            DeleteProduct(p);
        }

        public void DeleteProductById(int productId)
        {
            var p = GetProductById(productId);
            DeleteProduct(p);
        }

        public void DeleteProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Delete(p);
            }
        }

        public IEnumerable<Product> GetProducts(int moduleId)
        {
            IEnumerable<Product> p;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.Get(moduleId);
            }
            return p;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> p;
            using (IDataContext ctx=DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.Get();
            }
            return p;
        }

        public Product GetProduct(int productId, int moduleId)
        {
            Product p;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.GetById(productId, moduleId);
            }
            return p;
        }

        public Product GetProductById(int productId)
        {
            Product p;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                p = rep.GetById(productId);
            }
            return p;
        }

        public void UpdateProduct(Product p)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Product>();
                rep.Update(p);
            }
        }

        protected override System.Func<IProductManager> GetFactory()
        {
            return () => new ProductManager();
        }
    }
}
