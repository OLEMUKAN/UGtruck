using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadingApp.Models
{
    public class Load
    {
        private const double StandardTruckCapacity = 20.0; // Example value, adjust as needed
        private const double StandardTruckVolume = 500.0; // Example value, adjust as needed

        [Key]
        public Guid LoadId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double WeightInTons { get; set; }

        [Required]
        [Range(0, 1000)]
        public double VolumeInCubicFeet { get; set; }

        [Required]
        public Guid PickupLocationId { get; set; }

        [ForeignKey("PickupLocationId")]
        public Location PickupLocation { get; set; }

        [Required]
        public Guid DeliveryLocationId { get; set; }

        [ForeignKey("DeliveryLocationId")]
        public Location DeliveryLocation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        public Guid? ShipmentId { get; set; }

        [ForeignKey("ShipmentId")]
        public Shipment? Shipment { get; set; }

        public Guid? BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }

        [NotMapped]
        public bool IsOversized => WeightInTons > StandardTruckCapacity || VolumeInCubicFeet > StandardTruckVolume;
        [NotMapped]
        public TimeSpan TransitDuration => DeliveryDate - PickupDate;

    }
}