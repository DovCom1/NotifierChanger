namespace NotifierChanger.Model.Entities;

public class MessageEvent
{
    public long Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public long ChatId { get; set; }
    public required string  Message { get; set; }
    public required string SenderName { get; set; }
    public required string ReceiverName { get; set; }
    public required string ChatName { get; set; }
    public DateTime CreatedAt  { get; set; }
}