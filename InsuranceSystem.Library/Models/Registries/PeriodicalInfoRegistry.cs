using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceSystem.Library.Models.Registries
{
    public abstract class PeriodicalInfoRegistry
    {
        [Key,Column(Order = 0)]
        public DateTime Period { get; set; }
        public bool IsActive { get; set; }


    }
}
