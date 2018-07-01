using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeSongComposers.Models
{
    public class Track
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Composer { get; set; }
        public string Mood { get; set; }
        public string Path { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ArchiveDate { get; set; }
        public string FileName { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}