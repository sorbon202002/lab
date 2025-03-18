using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarRentalService.domain.Model;

namespace CarRentalService.domain.Service.InMemory;
/// <summary>
/// Имплементация репозитория для автомобилей, которая хранит коллекцию в оперативной памяти
/// </summary>
public class CarInMemoryRepository : IRepository<Car, string>
{
    private List<Car> _cars; // Список автомобилей

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public CarInMemoryRepository()
    {
        _cars = new List<Car>(); // Инициализация списка
    }

    /// <inheritdoc/>
    public Task<Car> Add(Car entity)
    {
        _cars.Add(entity); // Добавление автомобиля в список
        return Task.FromResult(entity); // Возврат добавленного автомобиля
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(string key)
    {
        var car = await Get(key); // Получение автомобиля по номеру
        if (car != null)
            _cars.Remove(car); // Удаление автомобиля из списка
        return car != null; // Возврат результата удаления
    }

    /// <inheritdoc/>
    public Task<Car?> Get(string key) =>
        Task.FromResult(_cars.FirstOrDefault(item => item.LicensePlate == key)); // Поиск автомобиля по номеру

    /// <inheritdoc/>
    public Task<IList<Car>> GetAll() =>
        Task.FromResult((IList<Car>)_cars); // Возврат всех автомобилей

    /// <inheritdoc/>
    public async Task<Car> Update(Car entity)
    {
        await Delete(entity.LicensePlate); // Удаление старой записи
        await Add(entity); // Добавление обновленной записи
        return entity; // Возврат обновленного автомобиля
    }
}