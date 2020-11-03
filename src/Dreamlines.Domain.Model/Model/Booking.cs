using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dreamlines.Domain.Model
{
    public class Booking : EntityBase
    {
        [ForeignKey(nameof(Ship))]
        public int ShipId { get; set; }
        public virtual Ship Ship { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
    }
}
