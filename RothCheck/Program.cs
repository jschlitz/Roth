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

      //first year just just recapitulate, essentially.
      //foreach year...
      //if we are in RMDland, take that, note taxes
      //if we aren't, or in the odd case that the RMD < expenses...
      //take out of taxable, if we can. Ignore capital gains tax for the moment
      //if not, take from conventional, accounting for taxes
      //if not, take from roth, with no taxes

      //TODO: Actually fill up the roth buckets, but first let's just get as far as the spreadsheet.

      foreach (var b in theArgs.Brackets)
      { 
        Console.WriteLine($"{b.Low+1000+theArgs.StdDeduction} - {GetTaxes(b.Low+1000+theArgs.StdDeduction, theArgs):f2}");
      }
      Console.ReadKey();
    }

    private static double GetTaxes(double income, Args arg)
    {
      //TODO: is SS taxed at a different rate? do I care for this application?

      var ti = income - arg.StdDeduction;
      var result = ti * arg.StateTax;

      //since I put these in order...
      foreach (var b in arg.Brackets)
      {
        if (b.High < ti)
        {
          result += (b.High - b.Low) * b.Rate;
        }
        else 
        {
          result += (ti - b.Low) * b.Rate;
          break;
        }
      }

      return result;
    }
  }
}