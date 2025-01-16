using MediatR;
using TaskTracking.Domain.Dto;
using TaskTracking.Domain.Models;

namespace TaskTracking.Application.Messages.Querys;

public record GetUsersRangeQuery(RangePagination Range) : IRequest<IEnumerable<UserDto>>;