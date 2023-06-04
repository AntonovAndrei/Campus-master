using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR;

public class RequestHub : Hub, IRequestHub
{
    public async Task StatusChanged(Request request)
    {
        Console.Beep(10000, 1000);
    }
}