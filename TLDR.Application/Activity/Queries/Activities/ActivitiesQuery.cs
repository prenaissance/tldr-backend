using MediatR;
using TLDR.Application.Activity.Dtos;
using TLDR.Domain.Entities.Activity;

namespace TLDR.Application.Activity.Queries.Activities;

public record ActivitiesQuery(Guid ActorId, int Page, int PageSize) : IRequest<IList<ActivityEventDto>>;