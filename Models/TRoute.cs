using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadingApp.Models
{
    public class TRoute
    {
        [Key]
        public Guid RouteId { get; set; }

        [Required]
        public Guid OriginId { get; set; }

        [ForeignKey("OriginId")]
        public Location Origin { get; set; }

        [Required]
        public Guid DestinationId { get; set; }

        [ForeignKey("DestinationId")]
        public Location Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Available Date")]
        public DateTime AvailableDate { get; set; }

        public string DriverId { get; set; }

        [ForeignKey("DriverId")]
        public ApplicationUser? Driver { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double CurrentCapacityPercentage { get; set; }

        [Required]
        public bool IsReturnTrip { get; set; }

        [Required]
        [Range(0, 1000000)]
        public double DistanceInMiles { get; set; }

        public Guid? TruckId { get; set; }

        [ForeignKey("TruckId")]
        public Truck? Truck { get; set; }

        [NotMapped]
        public double AvailableCapacity => Truck?.Capacity * (1 - CurrentCapacityPercentage / 100) ?? 0;
        [NotMapped]
        public bool IsAvailableForBooking => AvailableCapacity > 0 && DateTime.Now <= AvailableDate;


    }
}