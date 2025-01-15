using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NuGet.Packaging.Signing;

namespace TruckLoadingApp.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }

        [Required]
        public Guid RouteId { get; set; }

        public ICollection<Load> Loads { get; set; } = new List<Load>();

        [ForeignKey("RouteId")]
        public TRoute Route { get; set; }

        [Required]
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ApplicationUser Client { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public string Status { get; set; } = "Booked";

        [NotMapped]
        public bool IsConfirmed => Status == "Confirmed";

        [NotMapped]
        public double TotalWeight => Loads?.Sum(load => load.WeightInTons) ?? 0;

        [NotMapped]
        public bool IsFullLoad => Route?.Truck?.Capacity <= TotalWeight;


    }
}
