
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestTaskSurveys.Application.Commands;
using TestTaskSurveys.Application.Queries;
using TestTaskSurveys.Contracts.Requests;
using TestTaskSurveys.Contracts.Responses;

namespace TestTaskSurveys.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterviewController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{interviewId:guid}/question={questionId:guid}")]
        public async Task<ActionResult<GetQuestionAndAnswersResponse>> GetQuestionAsync([FromRoute]Guid questionId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetQuestionAndAnswersByQuestionIdQuery(questionId), cancellationToken);

            if (!result.IsSuccess())
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
        [HttpPost("{interviewId:guid}/question={questionId:guid}")]
        public async Task<ActionResult<CreateQuestionResultsResponse>> CreateQuestionResultsAsync([FromRoute] Guid questionId,
                                                                                                  [FromRoute] Guid interviewId,
                                                                                                  [FromBody] CreateQuestionResultsRequest request,
                                                                                                  CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateQuestionResultsCommand(interviewId, questionId, request.ResultList), cancellationToken);

            if (!result.IsSuccess())
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

    }

    




}


