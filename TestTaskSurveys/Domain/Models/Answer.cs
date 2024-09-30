namespace TestTaskSurveys.Domain.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }

        // Навигационное свойство для Question
        public Question Question { get; set; }
    }

}
