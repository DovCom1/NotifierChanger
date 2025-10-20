namespace NotifierChanger.Model.Dto;

public record CallEventDto(
    long SenderId,
    long ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt);