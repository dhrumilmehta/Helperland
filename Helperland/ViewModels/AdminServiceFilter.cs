namespace Helperland.ViewModels
{
    public class AdminServiceFilter
    {

        public int? ServiceRequestId { get; set; }

        public string CustomerName { get; set; }

        public string ServiceProviderName { get; set; }

        public int? Status { get; set; }


        public string FromDate { get; set; }

        public string ToDate { get; set; }

    }
}
