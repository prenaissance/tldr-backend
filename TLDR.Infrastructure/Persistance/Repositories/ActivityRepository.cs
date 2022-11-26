using Microsoft.EntityFrameworkCore;
using TLDR.Domain.Entities.Activity;
using TLDR.Domain.Entities.Activity.Repositories;

namespace TLDR.Infrastructure.Persistance.Repositories;

public class ActivityRepository : CommonRepository<ActivityEvent>, IActivityRepository
{
    public ActivityRepository(TldrDbContext context) : base(context) { }

    public IList<ActivityEvent> GetByActorId(Guid actorId, int page = 0, int pageSize = 0)
    {
        var actor = _context.Users
            .AsNoTracking()
            .Include(u => u.Activities)
            .FirstOrDefault(u => u.Id == actorId);

        if (actor is null)
        {
            return new List<ActivityEvent>();
        }
        if (pageSize == 0)
        {
            return actor.Activities.ToList();
        }
        return actor.Activities
            .OrderByDescending(a => a.CreatedAt)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public bool AddEvent(Guid actorId, ActivityEvent activityEvent)
    {
        var actor = _context.Users
            .Include(u => u.Activities)
            .FirstOrDefault(u => u.Id == actorId);

        if (actor is null)
        {
            return false;
        }
        actor.Activities.Add(activityEvent);
        _context.SaveChanges();
        return true;
    }
}