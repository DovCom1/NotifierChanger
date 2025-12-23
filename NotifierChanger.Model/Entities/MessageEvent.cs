namespace NotifierChanger.Model.Entities;

public class MessageEvent
{
    public long Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public Guid ChatId { get; set; }
    public required string  Message { get; set; }
    public required string SenderName { get; set; }
    public required string ReceiverName { get; set; }
    public required string ChatName { get; set; }
    public DateTime CreatedAt  { get; set; }
}