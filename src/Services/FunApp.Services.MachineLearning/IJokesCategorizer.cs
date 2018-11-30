namespace FunApp.Services.MachineLearning
{
    public interface IJokesCategorizer
    {
        string Categorize(string modelFile, string jokeContent);
    }
}
