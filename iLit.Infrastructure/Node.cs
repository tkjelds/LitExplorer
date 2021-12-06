using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Node
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

    }
}
