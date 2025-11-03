namespace NotifierChanger.Model.Storage;

public interface ISessionStorage
{
    Task<bool> isUserOnline(Guid userId);
}