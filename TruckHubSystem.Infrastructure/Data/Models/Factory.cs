using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Factory")]
    public class Factory
    {
        [Key]
        [Comment("Factory identifier")]
        public int Id {  get; set; }

        [Required]
        [MaxLength(FactoryNameMaxLength)]
        [Comment("Factory name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("City")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Comment("Creator identifier")]
        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public IdentityUser Creator { get; set; } = null!;
    }
}
