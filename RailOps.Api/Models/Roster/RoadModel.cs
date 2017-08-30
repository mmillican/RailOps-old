using System.ComponentModel.DataAnnotations;

namespace RailOps.Api.Models.Roster
{
    public class RoadModel
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
