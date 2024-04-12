

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Core.Models.Load;

namespace TruckHubSystem.Core.Models.Factory
{
    public class FactoryFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Factory Name")]
        public string Name { get; set; }

        public string Location { get; set; }

        [Comment("Creator identifier")]
        public string CreatorId { get; set; }

        [Display(Name = "Loads Sent")]
        public List<LoadFormModel> LoadsSent { get; set; }

        [Display(Name = "Loads Received")]
        public List<LoadFormModel> LoadsReceived { get; set; }

    }
}
