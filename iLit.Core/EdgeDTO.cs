using System.ComponentModel.DataAnnotations;

namespace iLit.Core
{
    public record EdgeDTO(int edgeID, int nodeFromID, int nodeToID);

    public record EdgeCreateDTO
    {
        [Required]
        public int nodeFromID { get; init; }

        [Required]
        public int nodeToID { get; init; }
    }
}
