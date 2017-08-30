using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailOps.Shared.Domain.Roster
{
    public abstract class RosterItem
    {
        [Key]
        public string Id { get; set; }


        public int RoadId { get; set; }
        [ForeignKey("RoadId")]
        public virtual Road Road { get; set; }

        [Required, MaxLength(10)]
        public string RoadNumber { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual RollingStockType Type { get; set; }

        public int Length { get; set; }

        public int? Weight { get; set; }
        public int? WeightTons { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int MoveCount { get; set; }

        public bool IsOutOfService { get; set; }
        public bool IsLocationUnknown { get; set; }

        [MaxLength(10)]
        public string Built { get; set; }
        [MaxLength(50)]
        public string Owner { get; set; }

        public DateTime LastDate { get; set; }

        // TODO: tracks/locations/routes
    }
}