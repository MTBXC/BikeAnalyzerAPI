using System.ComponentModel.DataAnnotations;

namespace BikeAnalyzerAPI.Models
{
    public class CreateBikeDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Brand { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Model { get; set; }
        [Required]
        public int? YearOfProduction { get; set; }
        [Required]
        [Range(60, 75)]
        public double? HeadTubeAngle { get; set; }
        [Required]
        [Range(60, 75)]
        public double? SeatTubeEffectiveAngle { get; set; }
        [Required]
        [Range(50, 200)]
        public int? TravelFrontWheel { get; set; }
        [Required]
        [Range(50, 200)]
        public int? TravelBackWheel { get; set; }
        [Required]
        [Range(15, 35)]
        public double? InnerRimWidth { get; set; }
        [Required]
        [Range(1.9, 2.6)]
        public double? TireWidth { get; set; }
        [Required]
        [Range(7, 20)]
        public double? Weigth { get; set; }

    }
}
