using System.Collections.Generic;
using BasicCore;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BasicData
{
    public class SqlRestaurantData : IRestauranteData
    {
        private readonly BasicDbContext db;

        public SqlRestaurantData(BasicDbContext db)
        {
            this.db = db;
        }

        public Restaurante Add(Restaurante newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurante Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.restaurantes.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurante GetById(int id)
        {
            return db.restaurantes.Find(id);
        }

        public IEnumerable<Restaurante> GetRestaurantsByName(string name)
        {
            var query = from r in db.restaurantes
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurante Update(Restaurante updatedRestaurant)
        {
            var entity = db.restaurantes.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
