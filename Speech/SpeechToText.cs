using Microsoft.CognitiveServices.Speech;
using System;
using System.Threading.Tasks;

namespace SpeechService
{
    public static class SpeechToText
    {
        private static readonly string Key = Environment.GetEnvironmentVariable("speechKey", EnvironmentVariableTarget.User);
        private static readonly string Endpoint = Environment.GetEnvironmentVariable("speechEndpoint", EnvironmentVariableTarget.User);

        public static async Task<(string languageHeard, string textHeard)> ListenOnce()
        {
            var speechConfig = SpeechConfig.FromEndpoint(new Uri(Endpoint), Key);

            var autoDetectSourceLanguageConfig =
                AutoDetectSourceLanguageConfig.FromLanguages(
                    new [] { "en-US", "pt-br" });

            using var speechRecognizer = new SpeechRecognizer(speechConfig, autoDetectSourceLanguageConfig);
            var result = await speechRecognizer.RecognizeOnceAsync();

            var autoDetectSourceLanguageResult =
                AutoDetectSourceLanguageResult.FromResult(result);
            var detectedLanguage = autoDetectSourceLanguageResult.Language;

            return (detectedLanguage,
                result.Reason == ResultReason.RecognizedSpeech
                    ? result.Text
                    : string.Empty);
        }
    }
}
