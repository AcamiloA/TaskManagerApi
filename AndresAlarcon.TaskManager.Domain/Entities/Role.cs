using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndresAlarcon.TaskManager.Domain.Entities
{
    [Table("Role", Schema = DataConstants.SCHEMA)]
    public class Role : BaseEntity<int>
    {
        [Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("IsActive", TypeName = "bit")]
        public bool IsActive { get; set; }        
    }
}
