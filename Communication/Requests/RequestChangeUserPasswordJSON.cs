namespace MyFirstApi.Communication.Requests;

public class RequestChangeUserPasswordJSON
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
