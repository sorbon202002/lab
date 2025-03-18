using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalService.domain.Model;

namespace CarRentalService.domain.Service;

public interface ICarRepository : IRepository<Car, int>
{
    /// <summary>
    /// Вывести информацию обо всех транспортных средствах.
    /// </summary>
    Task<IList<Car>> GetAllCarType();

    /// <summary>
    /// Вывести информацию о топ 5 наиболее часто арендуемых автомобилях.
    /// </summary>
    /// <returns>Список кортежей с номером автомобиля и количество часов</returns>
    Task<IList<(string Number, int RentalCount)>> Top5MostRentedBicycles { get; }
}

