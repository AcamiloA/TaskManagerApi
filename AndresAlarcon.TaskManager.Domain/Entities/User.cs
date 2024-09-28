using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Domain.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndresAlarcon.TaskManager.Domain.Entities
{
    [Table("User", Schema = DataConstants.SCHEMA)]
    public class User : BaseEntity<Guid>
    {
        [Column("Username", TypeName = "varchar(250)")]
        public string Username { get; set; }

        [Column("Email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column("PasswordHash", TypeName = "varchar(250)")]
        public string PasswordHash { get; set; }

        [Column("RoleId", TypeName = "int")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Column("IsActive", TypeName = "bit")]
        public bool IsActive { get; set; }

        [Column("CreatedOn", TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column("UpdatedOn", TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        public virtual Role Role { get; set; } 

    }
}
