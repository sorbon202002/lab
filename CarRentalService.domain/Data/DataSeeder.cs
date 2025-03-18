using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalService.domain.Model;

namespace CarRentalService.domain.Data
{
    /// <summary>
    /// Класс для заполнения коллекций данными
    /// </summary>
    public static class DataSeeder
    {
        /// <summary>
        /// Коллекция автомобилей, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
        /// </summary>
        public static readonly List<Car> Cars =
            new()
            {
                new()
                {
                    LicensePlate = "ABC123",
                    Model = "Toyota Camry",
                    Color = "Black"
                },
                new()
                {
                    LicensePlate = "XYZ789",
                    Model = "Honda Accord",
                    Color = "White"
                },
                new()
                {
                    LicensePlate = "LMN456",
                    Model = "Ford Focus",
                    Color = "Blue"
                },
                new()
                {
                    LicensePlate = "DEF321",
                    Model = "Chevrolet Malibu",
                    Color = "Red"
                },
                new()
                {
                    LicensePlate = "GHI654",
                    Model = "Nissan Altima",
                    Color = "Silver"
                }
            };
        /// <summary>
        /// Коллекция клиентов, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
        /// </summary>
        public static readonly List<Client> Clients =
            new()
            {
                new()
                {
                    Passport = "1234567890",
                    FullName = "Иванов Иван Иванович",
                    DateOfBirth = new DateTime(1985, 1, 1)
                },
                new()
                {
                    Passport = "0987654321",
                    FullName = "Горшкова Мария Сергеевна",
                    DateOfBirth = new DateTime(1990, 5, 15)
                },
                new()
                {
                    Passport = "1122334455",
                    FullName = "Сидоров Сергей Анатольевич",
                    DateOfBirth = new DateTime(1988, 3, 20)
                },
                new()
                {
                    Passport = "2233445566",
                    FullName = "Сидорова Анна Викторовна",
                    DateOfBirth = new DateTime(1995, 7, 30)
                },
                new()
                {
                    Passport = "3344556677",
                    FullName = "Кузнецов Дмитрий Владимирович",
                    DateOfBirth = new DateTime(1982, 12, 10)
                }
            };
        /// <summary>
        /// Коллекция пунктов проката, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
        /// </summary>
        public static readonly List<RentalPoint> RentalPoints =
            new()
            {
                new()
                {
                    Id = 1,
                    Name = "Пункт проката 1",
                    Address = "Улица 1, Город 1"
                },
                new()
                {
                    Id = 2,
                    Name = "Пункт проката 2",
                    Address = "Улица 2, Город 2"
                },
                new()
                {
                    Id = 3,
                    Name = "Пункт проката 3",
                    Address = "Улица 3, Город 3"
                }
            };
        /// <summary>
        /// Коллекция аренд, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
        /// </summary>
        public static readonly List<Rental> Rentals =
            new()
            {
                new()
                {
                    Id = 1,
                    Car = Cars[0], // Toyota Camry
                    Client = Clients[0], // Иванов Иван Иванович
                    RentalPoint = RentalPoints[0], // Пункт проката 1
                    RentalTime = new DateTime(2023, 1, 10, 10, 0, 0),
                    ReturnTime = new DateTime(2023, 1, 15, 10, 0, 0),
                    RentalDuration = 5 // 5 дней
                },
                new()
                {
                    Id = 1,
                    Car = Cars[1], // Honda Accord
                    Client = Clients[1], // Горшкова Мария Сергеевна
                    RentalPoint = RentalPoints[2], // Пункт проката 3
                    RentalTime = new DateTime(2023, 1, 10, 10, 0, 0),
                    ReturnTime = new DateTime(2023, 1, 15, 10, 0, 0),
                    RentalDuration = 5 // 5 дней
                },
                new()
                {
                    Id = 1,
                    Car = Cars[2], // Ford Focus
                    Client = Clients[2], // Сидоров Сергей Анатольевич
                    RentalPoint = RentalPoints[0], // Пункт проката 1
                    RentalTime = new DateTime(2023, 1, 10, 10, 0, 0),
                    ReturnTime = new DateTime(2023, 1, 15, 10, 0, 0),
                    RentalDuration = 5 // 5 дней
                },
                new()
                {
                    Id = 1,
                    Car = Cars[3], // Chevrolet Malibu
                    Client = Clients[3], // Сидорова Анна Викторовна
                    RentalPoint = RentalPoints[1], // Пункт проката 2
                    RentalTime = new DateTime(2023, 1, 10, 10, 0, 0),
                    ReturnTime = new DateTime(2023, 1, 15, 10, 0, 0),
                    RentalDuration = 5 // 5 дней
                }
            }
    }
