using Xunit;
using CarRentalService.Domain.Service.InMemory; // ��������������, ��� ��� ����������� ��������� � ���� ������������ ����
using CarRentalService.Domain.Data; // ��� ������� � DataSeeder

namespace CarRentalService.Tests
{
    /// <summary>
    /// ����� � ����-������� ����������� ������ �����������
    /// </summary>
    public class RentalInMemoryRepositoryTests
    {
        private readonly RentalInMemoryRepository _repository;

        public RentalInMemoryRepositoryTests()
        {
            // ������������� ����������� � ������� �� DataSeeder
            _repository = new RentalInMemoryRepository();
            SeedData(); // ���������� �������
        }

        /// <summary>
        /// ����� ��� ���������� ����������� �������
        /// </summary>
        private void SeedData()
        {
            foreach (var rental in DataSeeder.Rentals)
            {
                _repository.Add(rental).Wait(); // ��������� ������ � �����������
            }
        }

        /// <summary>
        /// ���� ������, ������������� ��� 5 �������� ����� ���������� �����������
        /// </summary>
        [Fact]
        public async Task GetTop5MostRentedCars_Success()
        {
            var topCars = await _repository.GetTop5MostRentedCars(); // ������������, ��� ����� ����������

            Assert.NotNull(topCars);
            Assert.True(topCars.Count <= 5); // ���������, ��� ���������� �� ��������� 5
        }

        /// <summary>
        /// ���� ������, ������������, ��� ������������ ���������� �� ����� null
        /// </summary>
        [Fact]
        public async Task GetTop5MostRentedCars_ValidData()
        {
            var topCars = await _repository.GetTop5MostRentedCars(); // ������������, ��� ����� ����������

            // ���������, ��� ��� ���������� � ���� �� ����� null � ����� ���������� ������
            foreach (var tuple in topCars)
            {
                Assert.NotNull(tuple.Item1); // ���������, ��� ���������� �� null
                Assert.True(tuple.Item2 > 0); // ���������, ��� ���������� ������ ������ 0
            }
        }

        /// <summary>
        /// ���� ������, ������������, ��� ������������ ���������� ����� ���������� ������
        /// </summary>
        [Fact]
        public async Task GetCarWithRentals_Success()
        {
            var carWithRentals = await _repository.GetCarWithRentals("ABC123"); // ������������, ��� "ABC123" - ��� ����� ����������

            Assert.NotNull(carWithRentals);
            Assert.NotNull(carWithRentals.Item1); // ���������, ��� ���������� �� null
            Assert.NotNull(carWithRentals.Item2); // ���������, ��� ���������� ������ �� null
        }
    }
}