using Xunit;
using CarRentalService.Domain.Service.InMemory; // Предполагается, что ваш репозиторий находится в этом пространстве имен
using CarRentalService.Domain.Data; // Для доступа к DataSeeder

namespace CarRentalService.Tests
{
    /// <summary>
    /// Класс с юнит-тестами репозитория аренды автомобилей
    /// </summary>
    public class RentalInMemoryRepositoryTests
    {
        private readonly RentalInMemoryRepository _repository;

        public RentalInMemoryRepositoryTests()
        {
            // Инициализация репозитория с данными из DataSeeder
            _repository = new RentalInMemoryRepository();
            SeedData(); // Заполнение данными
        }

        /// <summary>
        /// Метод для заполнения репозитория данными
        /// </summary>
        private void SeedData()
        {
            foreach (var rental in DataSeeder.Rentals)
            {
                _repository.Add(rental).Wait(); // Добавляем аренды в репозиторий
            }
        }

        /// <summary>
        /// Тест метода, возвращающего топ 5 наиболее часто арендуемых автомобилей
        /// </summary>
        [Fact]
        public async Task GetTop5MostRentedCars_Success()
        {
            var topCars = await _repository.GetTop5MostRentedCars(); // Предполагаем, что метод существует

            Assert.NotNull(topCars);
            Assert.True(topCars.Count <= 5); // Проверяем, что количество не превышает 5
        }

        /// <summary>
        /// Тест метода, проверяющего, что возвращаемые автомобили не равны null
        /// </summary>
        [Fact]
        public async Task GetTop5MostRentedCars_ValidData()
        {
            var topCars = await _repository.GetTop5MostRentedCars(); // Предполагаем, что метод существует

            // Проверяем, что все автомобили в топе не равны null и имеют корректные данные
            foreach (var tuple in topCars)
            {
                Assert.NotNull(tuple.Item1); // Проверяем, что автомобиль не null
                Assert.True(tuple.Item2 > 0); // Проверяем, что количество аренды больше 0
            }
        }

        /// <summary>
        /// Тест метода, проверяющего, что возвращаемый автомобиль имеет корректные данные
        /// </summary>
        [Fact]
        public async Task GetCarWithRentals_Success()
        {
            var carWithRentals = await _repository.GetCarWithRentals("ABC123"); // Предполагаем, что "ABC123" - это номер автомобиля

            Assert.NotNull(carWithRentals);
            Assert.NotNull(carWithRentals.Item1); // Проверяем, что автомобиль не null
            Assert.NotNull(carWithRentals.Item2); // Проверяем, что количество аренды не null
        }
    }
}