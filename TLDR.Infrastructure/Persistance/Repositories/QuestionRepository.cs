using Microsoft.EntityFrameworkCore;
using TLDR.Domain.Entities.QnA;
using TLDR.Domain.Entities.QnA.Repositories;

namespace TLDR.Infrastructure.Persistance.Repositories;

public class QuestionRepository : CommonRepository<Question>, IQuestionRepository
{
    public QuestionRepository(TldrDbContext context) : base(context)
    {
    }
    public Question? GetAggregateById(Guid id)
    {
        return _dbSet
            .Include(q => q.Answers)
            .FirstOrDefault(q => q.Id == id);
    }

    public IQueryable<Question> GetAllAggregates()
    {
        return _dbSet
            .Include(q => q.Answers);
    }
}