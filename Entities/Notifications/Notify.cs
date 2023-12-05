using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notify
    {

        public Notify()
        {
            notifications = new List<Notify>();
        }


        [NotMapped]
        public string PriorityName { get; set; }

        [NotMapped]
        public string message { get; set; }

        [NotMapped]
        public List<Notify> notifications;


        public bool PropertyStringValidate(string value, string priorityName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(priorityName))
            {
                notifications.Add(new Notify
                {
                    message = "Required field",
                    PriorityName = priorityName
                });

                return false;
            }

            return true;
        }


        public bool ValidarPropriedadeInt(int value, string priorityName)
        {

            if (value < 1 || string.IsNullOrWhiteSpace(priorityName))
            {
                notifications.Add(new Notify
                {
                    message = "Required field",
                    PriorityName = "PriorityName"
                });

                return false;
            }

            return true;

        }
    }
}
