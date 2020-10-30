using LUIS.Intents;
using Newtonsoft.Json;
using System;

namespace LUIS
{
    internal class IntentResolver
    {
        private readonly string _topIntent;
        private readonly string _entities;

        public IntentResolver(string topIntent, string entities)
        {
            _topIntent = topIntent;
            _entities = entities;
        }

        public IntentResult Resolve()
        {
            if (!Enum.TryParse(_topIntent, true, out Intent topIntent))
                return IntentResult.Empty;

            switch (topIntent)
            {
                case Intent.VerRelatorio:
                    var verRelatorioIntent = JsonConvert.DeserializeObject<VerRelatorioIntent>(_entities);
                    return verRelatorioIntent.Convert();

                default:
                    return IntentResult.Empty;
            }
        }
    }
}