namespace NotifierChanger.Model.Request;

public class RequestPath
{
    public static string Base { get; } = "/api/notification/send";
    public static string SendMessage { get; } =  Base + "message";
    public static string CallEvent { get; } =  Base + "call";
    public static string InviteEvent { get; } = Base + "invite";
    
}