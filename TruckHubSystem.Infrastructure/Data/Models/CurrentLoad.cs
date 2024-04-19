﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    public class CurrentLoad
    {
        [Key]
        [Comment("Load identifier")]
        public int Id { get; set; }

        [Required]
        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Factory Factory { get; set; } = null!;

        [Required]
        public int LoadId { get; set; }
        [ForeignKey(nameof(LoadId))]
        public Load Load { get; set; } = null!;
    }
}
