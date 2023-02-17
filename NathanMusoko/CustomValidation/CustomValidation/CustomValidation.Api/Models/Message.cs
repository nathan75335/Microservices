namespace CustomValidation.Api.Models;

public class Message
{
    public Message(string messageError, bool isValid, string propertyName)
    {
        MessageError = messageError;
        IsValid = isValid;
        PropertyName = propertyName;
    }

    public string MessageError { get ; set; }
    public bool IsValid { get; set; }
    public string PropertyName { get; set; }
}
