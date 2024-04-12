using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckHubSystem.Core.Models.Load
{
    public class LoadReceivedFormModel
    {
        [Display(Name = "Factory")]
        public int FactoryId { get; set; }

        [Display(Name = "Load")]
        public int LoadId { get; set; }
    }
}
