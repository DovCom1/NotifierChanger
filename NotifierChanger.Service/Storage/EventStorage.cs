using NotifierChanger.Infrastructure;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Storage;
using NotifierChanger.Service.Extensions;

namespace NotifierChanger.Service.Storage;

public class EventStorage(PostgresDbContext context) : IEventStorage
{
    private readonly PostgresDbContext _context = context;
    public async Task AddMessageEvent(MessageEventDto dto)
    {
        await _context.AddAsync(dto.ToMessageEvent());
    }

    public async Task AddCallEvent(CallEventDto dto)
    {
        await _context.AddAsync(dto.ToCallEvent());
    }

    public async Task AddInviteEvent(InviteEventDto dto)
    {
        await _context.AddAsync(dto.ToInviteEvent());
    }
}