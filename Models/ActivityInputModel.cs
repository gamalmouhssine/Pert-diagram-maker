using System.ComponentModel.DataAnnotations;

namespace PertChartGenerator.Models
{
    public class ActivityInputModel
    {
        public required string Name { get; set; }
        [Display(Name = "Precedence (comma separated)")]
        public string PrecedenceString { get; set; }
        [Display(Name = "Optimistic Time")]
        public double OptimisticTime { get; set; }
        [Display(Name = "Most Likely Time")]
        public double MostLikelyTime { get; set; }
        [Display(Name = "Pessimistic Time")]
        public double PessimisticTime { get; set; }

    }
}
