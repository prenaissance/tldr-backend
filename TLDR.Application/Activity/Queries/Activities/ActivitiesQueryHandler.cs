using AutoMapper;
using MediatR;
using TLDR.Application.Activity.Dtos;
using TLDR.Domain.Entities.Activity;
using TLDR.Domain.Entities.Activity.Repositories;

namespace TLDR.Application.Activity.Queries.Activities;

public class ActivitiesQueryHandler : IRequestHandler<ActivitiesQuery, IList<ActivityEventDto>>
{
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;

    public ActivitiesQueryHandler(IActivityRepository activityRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _mapper = mapper;
    }

    public Task<IList<ActivityEventDto>> Handle(ActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = _activityRepository
            .GetByActorId(request.ActorId, request.Page, request.PageSize);
        return Task.FromResult(_mapper.Map<IList<ActivityEventDto>>(activities));
    }
}