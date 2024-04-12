using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Core.Models.Load;

namespace TruckHubSystem.Core.Models.Factory
{
    public class FactoryDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Factory Name")]
        public string Name { get; set; }

        public string Location { get; set; }

        [Display(Name = "Loads Sent Count")]
        public int LoadsSent { get; set; }

        [Display(Name = "Loads Received Count")]
        public int LoadsReceived { get; set; }

        [Display(Name = "Loads Received Count")]
        public int CurrentLoads { get; set; }

        public string CreatorId { get; set; }
    }
}
