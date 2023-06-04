using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IRequestHub
{
    public Task StatusChanged(Request request);
}