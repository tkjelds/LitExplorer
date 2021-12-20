using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iLit.Core
{
    public record NodeDTO(int id, string title);

    //probably won't need this? only thing node is given is a string. 
    public record NodeCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
