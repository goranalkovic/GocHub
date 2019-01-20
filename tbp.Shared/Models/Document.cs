using System;

namespace tbp.Shared.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public int RepoId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Contents { get; set; }
        public string Path { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }
    }
}
