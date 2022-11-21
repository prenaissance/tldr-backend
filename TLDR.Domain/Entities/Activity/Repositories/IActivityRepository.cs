using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.Activity.Repositories;

public interface IActivityRepository : IRepository<Activity>
{
    IQueryable<Activity> GetAllAggregates();
}