using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace iLit.Core
{
    public record NodeDTO(int id, string title);

    public record NodeCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string title { get; set; }
    }
}
