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

        [Column("CreatedOn", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column("CreatedBy", TypeName = "uniqueidentifier")]
        [ForeignKey("Creator")]
        public Guid CreatedBy { get; set; }

        [Column("UpdatedOn", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [Column("UpdatedBy", TypeName = "uniqueidentifier")]
        [ForeignKey("Updater")]
        public Guid UpdatedBy { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Updater { get; set; }
    }
}
