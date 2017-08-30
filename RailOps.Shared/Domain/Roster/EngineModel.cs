using System.ComponentModel.DataAnnotations;

namespace RailOps.Shared.Domain.Roster
{
    public class EngineModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
