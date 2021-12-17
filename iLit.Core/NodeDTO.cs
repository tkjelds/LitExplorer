using System.ComponentModel.DataAnnotations;

namespace iLit.Core
{
    public record NodeDTO(int id, string title);

    public record NodeCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
