using Microsoft.EntityFrameworkCore;
using TLDR.Domain.Entities.QnA;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Infrastructure.Persistance.Repositories;

public class AnswerRepository : CommonRepository<Answer>, IAnswerRepository
{
    public AnswerRepository(TldrDbContext context) : base(context)
    {
    }

    public IQueryable<Answer> GetAllAggregates()
    {
        return _dbSet
            .Include(a => a.Question)
            .Include(a => a.FollowingQuestions);
    }
}