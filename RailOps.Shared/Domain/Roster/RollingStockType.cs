using System.ComponentModel.DataAnnotations;

namespace RailOps.Shared.Domain.Roster
{
    public class RollingStockType
    {
        [Key]
        public int Id { get; set; }

        public RollingStockClass Class { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
    }

    public enum RollingStockClass
    {
        Engine = 1,
        Car = 5
    }
}
