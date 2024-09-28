using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndresAlarcon.TaskManager.Domain.Entities
{
    [Table("Board", Schema = DataConstants.SCHEMA)]
    public class Board : BaseEntity<int>
    {
        [Column("Title", TypeName = "varchar(250)")]
        public string Title { get; set; }

        [Column("Description", TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        [Column("DueDate", TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [Column("StatusId", TypeName = "varchar(20)")]
        [ForeignKey("Status")]
        public string StatusId { get; set; }

        [Column("PriorityId", TypeName = "varchar(20)")]
        [ForeignKey("Priority")]
        public string PriorityId { get; set; }

        [Column("AssignedTo", TypeName = "uniqueidentifier")]
        [ForeignKey("User")]
        public Guid AssignedTo { get; set; }

        [Column("IsActive", TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column("CreatedOn", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column("CreatedBy", TypeName = "uniqueidentifier")]
        [ForeignKey("Creator")]
        public Guid CreatedBy { get; set; }

        [Column("UpdatedOn", TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        [Column("UpdatedBy", TypeName = "uniqueidentifier")]
        [ForeignKey("Updater")]
        public Guid? UpdatedBy { get; set; }

        public virtual User Creator { get; set; }
        public virtual User Updater { get; set; }
        public virtual User User { get; set; } 
    }
}
