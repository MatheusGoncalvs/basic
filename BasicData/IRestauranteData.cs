using BasicCore;
using System.Collections.Generic;
using System.Text;

namespace BasicData
{
    public interface IRestauranteData
    {
        IEnumerable<Restaurante> GetRestaurantsByName(string name);
        Restaurante GetById(int id);
        Restaurante Add(Restaurante newRestaurant);
        Restaurante Update(Restaurante updatedRestaurant);
        Restaurante Delete(int id);
        int Commit();
    }
}
