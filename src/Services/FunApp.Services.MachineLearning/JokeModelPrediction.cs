using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Runtime.Data;

namespace FunApp.Services.MachineLearning
{
    internal class JokeModelPrediction
    {
        [ColumnName(DefaultColumnNames.PredictedLabel)]
        public string Category { get; set; }
    }
}
