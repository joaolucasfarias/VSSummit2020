using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace VSSummit2020.Pages.Relatorios
{
    public class IndexModel : PageModel
    {
        public string StartDate { get; private set; }
        public string FinalDate { get; private set; }

        public void OnGet(DateTime startDate, DateTime finalDate)
        {
            if (startDate != DateTime.MinValue)
                StartDate = $"{startDate:yyyy-MM-dd}";

            if (finalDate != DateTime.MinValue)
                FinalDate = $"{finalDate:yyyy-MM-dd}";
        }
    }
}
