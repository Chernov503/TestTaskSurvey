namespace TestTaskSurveys.Contracts.Responses
{
    public record GetQuestionAndAnswersResponse(
       Guid Id,
       string Text,
       List<GetAnswerResponse> answerList);
}
