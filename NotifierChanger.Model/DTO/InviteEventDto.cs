namespace NotifierChanger.Model.Dto;

public record InviteEventDto(
    string TypeDto,
    Guid SenderId,
    Guid ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt) : IEventDto;