namespace TestTaskSurveys.Domain.Models
{
    public class Interview
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        // Навигационное свойство для Survey
        public Survey Survey { get; set; }

        // Навигационное свойство для Result
        public ICollection<Result> Results { get; set; }
    }

}
