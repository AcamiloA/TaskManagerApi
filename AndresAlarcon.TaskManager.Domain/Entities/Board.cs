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

        [Column("StatusId", TypeName = "int")]
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Column("PriorityId", TypeName = "int")]
        [ForeignKey("Priority")]
        public int PriorityId { get; set; }

        [Column("UserId", TypeName = "uniqueidentifier")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

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
        public virtual User User { get; set; } 
        public virtual Status Status { get; set; } 
        public virtual Priority Priority { get; set; } 
    }
}
