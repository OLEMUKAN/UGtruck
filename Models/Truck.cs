using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TruckLoadingApp.Models
{
    public class Truck
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Capacity (Tons)")]
        public double Capacity { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey("ApplicationUser")]
        public string DriverId { get; set; }

        public ApplicationUser? Driver { get; set; }

        // Assuming CurrentLoadWeight is a property that should be added to the class
        public double? CurrentLoadWeight { get; set; }

        [NotMapped]
        public double AvailableCapacity => Capacity - (CurrentLoadWeight ?? 0);

        [NotMapped]
        public bool IsOverCapacity => CurrentLoadWeight > Capacity;

        [NotMapped]
        public bool MaintenanceDueSoon => MaintenanceDueDate.HasValue && MaintenanceDueDate.Value.Subtract(DateTime.Now).TotalDays <= 30;

        // Assuming MaintenanceDueDate is a property that should be added to the class
        public DateTime? MaintenanceDueDate { get; set; }
    }
}