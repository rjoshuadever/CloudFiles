namespace CloudFiles
{
    public class UserFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public byte[] Content { get; set; }
    }
}
