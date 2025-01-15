using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadingApp.Models
{
    public class Shipment
    {
        [Key]
        public Guid ShipmentId { get; set; }

        [Required]
        public string ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ApplicationUser Client { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpectedDeliveryDate { get; set; }

        public string Status { get; set; } = "Pending";

        public ICollection<Load> Loads { get; set; }

        [StringLength(500)]
        public string SpecialInstructions { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        public bool IsUrgent { get; set; }

        [NotMapped]
        public double TotalWeight => Loads?.Sum(load => load.WeightInTons) ?? 0;

        [NotMapped]
        public bool IsOnTime => ExpectedDeliveryDate <= DateTime.Now;

        [NotMapped]
        public double TotalVolume => Loads?.Sum(load => load.VolumeInCubicFeet) ?? 0;

    }
}