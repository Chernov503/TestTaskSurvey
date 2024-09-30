namespace TestTaskSurveys.Domain.Models
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационное свойство для вопросов
        public ICollection<Question> Questions { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }

}
