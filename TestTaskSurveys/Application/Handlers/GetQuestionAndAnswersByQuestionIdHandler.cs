using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTaskSurveys.Application.Queries;
using TestTaskSurveys.Contracts.Responses;
using TestTaskSurveys.Data;

namespace TestTaskSurveys.Application.Handlers
{
    public class GetQuestionAndAnswersByQuestionIdHandler(SurveysDbContext context) :
        IRequestHandler<GetQuestionAndAnswersByQuestionIdQuery, Result<GetQuestionAndAnswersResponse>>
    {
        //TODO: Перенести логику работы с базой в нижележащий слой Repository

        private readonly SurveysDbContext _context = context;
        public async Task<Result<GetQuestionAndAnswersResponse>> Handle(GetQuestionAndAnswersByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var questionEntity = await _context.Questions
                .AsNoTracking()
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == request.questionId, cancellationToken);

            if (questionEntity == null)
            {
                return Result<GetQuestionAndAnswersResponse>.FromError("Not Found");
            }

            //TODO: прикрутить маппер/автомаппер
            var questionResponse = new GetQuestionAndAnswersResponse(
                questionEntity.Id,
                questionEntity.Text,
                questionEntity.Answers.Select(answer => new GetAnswerResponse(
                    answer.Id,
                    answer.Text))
                    .ToList()
                );

            return Result<GetQuestionAndAnswersResponse>.FromSuccess(questionResponse);
        }
    }
}
