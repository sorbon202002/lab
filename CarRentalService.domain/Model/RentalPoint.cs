using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.domain.Model;
    /// <summary>
    /// Представляет информацию о пункте проката.
    /// </summary>
    public class RentalPoint
    {
        /// <summary>
        /// Название пункта проката.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес пункта проката.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RentalPoint"/>.
        /// </summary>
        /// <param name="name">Название пункта проката.</param>
        /// <param name="address">Адрес пункта проката.</param>
        public RentalPoint(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Name} - {Address}";
        }
    }
