using BasicCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicData
{
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

        public int Commit()
        {
            return 0;
        }

        public Restaurante Add(Restaurante newRestaurant)
        {
            restaurantes.Add(newRestaurant);
            newRestaurant.Id = restaurantes.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurante Update(Restaurante updatedRestaurant)
        {
            var restaurant = restaurantes.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cozinha = updatedRestaurant.Cozinha;
            }
            return restaurant;
        }

        public Restaurante GetById(int id)
        {
            return restaurantes.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurante> GetRestaurantsByName(string name = null)
        {
            return from r in restaurantes
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurante Delete(int id)
        {
            var restaurant = restaurantes.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurantes.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
