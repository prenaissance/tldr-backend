using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.QnA.Repositories;

public interface IQuestionRepository : IRepository<Question>
{
    IQueryable<Question> GetAllAggregates();
    Question? GetAggregateById(Guid id);
}