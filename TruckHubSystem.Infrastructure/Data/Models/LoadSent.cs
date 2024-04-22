using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    public class LoadSent
    {
        [Key]
        [Comment("Load identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Sending factory identifier")]
        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Factory Factory { get; set; } = null!;

        [Required]
        [Comment("Load identifier")]
        public int LoadId { get; set; }
        [ForeignKey(nameof(LoadId))]
        public Load Load { get; set; } = null!;
    }
}
