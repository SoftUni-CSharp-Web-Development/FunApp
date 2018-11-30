using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Runtime.Data;

namespace FunApp.Services.MachineLearning
{
    public class JokesCategorizer : IJokesCategorizer
    {
        public string Categorize(string modelFile, string jokeContent)
        {
            var mlContext = new MLContext(seed: 0);
            ITransformer trainedModel;
            using (var stream = new FileStream(modelFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                trainedModel = mlContext.Model.Load(stream);
            }

            var predFunction = trainedModel.MakePredictionFunction<JokeModel, JokeModelPrediction>(mlContext);
            var prediction = predFunction.Predict(new JokeModel { Content = jokeContent });
            return prediction.Category;
        }
    }
}