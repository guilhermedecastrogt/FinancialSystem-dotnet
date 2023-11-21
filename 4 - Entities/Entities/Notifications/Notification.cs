using System.ComponentModel.DataAnnotations.Schema;

namespace Entities._4___Entities.Entities.Notifications;

public class Notification
{
    public Notification()
    {
        Notifications = new List<Notification>();
    }
    
    [NotMapped] public string PriorityName { get; set; }
    [NotMapped] public string Message { get; set; }
    [NotMapped] public List<Notification> Notifications;
    
    public bool StringPropertyValidation(string value , string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
        {
            Notifications.Add(new Notification
            {
                Message = "Require Field",
                PriorityName = propertyName
            });
            return false;
        }
        return true;
    }
    
    public bool IntPropertyValidation(int value , string propertyName)
    {
        if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
        {
            Notifications.Add(new Notification
            {
                Message = "Require Field",
                PriorityName = propertyName
            });
            return false;
        }
        return true;
    }
}