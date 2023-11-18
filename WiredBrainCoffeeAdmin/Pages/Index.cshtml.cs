
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Text.Json;

using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<SurveyItem> SurveyResults { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ParseSurveyJson();
        }

        private void ParseSurveyJson()
        {
            var rawJson = System.IO.File.ReadAllText("wwwroot/sampledata/survey.json");
            SurveyResults = JsonSerializer.Deserialize<List<SurveyItem>>(rawJson);
        }
    }
}