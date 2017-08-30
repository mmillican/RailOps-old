using System.ComponentModel.DataAnnotations;

namespace RailOps.Shared.Domain.Roster
{
    public class Road
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
