using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VSSummit2020.Controllers;

namespace VSSummit2020.Pages.Nav
{
    public class SpeechModel : PageModel
    {
        public bool Choose { get; private set; }
        public bool Auto { get; private set; }

        public void OnGet(bool choose, bool auto)
        {
            Choose = choose;
            Auto = auto;
        }

        public IActionResult OnPost()
        {
            return new RedirectIntentController().RedirectBySpeech();
        }
    }
}
