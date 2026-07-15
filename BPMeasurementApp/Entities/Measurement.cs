using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;

namespace BPMeasurementApp.Entities
{
    public class Measurement
    {
        public int MeasurementId { get; set; }

        [Required(ErrorMessage = "Please enter Systolic value.")]
        [Range(20, 400)]
        public int? Systolic {  get; set; }

        [Required(ErrorMessage = "Please enter Diastolic Value.")]
        [Range(10, 300)]
        public int? Diastolic { get; set; }

        // Add a Position by adding "a foreign key relationship". We do this by adding
        // BOTH an id prop that is named to reflect the FK relationship (i.e. the name
        // here must be the PK name in the Position class) AND we add a full Position object
        // as a 2nd prop
        [Required(ErrorMessage = "Please specify a genre.")]
        public string? PositionId { get; set; }
        public Position? Position { get; set; }

        [Required(ErrorMessage = "Please enter a Date.")]
        [DataType(DataType.Date)]
        public DateOnly? DateTaken { get; set; }
    }
}
