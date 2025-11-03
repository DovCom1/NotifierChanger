namespace NotifierChanger.Model.Dto;

public record MessageEventDto(
    Guid SenderId,
    Guid ReceiverId,
    long ChatId,
    string Message,
    string SenderName,
    string ReceiverName,
    string ChatName,
    DateTime CreatedAt) : IEventDto;