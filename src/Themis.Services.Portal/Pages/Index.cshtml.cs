using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Themis.Services.Portal.Pages
{
    public class GdprModel : PageModel
    {
        private readonly IConfiguration configuration;

        public GdprModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [Required]
        [BindProperty]
        [EmailAddress]
        [DisplayName(displayName: "Email Address")]
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

            var triggerResponse = await TriggerDataConsolidation();

            if (triggerResponse.IsSuccessStatusCode)
            {
                return RedirectToPage(pageName: "/Gdpr/Consolidation/Started", routeValues: new {EmailAddress});
            }

            return RedirectToPage(pageName: "Error");
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            var authenticationHeader = configuration[key: "GDPR:DataConsolidation:AuthHeader"];
            var authenticationKey = configuration[key: "GDPR:DataConsolidation:AuthKey"];

            if (string.IsNullOrWhiteSpace(authenticationHeader) == false || string.IsNullOrWhiteSpace(authenticationKey) == false)
            {
                httpClient.DefaultRequestHeaders.Add(authenticationHeader, authenticationKey);
            }

            return httpClient;
        }

        private async Task<HttpResponseMessage> TriggerDataConsolidation()
        {
            var dataConsolidationApiBaseUrl = configuration[key: "GDPR:DataConsolidation:Url"];
            var dataConsolidationTriggerUrl = $"{dataConsolidationApiBaseUrl}/{EmailAddress}/data-consolidation/initiate";
            var requestContent = new StringContent(string.Empty);

            var httpClient = CreateHttpClient();
            return await httpClient.PostAsync(dataConsolidationTriggerUrl, requestContent);
        }
    }
}