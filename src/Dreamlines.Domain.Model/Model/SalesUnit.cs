using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dreamlines.Domain.Model
{
	public class SalesUnit : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }

        public void AddShip(Ship ship)
		{
            Ships.Add(ship);
            ship.SalesUnit = this;
		}

        public decimal CalculateBookingSummary()
		{
            decimal result = 0;
            foreach(var ship in Ships)
			{
                foreach(var booking in ship.Bookings)
				{
                    result += booking.Price;
				}
			}
            return result;
		}
    }
}
