using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeSongComposers.Models
{
    public class Artist
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
    }
}