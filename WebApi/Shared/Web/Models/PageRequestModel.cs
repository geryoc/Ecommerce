using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Shared.Web.Requests
{
    public class PageRequestModel
    {
        [Range(0, int.MaxValue)]
        public int Skip { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int Take { get; set; } = 100;
    }
}
