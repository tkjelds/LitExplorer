using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iLit.Core
{
    public record EdgeDTO(int edgeID, int nodeFromID, int nodeToID);

    public record EdgeCreateDTO
    {
        [Required]
        public int nodeFromID { get; set; }

        [Required]
        public int nodeToID { get; set; }
    }
}
