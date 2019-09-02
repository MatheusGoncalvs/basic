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

        //Método transformado em opcional serve tanto para editar quanto pra cadastrar.
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<TipoCozinha>();
            if(restaurantId.HasValue)
            {
                Restaurante = restauranteData.GetById(restaurantId.Value);
            }else
            {
                Restaurante = new Restaurante();
            }
            
            if (Restaurante == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<TipoCozinha>();
                return Page();
            }
            //Como a página Edit é reutilizada verifica se: update ou add a restaurant
            if(Restaurante.Id > 0)
            {
                restauranteData.Update(Restaurante);
            }else
            {
                restauranteData.Add(Restaurante);
            }
            
            restauranteData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurante.Id });


        }
    }
}