using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVisionService
{
    public static class ImageAnalysis
    {
        private static readonly Guid ProjectId =
            new Guid(Environment.GetEnvironmentVariable("customVisionProjectId", EnvironmentVariableTarget.User));

        private static readonly string PredictionKey = Environment.GetEnvironmentVariable("customVisionPredictionKey", EnvironmentVariableTarget.User);
        private static readonly string TrainingKey = Environment.GetEnvironmentVariable("customVisionTrainingKey", EnvironmentVariableTarget.User);

        private static readonly string Endpoint = Environment.GetEnvironmentVariable("customVisionEndpoint", EnvironmentVariableTarget.User);

        public static async Task<string> Analyze(Stream image)
        {
            var trainingClient = new CustomVisionTrainingClient(
                new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.ApiKeyServiceClientCredentials(
                    TrainingKey))
            {
                Endpoint = Endpoint
            };

            var lastPublishedName =
                trainingClient
                    .GetIterationsAsync(ProjectId)
                    .Result
                    .OrderByDescending(i => i.Created)
                    .FirstOrDefault(i => !string.IsNullOrWhiteSpace(i.PublishName))?.PublishName;

            var predictionClientlient = new CustomVisionPredictionClient(
                new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.ApiKeyServiceClientCredentials(
                    PredictionKey))
            {
                Endpoint = Endpoint
            };

            var result = await predictionClientlient.ClassifyImageAsync(ProjectId, lastPublishedName, image);

            return result.Predictions.OrderByDescending(p => p.Probability).FirstOrDefault()?.TagName;
        }
    }
}
