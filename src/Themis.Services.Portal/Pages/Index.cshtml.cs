using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Themis.Services.Portal.Models;

namespace Themis.Services.Portal.Pages
{
    public class GdprModel : PageModel
    {
        private readonly HttpClient _httpClient = new HttpClient();

        [Required]
        [BindProperty]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await TriggerDataConsolidation();

            return RedirectToPage("/Gdpr/Consolidation/Started", new {EmailAddress });
        }

        private async Task TriggerDataConsolidation()
        {
            var dataConsolidationApiUrl = Program.Configuration["GDPR:DataConsolidation:Url"];

            var dataConsolidationRequest = new DataConsolidationRequest
            {
                EmailAddress = EmailAddress
            };

            var rawDataConsolidationRequest = JsonConvert.SerializeObject(dataConsolidationRequest);
            var requestContent = new StringContent(rawDataConsolidationRequest);

            await _httpClient.PostAsync(dataConsolidationApiUrl, requestContent);
        }
    }
}