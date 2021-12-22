using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Node
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string title { get; set; }
    }
}
