using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.domain.Model;
/// <summary>
/// Представляет информацию о клиенте.
/// </summary>
public class Client
{
    /// <summary>
    /// Паспортные данные клиента.
    /// </summary>
    public string Passport { get; set; }

    /// <summary>
    /// Полное имя клиента.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Дата рождения клиента.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Client"/>.
    /// </summary>
    /// <param name="passport">Паспортные данные клиента.</param>
    /// <param name="fullName">Полное имя клиента.</param>
    /// <param name="dateOfBirth">Дата рождения клиента.</param>
    public Client(string passport, string fullName, DateTime dateOfBirth)
    {
        Passport = passport;
        FullName = fullName;
        DateOfBirth = dateOfBirth;
    }

    public override string ToString()
    {
        return $"{FullName} ({Passport})";
    }
}
