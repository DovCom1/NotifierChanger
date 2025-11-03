namespace NotifierChanger.Model.Entities;

public class CallEvent
{
    public long Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public required string SenderName { get; set; }
    public required string ReceiverName { get; set; }
    public DateTime CreatedAt  { get; set; }
}