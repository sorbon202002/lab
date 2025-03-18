using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.domain.Model;
/// <summary>
/// Представляет информацию об автомобиле.
/// </summary>
public class Car
{
    /// <summary>
    /// Номер автомобиля.
    /// </summary>
    public string LicensePlate { get; set; }

    /// <summary>
    /// Модель автомобиля.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Цвет автомобиля.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Car"/>.
    /// </summary>
    /// <param name="licensePlate">Номер автомобиля.</param>
    /// <param name="model">Модель автомобиля.</param>
    /// <param name="color">Цвет автомобиля.</param>
    public Car(string licensePlate, string model, string color)
    {
        LicensePlate = licensePlate;
        Model = model;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Model} ({LicensePlate})";
    }

