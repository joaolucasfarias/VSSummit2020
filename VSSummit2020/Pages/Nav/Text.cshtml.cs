using LUIS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VSSummit2020.Controllers;

namespace VSSummit2020.Pages.Nav
{
    public class TextModel : PageModel
    {
        public IActionResult OnPost(string query)
        {
            return new RedirectIntentController().RedirectByText(query);
        }
    }
}
