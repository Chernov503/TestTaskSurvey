using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTaskSurveys.Application.Commands;
using TestTaskSurveys.Data;
using TestTaskSurveys.Domain.Models;

namespace TestTaskSurveys.Application.Handlers
{
    public class CreateQuestionResultsHandler(SurveysDbContext context) : IRequestHandler<CreateQuestionResultsCommand, Result<Guid>>
    {
        //TODO: Перенести логику работы с базой в нижележащий слой Repository

        private readonly SurveysDbContext _context = context;
        public async Task<Result<Guid>> Handle(CreateQuestionResultsCommand request, CancellationToken cancellationToken)
        {
            if(request.resultList.Count() == 0)
            {
                return Result<Guid>.FromError("No one answer in request");
            }

            var resultEntityList = request.resultList.Select(r => new Domain.Models.Result() {
                Id = Guid.NewGuid(),
                InterviewId = request.interviewId,
                QuestionId = request.questionId,
                AnswerId = r.AnswerId}
                ).ToList();

            await _context.Results.AddRangeAsync(resultEntityList, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var nextQuestion = await _context.Questions
                .Where(q => q.Id == request.questionId)
                .SelectMany(q => _context.Questions
                    .Where(nq => nq.SurveyId == q.SurveyId && nq.Order == q.Order + 1))
                .FirstOrDefaultAsync();

            if (nextQuestion == null)
            {
                return Result<Guid>.FromSuccess(Guid.Empty);
            }

            return Result<Guid>.FromSuccess(nextQuestion.Id);


        }
    }
}
