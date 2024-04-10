using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id {  get; set; }

        [Required]
        [MaxLength(FactoryNameMaxLength)]
        [Comment("Factory name")]
        public string Name { get; set; } = string.Empty;


        public List<Load> LoadsSent = new List<Load>();
        public List<Load> LoadsReceived = new List<Load>();

    }
}
