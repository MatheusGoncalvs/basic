using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace basic.Pages.Restaurantes
{
    public class DetailModel : PageModel
    {
        public Restaurante Restaurante { get; set; }

        public void OnGet()
        {
            Restaurante = new Restaurante();
        }
    }
}