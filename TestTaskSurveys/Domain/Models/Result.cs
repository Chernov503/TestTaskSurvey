namespace TestTaskSurveys.Domain.Models
{

    public class Result
    {
        public Guid Id { get; set; }
        public Guid InterviewId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }

        // Уникальное ограничение InterviewId и QuestionId
        public Interview Interview { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }

}
