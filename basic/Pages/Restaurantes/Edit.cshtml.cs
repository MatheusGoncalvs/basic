using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCore;
using BasicData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace basic.Pages.Restaurantes
{
    public class EditModel : PageModel
    {
        private readonly IRestauranteData restauranteData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurante Restaurante { get; set; }
        //Atributo para manter os itens do select baseado em um Enum.(IHtmlHelper)
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestauranteData restauranteData, IHtmlHelper htmlHelper)
        {
            this.restauranteData = restauranteData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<TipoCozinha>();
            Restaurante = restauranteData.GetById(restaurantId);
            if(Restaurante == null)
            {
               return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //Recupera o Enum também no POST
            Cuisines = htmlHelper.GetEnumSelectList<TipoCozinha>();
            restauranteData.Update(Restaurante);
            restauranteData.Commit();
            return Page();
        }
    }
}