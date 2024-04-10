using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Attributes
{
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(int YearManifacturedMin)
            :base(YearManifacturedMin,DateTime.Now.Year)
        {
            
        }
    }
}
