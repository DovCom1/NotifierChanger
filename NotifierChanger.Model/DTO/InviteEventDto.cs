namespace NotifierChanger.Model.Dto;

public record InviteEventDto(
    int SenderId,
    int ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt) : IEventDto;