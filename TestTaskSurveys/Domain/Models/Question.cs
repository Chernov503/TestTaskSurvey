namespace TestTaskSurveys.Domain.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }

        // Навигационное свойство для Survey
        public Survey Survey { get; set; }

        // Навигационное свойство для ответов
        public ICollection<Answer> Answers { get; set; }
    }

}
