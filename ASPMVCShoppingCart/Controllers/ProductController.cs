using ASPMVCShoppingCart.Models;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace ASPMVCShoppingCart.Controllers
{
    public class ProductController : Controller
    {

        private DemoDBEntities de = new DemoDBEntities(); // Accessing relative path from connection string.

        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            var onePageOfProducts = de.tblProducts.OrderBy(x => x.Id).ToPagedList(pageNumber, 15); // will only contain 5 products max because of the pageSize
            
            ViewBag.ListProducts = onePageOfProducts; // Store pages in ViewBag to access them on the view

            return View();
        }

    }
}
