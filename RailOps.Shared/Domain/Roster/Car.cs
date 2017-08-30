using System;
using System.Collections.Generic;
using System.Text;

namespace RailOps.Shared.Domain.Roster
{
    public class Car : RosterItem
    {
        public bool IsPassenger { get; set; }
        public bool IsHazardous { get; set; }

        public bool IsCaboose { get; set; }
        public bool IsFred { get; set; }
        public bool IsUtility { get; set; }

        public bool LoadGeneratedByStaging { get; set; }

        public int Wait { get; set; }

        // TODO: kernel / loadname
    }
}
