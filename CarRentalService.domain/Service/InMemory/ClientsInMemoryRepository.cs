using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalService.domain.Model;
using System.Xml.Linq;

namespace CarRentalService.Domain.Services.InMemory
{
    /// <summary>
    /// Имплементация репозитория для клиентов, которая хранит коллекцию в оперативной памяти 
    /// </summary>
    public class ClientInMemoryRepository
    {
        private List<Client> clients; // Список клиентов
        private List<Rental> rentals; // Список аренд

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        public ClientInMemoryRepository()
        {
            clients = DataSeeder.Clients; // Инициализация списка клиентов
            rentals = DataSeeder.Rentals; // Инициализация списка аренд

            // Связываем записи аренды с клиентами
            foreach (var rental in rentals)
            {
                rental.Client = clients.FirstOrDefault(c => c.Passport == rental.Client.Passport);
            }
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="entity">Клиент</param>
        /// <returns>Добавленный клиент</returns>
        public Task<Client> Add(Client entity)
        {
            clients.Add(entity); // Добавление клиента в список
            return Task.FromResult(entity); // Возврат добавленного клиента
        }

        /// <summary>
        /// Удаление клиента по паспорту
        /// </summary>
        /// <param name="key">Паспорт клиента</param>
        /// <returns>Результат операции</returns>
        public async Task<bool> Delete(string key)
        {
            var client = await Get(key); // Получение клиента по паспорту
            if (client != null)
            {
                clients.Remove(client); // Удаление клиента из списка
                return true; // Успешное удаление
            }
            return false; // Клиент не найден
        }

        /// <summary>
        /// Обновление информации о клиенте
        /// </summary>
        /// <param name="entity">Обновленный клиент</param>
        /// <returns>Обновленный клиент</returns>
        public async Task<Client> Update(Client entity)
        {
            await Delete(entity.Passport); // Удаление старой записи
            await Add(entity); // Добавление обновленной записи
            return entity; // Возврат обновленного клиента
        }

        /// <summary>
        /// Получение клиента по паспорту
        /// </summary>
        /// <param name="key">Паспорт клиента</param>
        /// <returns>Клиент</returns>
        public Task<Client?> Get(string key) =>
            Task.FromResult(clients.FirstOrDefault(c => c.Passport == key)); // Поиск клиента по паспорту

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns>Список всех клиентов</returns>
        public Task<IList<Client>> GetAll() =>
            Task.FromResult((IList<Client>)clients); // Возврат всех клиентов

        /// <summary>
        /// Получение клиентов, которые арендовали автомобили в определенный период
        /// </summary>
        /// <param name="startDate">Дата начала</param>
        /// <param name="endDate">Дата окончания</param>
        /// <returns>Список клиентов, арендовавших автомобили</returns>
        public async Task<IList<Client>> GetClientsByRentalDate(DateTime startDate, DateTime endDate)
        {
            var clientIds = rentals
                .Where(r => r.RentalTime >= startDate && r.RentalTime <= endDate)
                .Select(r => r.Client.Passport)
                .Distinct()
                .ToList();

            var clientsInPeriod = clients
                .Where(c => clientIds.Contains(c.Passport))
                .ToList();

            return await Task.FromResult(clientsInPeriod); // Возврат клиентов, арендовавших автомобили в заданный период
        }
    }
}