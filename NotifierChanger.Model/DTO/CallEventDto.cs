namespace NotifierChanger.Model.Dto;

public record CallEventDto(
    Guid SenderId,
    Guid ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt) : IEventDto;