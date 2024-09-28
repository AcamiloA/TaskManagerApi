using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndresAlarcon.TaskManager.Domain.Entities
{
    [Table("Trace", Schema = DataConstants.SCHEMA)]
    public class Trace : BaseEntity<int>
    {
        [Column("BoardId", TypeName = "int")]
        [ForeignKey("Board")]
        public int BoardId { get; set; }

        public string LastState { get; set; }

        public string CurrentState { get; set; }

        [Column("CurrentAssignedTo", TypeName = "uniqueidentifier")]
        [ForeignKey("CurrentUser")]
        public Guid CurrentAssignedTo { get; set; }

        [Column("LastAssignedTo", TypeName = "uniqueidentifier")]
        [ForeignKey("LastUser")]
        public Guid? LastAssignedTo { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual Board Board { get; set; }
        public virtual User CurrentUser { get; set; }
        public virtual User? LastUser { get; set; }
    }
}
