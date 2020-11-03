using Dreamlines.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamlines.Infrastructure.Repositories
{
	public class ImportStructure
	{
		public SalesUnit[] salesUnits { get; set; }
		public Ship[] ships { get; set; }
		public Booking[] bookings { get; set; }

		public void RestoreReferences()
		{
			foreach (var booking in bookings)
			{
				var ship = ships.FirstOrDefault(s => s.Id == booking.ShipId);
				ship.AddBooking(booking);
			}
			foreach (var ship in ships)
			{
				var salesUnit = salesUnits.FirstOrDefault(su => su.Id == ship.SalesUnitId);
				salesUnit.AddShip(ship);
			}
		}

		public void CleanupIds()
		{
			foreach (var salesUnit in salesUnits)
			{
				salesUnit.Id = 0;
				foreach (var ship in salesUnit.Ships)
				{
					ship.Id = 0;
					ship.SalesUnitId = 0;
					foreach (var booking in ship.Bookings)
					{
						booking.Id = 0;
						booking.ShipId = 0;
					}
				}
			}
		}
	}
}
