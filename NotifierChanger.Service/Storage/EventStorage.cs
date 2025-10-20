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
}