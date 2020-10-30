using CustomVisionService;
using LUIS;
using LUIS.Intents;
using Microsoft.AspNetCore.Mvc;
using SpeechService;
using System.IO;
using TranslatorService;

namespace VSSummit2020.Controllers
{
    public class RedirectIntentController : Controller
    {
        public IActionResult RedirectBySpeech()
        {
            var (languageHeard, textHeard) = SpeechToText.ListenOnce().Result;

            if (!languageHeard.Contains("pt"))
                textHeard = Translator.Translate(textHeard, languageHeard).Result;

            var intent = Prediction.Predict(textHeard).Result;

            return Redirect(intent);
        }

        public IActionResult RedirectByText(string query)
        {
            var intent = Prediction.Predict(query).Result;

            return Redirect(intent);
        }

        private IActionResult Redirect(IntentResult intent)
        {
            if (intent.IsEmpty)
                return RedirectToPage("/Index");

            if (intent.GoTo.ToLower().Contains("entrada"))
                return RedirectToPage("/Relatorios/Entrada", intent.Parameters);

            if (intent.GoTo.ToLower().Contains("saída"))
                return RedirectToPage("/Relatorios/Saida", intent.Parameters);

            return RedirectToPage("/Relatorios/Index", intent.Parameters);
        }

        public IActionResult RedirectByPicture(Stream stream)
        {
            var intent = ImageAnalysis.Analyze(stream).Result;

            return intent.Contains("casa")
                ? RedirectToPage("/Index")
                : null;
        }
    }
}
