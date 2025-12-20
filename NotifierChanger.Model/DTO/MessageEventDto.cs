namespace NotifierChanger.Model.Dto;

public record MessageEventDto() : IEventDto
{
    public Guid SenderId { get; init; }
    public Guid ReceiverId { get; init; }
    public Guid ChatId { get; init; }
    public required string Message { get; init; }
    public required string SenderName { get; init; }
    public required string ReceiverName { get; init; }
    public required string ChatName { get; init; }
    public DateTime CreatedAt { get; init; }
}
