namespace NotifierChanger.Model.Dto;

public record CallEventDto(
    int SenderId,
    int ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt) : IEventDto;