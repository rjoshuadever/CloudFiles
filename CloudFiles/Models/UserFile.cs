using System.ComponentModel.DataAnnotations;

namespace CloudFiles.Models
{
    public class UserFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string Version { get; set; }

        [MaxLength(255)]
        public int? PreviousVersionId { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
