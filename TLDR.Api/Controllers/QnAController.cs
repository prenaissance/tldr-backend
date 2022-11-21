using MediatR;
using Microsoft.AspNetCore.Mvc;
using TLDR.Application.QnA.Commands.AnswerQuestion;
using TLDR.Application.QnA.Dtos;
using TLDR.Application.QnA.Queries.AnsweredQuestions;
using TLDR.Application.QnA.Queries.AskQuestion;
using TLDR.Application.QnA.Queries.Questions;

namespace TLDR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QnAController : ControllerBase
{
    private readonly IMediator _mediator;

    public QnAController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("questions")]
    public async Task<ActionResult<QuestionDto[]>> GetQuestions(
        [FromQuery] string search = "",
        [FromQuery] bool onlyUnanswered = false)
    {
        var questions = await _mediator.Send(new QuestionsQuery(search, onlyUnanswered));
        return Ok(questions);
    }

    [HttpGet]
    [Route("answeredQuestions")]
    public async Task<ActionResult<QuestionDto[]>> GetAnsweredQuestions([FromQuery] string search = "")
    {
        var questions = await _mediator.Send(new AnsweredQuestionsQuery(search));
        return Ok(questions);
    }

    [HttpPost]
    [Route("answerQuestion")]
    public async Task<ActionResult<AnsweredQuestionDto>> AnswerQuestion([AsParameters] AnswerQuestionCommand command)
    {
        var question = await _mediator.Send(command);
        if (question is null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPost]
    [Route("askQuestion")]
    public async Task<ActionResult<QuestionDto>> AskQuestion([AsParameters] AskQuestionCommand command)
    {
        var question = await _mediator.Send(command);
        if (question is null)
        {
            return Conflict($"Question with title {command.Title} already exists");
        }
        return Ok(question);
    }
}