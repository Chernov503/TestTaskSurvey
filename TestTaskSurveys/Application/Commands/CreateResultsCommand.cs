using MediatR;
using TestTaskSurveys.Contracts.Requests;

namespace TestTaskSurveys.Application.Commands
{
    public record CreateQuestionResultsCommand(Guid interviewId, Guid questionId, List<CreateResultRequest> resultList) : IRequest<Result<Guid>>;
}
