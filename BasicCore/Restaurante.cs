using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCore
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public TipoCozinha Cozinha { get; set; }
    }
}
