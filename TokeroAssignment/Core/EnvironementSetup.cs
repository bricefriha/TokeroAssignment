using Newtonsoft.Json;
using System.Reflection;

namespace TokeroAssignment.Core;

public static class EnvironementSetup
{
    /// <summary>
    /// Setup to automatically fillup the environement variables for the Debug setup
    /// </summary>
    public static void DebugSetup()
    {
        string jsonString;
        string jsonFileName = "AppSettings.json";
        var assembly = Assembly.GetExecutingAssembly();
        var s = $"{assembly.GetName().Name}.Config.{jsonFileName}";//C:\Users\Brice\source\repos\TokeroAssignment\TokeroAssignment\Config\Config.json
        Stream stream = assembly!.GetManifestResourceStream($"{assembly.GetName().Name}.Config.{jsonFileName}");
        using (var reader = new System.IO.StreamReader(stream))
        {
            jsonString = reader.ReadToEnd();
        }

        foreach (var item in JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString))
        {
            Environment.SetEnvironmentVariable(item.Key, item.Value);
        }

    }
}
