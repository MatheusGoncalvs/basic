using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCore;
using BasicData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace basic.Pages.Restaurantes
{
    public class DetailModel : PageModel
    {
        private readonly IRestauranteData restauranteData;

        public Restaurante Restaurante { get; set; }

        public DetailModel(IRestauranteData restauranteData)
        {
            this.restauranteData = restauranteData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurante = restauranteData.GetById(restaurantId);
            if(Restaurante == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}