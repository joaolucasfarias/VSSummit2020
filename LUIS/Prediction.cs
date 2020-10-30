using LUIS.Intents;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace LUIS
{
    public static class Prediction
    {
        private static readonly string PredictionKey = Environment.GetEnvironmentVariable("predictionKey", EnvironmentVariableTarget.User);
        private static readonly string PredictionResourceName = Environment.GetEnvironmentVariable("predictionResourceName", EnvironmentVariableTarget.User);
        private static readonly string PredictionEndpoint = $"https://{PredictionResourceName}.cognitiveservices.azure.com/";
        private static readonly Guid AppId = new Guid(Environment.GetEnvironmentVariable("appId", EnvironmentVariableTarget.User));

        public static async Task<IntentResult> Predict(string query)
        {
            var credentials = new ApiKeyServiceClientCredentials(PredictionKey);
            var runtimeClient = new LUISRuntimeClient(credentials) { Endpoint = PredictionEndpoint };

            var request = new PredictionRequest { Query = query };
            var prediction =
                await runtimeClient.Prediction.GetSlotPredictionAsync(AppId, "production", request, false, log: true);

            var entities = JsonConvert.SerializeObject(prediction.Prediction.Entities);
            return new IntentResolver(prediction.Prediction.TopIntent, entities).Resolve();
        }
    }
}