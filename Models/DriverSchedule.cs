using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadingApp.Models
{
    public class DriverSchedule
    {
        [Key]
        public Guid ScheduleId { get; set; }

        [Required]
        public string DriverId { get; set; }

        [ForeignKey("DriverId")]
        public ApplicationUser Driver { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public Guid? RouteId { get; set; }

        [ForeignKey("RouteId")]
        public TRoute? Route { get; set; }

        public string Status { get; set; } = "Scheduled";

        [Range(0, 24)]
        public double DrivingHours { get; set; }

        [Range(0, 24)]
        public double RestHours { get; set; }

        public bool IsOvertime { get; set; }

        [NotMapped]
        public double TotalHours => DrivingHours + RestHours;
        [NotMapped]
        public bool IsWithinLegalLimit => DrivingHours <= 11;

        [NotMapped]
        public double RemainingDrivingHours => Math.Max(0, 11 - DrivingHours);

    }
}