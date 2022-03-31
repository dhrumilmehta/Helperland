
using Helperland.Models;

namespace Helperland.ViewModels
{
    public class AdminEditPopUp
    {
        public ServiceRequestAddress address { get; set; }

        public int ServiceRequestId { get; set; }

        public string Date { get; set; }

        public string StartTime { get; set; }

        public string WhyReschedule { get; set; }

        public string CallCenterNote { get; set; }
    }
}
