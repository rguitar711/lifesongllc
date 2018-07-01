using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LifeSongComposers.Models
{
    public class File
    {
        public Guid ID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public Guid TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}