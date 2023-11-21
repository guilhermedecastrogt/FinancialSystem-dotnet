using System.ComponentModel.DataAnnotations;
using Entities._4___Entities.Entities.Notifications;

namespace Entities._4___Entities.Entities.Entities;

public class Base : Notification
{
    [Display(Name = "Key")]
    public int Id { get; set; }
    
    [Display(Name = "Name")]
    public string Name { get; set; }
}