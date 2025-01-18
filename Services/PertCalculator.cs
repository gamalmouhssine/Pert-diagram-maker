using PertChartGenerator.Models;

namespace PertChartGenerator.Services
{
    public class PertCalculator
    {
        public PertAnalysisResult CalculatePert(List<Activity> activities)
        {
            // Calculate Expected Time (TE)
            foreach (var activity in activities)
            {
                activity.ExpectedTime = Math.Round(
                    (activity.OptimisticTime + 4 * activity.MostLikelyTime + activity.PessimisticTime) / 6.0,
                    2
                );
                Console.WriteLine($"{activity.Name}: TE = {activity.ExpectedTime}");
            }

            CalculateForwardPass(activities);
            CalculateBackwardPass(activities);

            // Calculate Float and identify critical path
            var criticalPath = new List<Activity>();
            foreach (var activity in activities)
            {
                activity.TotalFloat = Math.Round(activity.LatestStart - activity.EarliestStart, 2);
                if (Math.Abs(activity.TotalFloat) < 0.01) // Critical path has zero float
                {
                    activity.IsOnCriticalPath = true;
                    criticalPath.Add(activity);
                }
                Console.WriteLine($"{activity.Name}: ES = {activity.EarliestStart}, EF = {activity.EarliestFinish}, LS = {activity.LatestStart}, LF = {activity.LatestFinish}, Float = {activity.TotalFloat}");
            }

            return new PertAnalysisResult
            {
                Activities = activities,
                CriticalPath = OrderCriticalPath(criticalPath, activities),
                ProjectDuration = activities.Max(a => a.EarliestFinish)
            };
        }

        private List<Activity> OrderCriticalPath(List<Activity> criticalPath, List<Activity> allActivities)
        {
            var ordered = new List<Activity>();
            var remaining = new HashSet<Activity>(criticalPath);

            while (remaining.Any())
            {
                var next = remaining.FirstOrDefault(a =>
                    !a.Precedence.Any() ||
                    !a.Precedence.Any(p => remaining.Any(r => r.Name == p)));

                if (next == null) break; 

                ordered.Add(next);
                remaining.Remove(next);
            }

            return ordered;
        }

        private void CalculateForwardPass(List<Activity> activities)
        {
            var processed = new HashSet<string>();

            while (processed.Count < activities.Count)
            {
                foreach (var activity in activities)
                {
                    if (processed.Contains(activity.Name)) continue;

                    var predecessors = activities
                        .Where(a => activity.Precedence.Contains(a.Name))
                        .ToList();

                    if (!predecessors.Any() || predecessors.All(p => processed.Contains(p.Name)))
                    {
                        activity.EarliestStart = predecessors.Any()
                            ? predecessors.Max(p => p.EarliestFinish) // Start after the last predecessor finishes
                            : 0;                                      // Start at time 0 if no dependencies
                        activity.EarliestFinish = Math.Round(activity.EarliestStart + activity.ExpectedTime, 2);
                        processed.Add(activity.Name);
                    }
                }
            }
        }

        private void CalculateBackwardPass(List<Activity> activities)
        {
            var processed = new HashSet<string>();
            double projectEnd = activities.Max(a => a.EarliestFinish);

            foreach (var activity in activities)
            {
                activity.LatestFinish = projectEnd;
            }

            while (processed.Count < activities.Count)
            {
                foreach (var activity in activities.OrderByDescending(a => a.EarliestFinish))
                {
                    if (processed.Contains(activity.Name)) continue;

                    var successors = activities
                        .Where(a => a.Precedence.Contains(activity.Name))
                        .ToList();

                    if (!successors.Any() || successors.All(s => processed.Contains(s.Name)))
                    {
                        activity.LatestFinish = successors.Any()
                            ? successors.Min(s => s.LatestStart) // Finish before the earliest successor starts
                            : projectEnd;                       // Finish at project end if no successors
                        activity.LatestStart = Math.Round(activity.LatestFinish - activity.ExpectedTime, 2);
                        processed.Add(activity.Name);
                    }
                }
            }
        }
    }
}
