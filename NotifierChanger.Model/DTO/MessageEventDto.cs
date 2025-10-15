namespace NotifierChanger.Model.Dto;

public record MessageEventDto(
    long SenderId,
    long ReceiverId,
    long ChatId,
    string Message,
    string SenderName,
    string ReceiverName,
    string ChatName,
    DateTime CreatedAt);