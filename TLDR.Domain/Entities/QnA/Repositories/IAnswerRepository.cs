using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.QnA.Repositories;

public interface IAnswerRepository : IRepository<Answer>
{
    IQueryable<Answer> GetAllAggregates();
}