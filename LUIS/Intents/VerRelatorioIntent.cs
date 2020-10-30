using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LUIS.Intents
{
    internal class VerRelatorioIntent : IIntentConverter
    {
        [JsonProperty("RelatorioPeriodo")]
        public List<RelatorioPeriodo> RelatorioPeriodo { get; set; }

        [JsonProperty("datetimeV2")]
        public List<DatetimeV2> DateTime { get; set; }

        public IntentResult Convert()
        {
            var goTo = RelatorioPeriodo?.FirstOrDefault()?.Relatório.FirstOrDefault()?.Tipo.FirstOrDefault() ?? string.Empty;

            if (DateTime.Count == 0)
                return new IntentResult(goTo, new { });

            if (DateTime.Count == 1)
            {
                var timex = DateTime.First().Values.First().Timex;
                var date1 = DateTime.First().Values.First().Resolution.First().Value;
                if (timex.StartsWith("XXXX-XX") || !timex.Contains("X"))
                    return new IntentResult(goTo, new { startDate = date1 });

                var date2 = DateTime.First().Values.First().Resolution.Last().Value;

                return new IntentResult(goTo, new { startDate = date1, finalDate = date2 });
            }

            var startDate = DateTime.First().Values.First().Resolution.First().Value;
            var finalDate = DateTime.Last().Values.First().Resolution.First().Value;

            return new IntentResult(goTo, new { startDate, finalDate });
        }
    }

    internal class RelatorioPeriodo
    {
        [JsonProperty("Relatório")]
        public List<Relatório> Relatório { get; set; }
    }

    internal class Relatório
    {
        [JsonProperty("Tipo")]
        public List<string> Tipo { get; set; }
    }

    internal class DatetimeV2
    {
        [JsonProperty("values")]
        public List<Value> Values { get; set; }
    }

    internal class Value
    {
        [JsonProperty("timex")]
        public string Timex { get; set; }

        [JsonProperty("resolution")]
        public List<Resolution> Resolution { get; set; }
    }

    internal class Resolution
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
