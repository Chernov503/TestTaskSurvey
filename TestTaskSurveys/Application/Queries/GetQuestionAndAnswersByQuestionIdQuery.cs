using MediatR;
using TestTaskSurveys.Contracts.Responses;

namespace TestTaskSurveys.Application.Queries
{
    public record GetQuestionAndAnswersByQuestionIdQuery(Guid questionId) : IRequest<Result<GetQuestionAndAnswersResponse>>;

}
