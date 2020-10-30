using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VSSummit2020.Pages.Relatorios
{
    public class EntradaModel : PageModel
    {
        public IList<RealInformation> RealInformations { get; private set; }
        public string StartDate { get; private set; }
        public string FinalDate { get; private set; }

        public EntradaModel()
        {
            RealInformations = RealInformation.GetRealInformation();
        }

        public void OnGet(DateTime startDate, DateTime finalDate)
        {
            if (startDate != DateTime.MinValue)
            {
                RealInformations = RealInformations.Where(i => i.Date >= startDate).ToList();
                StartDate = $"{startDate:yyyy-MM-dd}";
            }

            if (finalDate == DateTime.MinValue) return;

            RealInformations = RealInformations.Where(i => i.Date <= finalDate).ToList();
            FinalDate = $"{finalDate:yyyy-MM-dd}";
        }
    }
}
