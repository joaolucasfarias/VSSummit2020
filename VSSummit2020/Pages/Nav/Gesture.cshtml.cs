using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using VSSummit2020.Controllers;

namespace VSSummit2020.Pages.Nav
{
    public class GestureModel : PageModel
    {
        public IActionResult OnPost(string pictureBase64)
        {
            var parts = pictureBase64.Split(',');
            var lastIndex = parts.Length - 1;
            var byteArray = Convert.FromBase64String(parts[lastIndex]);
            var stream = new MemoryStream(byteArray);

            return new RedirectIntentController().RedirectByPicture(stream);
        }
    }
}
