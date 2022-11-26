using TLDR.Domain.Entities.Common.Abstractions;

namespace TLDR.Domain.Entities.Activity.Repositories;

public interface IActivityRepository : IRepository<ActivityEvent>
{
    IList<ActivityEvent> GetByActorId(Guid actorId, int page, int pageSize);
    bool AddEvent(Guid actorId, ActivityEvent activityEvent);
}