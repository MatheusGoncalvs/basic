﻿using BasicCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData
{
    public interface IRestauranteData
    {
        IEnumerable<Restaurante> GetAll();
    }
    public class InMemoryRestaurantData : IRestauranteData
    {
        readonly List<Restaurante> restaurantes;

        public InMemoryRestaurantData()
        {
            restaurantes = new List<Restaurante>()
            {
                new Restaurante {Id = 1, Name = "Scott's Pizza", Cozinha = TipoCozinha.Brasileira, Location = "New York"},
                new Restaurante {Id = 2, Name = "La Casine", Cozinha = TipoCozinha.Italiana, Location = "São Paulo"},
                new Restaurante {Id = 3, Name = "Fausto's Pizza", Cozinha = TipoCozinha.Brasileira, Location = "Rio de Janeiro"}
            };
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return from r in restaurantes
                   orderby r.Name
                   select r;
        }
    }
}
