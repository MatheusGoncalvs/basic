using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCore;
using BasicData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace basic.Pages.Restaurantes
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestauranteData restauranteData;

        public string Message { get; set; }
        public IEnumerable<Restaurante> Restaurantes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestauranteData restauranteData)
        {
            this.config = config;
            this.restauranteData = restauranteData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurantes = restauranteData.GetRestaurantsByName(SearchTerm);
        }
    }
}