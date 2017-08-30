using System.ComponentModel.DataAnnotations.Schema;

namespace RailOps.Shared.Domain.Roster
{
    public class Engine : RosterItem
    {
        public int EngineModelId { get; set; }
        [ForeignKey("EngineModelId")]
        public virtual EngineModel EngineModel { get; set; }

        public int EngineTypeId { get; set; }
        [ForeignKey("EngineTypeId")]
        public virtual RollingStockType EngineType { get; set; }

        public int Horsepower { get; set; }
        public bool IsBUnit { get; set; }
    }
}
