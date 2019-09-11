using BasicData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic.ViewComponents
{
    public class RestaurantViewComponent : ViewComponent
    {
        private readonly IRestauranteData restauranteData;

        public RestaurantViewComponent(IRestauranteData restauranteData)
        {
            this.restauranteData = restauranteData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restauranteData.GetCountOfRestaurant();
            return View(count);
        }
    }
}
