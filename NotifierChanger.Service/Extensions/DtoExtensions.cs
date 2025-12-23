using System.Text.Json;
using NotifierChanger.Model.Dto;
using NotifierChanger.Model.Entities;
using static System.DateTime;
using static System.Guid;

namespace NotifierChanger.Service.Extensions;

public static class DtoExtensions
{
    public static MessageEvent ToMessageEvent(this EventDto dto)
    {
        Guid.TryParse(dto.AdditionalData["chatId"].GetString(), out var chatId);
        DateTime.TryParse(dto.AdditionalData["createdAt"].GetString(), out var createdAt);
        return new MessageEvent
        {
            SenderId = dto.SenderId,
            ReceiverId = dto.ReceiverId,
            ChatId = chatId,
            SenderName = dto.AdditionalData["senderName"].GetString(),
            ReceiverName = dto.AdditionalData["receiverName"].GetString(),
            ChatName = dto.AdditionalData["chatName"].GetString(),
            Message = dto.AdditionalData["message"].GetString(),
            CreatedAt = createdAt,
        };
    }
    
    public static InviteEvent ToInviteEvent(this EventDto dto)
    {
        DateTime.TryParse(dto.AdditionalData["createdAt"].GetString(), out var createdAt);
        return new InviteEvent
        {
            SenderId = dto.SenderId,
            ReceiverId = dto.ReceiverId,
            SenderName = dto.AdditionalData["senderName"].GetString(),
            ReceiverName = dto.AdditionalData["receiverName"].GetString(),
            CreatedAt = createdAt
        };
    }
}