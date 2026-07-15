using System.Diagnostics.Metrics;
using BPMeasurementApp.Entities;

namespace BPMeasurementApp.Models
{
    public class MeasurementViewModel
    {
        public List<Position>? Positions;
        public Measurement? ActiveMeasurement { get; set; }
    }
}
