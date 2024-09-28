using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndresAlarcon.TaskManager.Domain.Entities
{
    public class Priority
    {
        public const string HIGH = "High";
        public const string MEDIUM = "Medium";
        public const string LOW = "Low";        
    }
}
