namespace NotifierChanger.Model.Dto;

public record MessageEventDto(
    int SenderId,
    int ReceiverId,
    long ChatId,
    string Message,
    string SenderName,
    string ReceiverName,
    string ChatName,
    DateTime CreatedAt);