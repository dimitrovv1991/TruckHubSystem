using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Load category")]
    public class LoadCategory
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(LoadCategoryNameMaxLength)]
        [Comment("Load category")]
        public string Name { get; set; } = string.Empty;

        public List<Load> Loads { get; set; } = new List<Load>();
    }
}
