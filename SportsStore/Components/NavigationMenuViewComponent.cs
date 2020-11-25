using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repo;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repo.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }

    }
}
