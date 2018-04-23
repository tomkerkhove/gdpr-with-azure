using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Themis.Services.Portal.Pages.Gdpr.Consolidation
{
    public class ConsolidationStartedModel : PageModel
    {
        [Required]
        public string EmailAddress { get; set; }

        public void OnGet(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}