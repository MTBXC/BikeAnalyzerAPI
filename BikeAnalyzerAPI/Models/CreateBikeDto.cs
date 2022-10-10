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
        [Range(65, 70)]
        public double? HeadTubeAngle { get; set; }
        [Required]
        [Range(70, 80)]
        public double? SeatTubeEffectiveAngle { get; set; }
        [Required]
        [Range(100, 120)]
        public int? TravelFrontWheel { get; set; }
        [Required]
        [Range(100, 120)]
        public int? TravelBackWheel { get; set; }
        [Required]
        [Range(20, 30)]
        public double? InnerRimWidth { get; set; }
        [Required]
        [Range(2, 2.4)]
        public double? TireWidth { get; set; }
        [Required]
        [Range(9, 14)]
        public double? Weigth { get; set; }

        public double? GeneralBikeRate { get; set; }

    }
}
