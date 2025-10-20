using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Entities;

namespace NotifierChanger.Service.Extensions;

public static class DtoExtensions
{
    public static MessageEvent ToMessageEvent(this MessageEventDto dto)
    {
        return new MessageEvent
        {
            SenderId = dto.SenderId,
            ReceiverId = dto.ReceiverId,
            ChatId = dto.ChatId,
            SenderName = dto.SenderName,
            ReceiverName = dto.ReceiverName,
            ChatName = dto.ChatName,
            Message = dto.Message,
            CreatedAt = dto.CreatedAt
        };
    }
}