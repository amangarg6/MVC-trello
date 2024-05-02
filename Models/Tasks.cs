using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTask.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("StatusId ")]
        public Status Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    }
}
