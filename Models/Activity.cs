namespace PertChartGenerator.Models
{
    public class Activity
    {
        public required string Name { get; set; }
        public List<string>? Precedence { get; set; }
        public double OptimisticTime { get; set; }
        public double MostLikelyTime { get; set; }
        public double PessimisticTime { get; set; }
        public double ExpectedTime { get; set; }
        public double EarliestStart { get; set; }
        public double EarliestFinish { get; set; }
        public double LatestStart { get; set; }
        public double LatestFinish { get; set; }
        public double TotalFloat { get; set; }
        public bool IsOnCriticalPath { get; set; }
    }
}
