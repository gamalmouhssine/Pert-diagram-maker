namespace PertChartGenerator.Models
{
    public class PertAnalysisResult
    {
        public List<Activity> Activities { get; set; }
        public List<Activity> CriticalPath { get; set; }
        public double ProjectDuration { get; set; }
    }
}
