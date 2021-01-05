using AppTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTeste.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();

        public ViewResult Index()
        {
            var a = dataSource.Products;
            return View(dataSource.Products);
        }
    }
}