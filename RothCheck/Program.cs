using System.Text.Json;

namespace RothCheck
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var theArgs =
        JsonSerializer.Deserialize<Args>(File.ReadAllText("Args.json"));
      //var jso = new JsonSerializerOptions() { WriteIndented= true };
      //File.WriteAllText("Args2.json", JsonSerializer.Serialize(theArgs, jso));
    }
  }
}