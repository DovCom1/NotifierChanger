namespace NotifierChanger.Model.Entities;

public class CallEvent
{
    public long Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public required string SenderName { get; set; }
    public required string ReceiverName { get; set; }
    public DateTime CreatedAt  { get; set; }
}