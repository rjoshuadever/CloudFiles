namespace CloudFiles.Models
{
    public class UserFileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public int PreviousVersionId { get; set; }
        public string Content { get; set; }
    }
}
