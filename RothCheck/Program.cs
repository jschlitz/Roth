using System.Text.Json;

namespace RothCheck
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var theArgs = new Args();

      var jso = new JsonSerializerOptions() { WriteIndented= true};
      
      File.WriteAllText("Args.json", JsonSerializer.Serialize(theArgs, jso));
    }
  }
}