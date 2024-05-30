namespace BlazorWebApp.Data;

public class UserNotifyEmail
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = null!;
    public string NotifyEmail { get; set; } = null!;

}
