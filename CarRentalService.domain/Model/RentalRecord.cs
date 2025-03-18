using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.domain.Model;
/// <summary>
/// Представляет информацию о выданном автомобиле.
/// </summary>
public class RentalRecord
{
    /// <summary>
    /// Автомобиль.
    /// </summary>
    public Car Car { get; set; }

    /// <summary>
    /// Клиент.
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Время выдачи автомобиля.
    /// </summary>
    public DateTime PickupTime { get; set; }

    /// <summary>
    /// Пункт проката, где был выдан автомобиль.
    /// </summary>
    public RentalPoint PickupPoint { get; set; }

    /// <summary>
    /// Срок аренды (в днях).
    /// </summary>
    public int RentalDuration { get; set; }

    /// <summary>
    /// Время возврата автомобиля (может быть null, если автомобиль еще не возвращен).
    /// </summary>
    public DateTime? ReturnTime { get; set; }

    /// <summary>
    /// Пункт проката, где был возвращен автомобиль (может быть null, если автомобиль еще не возвращен).
    /// </summary>
    public RentalPoint ReturnPoint { get; set; }
}
