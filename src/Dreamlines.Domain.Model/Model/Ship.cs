using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dreamlines.Domain.Model
{
	public class Ship : EntityBase
    {
        [ForeignKey(nameof(SalesUnitId))]
        public virtual SalesUnit SalesUnit { get; set; }
        public int SalesUnitId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public void AddBooking(Booking booking)
		{
            Bookings.Add(booking);
            booking.Ship = this;
		}
    }
}
