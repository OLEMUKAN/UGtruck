using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckLoadingApp.Models
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [StringLength(500)]
        public string SpecialInstructions { get; set; }

        [NotMapped]
        public string FullAddress => $"{Address}, {City}, {State}, {ZipCode}, {Country}";

    }
}