using Dreamlines.Domain.Model;
using System.Linq;

namespace Dreamlines.Tests
{
	public class ImportStructure
	{
		public SalesUnit[] salesUnits { get; set; }
		public Ship[] ships { get; set; }
		public Booking[] bookings { get; set; }

		public void RestoreReferences()
		{
			foreach(var booking in bookings)
			{
				var ship = ships.FirstOrDefault(s => s.Id == booking.ShipId);
				ship.AddBooking(booking);
			}
			foreach(var ship in ships)
			{
				var salesUnit = salesUnits.FirstOrDefault(su => su.Id == ship.SalesUnitId);
				salesUnit.AddShip(ship);
			}
		}
	}
}
