namespace NotifierChanger.Model.Dto;

public record InviteEventDto(
    long SenderId,
    long ReceiverId,
    string SenderName,
    string ReceiverName,
    DateTime CreatedAt);