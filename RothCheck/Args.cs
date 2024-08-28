using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RothCheck
{
  public class Args
  {
    public double Expenses { get; set; } = 50000;
    public double RateOfReturn { get; set; } = 0.065;
    public int Age { get; set; } = 49;
    public double Taxable { get; set; } = 123456;
    public double Roth { get; set; } = 234567;
    public double Conventional { get; set; } = 345678;
    public List<double> Rmd { get; set; } = new List<double>() { 27.4, 26.5, 25.5, 24.6, 23.7, 22.9, 22, 21.1, 20.2, 19.4, 18.5, 17.7, 16.8, 16, 15.2, 14.4, 13.7, 12.9, 12.2, 11.5, 10.8, 10.1, 9.5, 8.9, 8.4, 7.8, 7.3, 6 };
    public double Ss67 { get; set; } = 36000 * 0.7;
    public double Ss61 { get; set; } = 13000 * 0.7;
    public List<Bracket> Brackets { get; set; } = new List<Bracket> 
    {
      new Bracket(0, 23200, 0.1),
      new Bracket(23200, 94300, 0.12),
      new Bracket(94300, 201050, 0.22),
      new Bracket(201050, 383900, 0.24),
      new Bracket(383900, 487450, 0.32),
      new Bracket(487450, 731200, 0.35),
      new Bracket(731200, int.MaxValue, 0.37),
    };
    public double StateTax { get; set; } = 0.0305;
    public int StdDeduction { get; set; } = 29200;
    public int FillBracket { get;set; } = 0;
  }

  public class Bracket
  {
    [JsonConstructor]
    public Bracket(int low, int high, double rate) 
    {
      Low = low;
      High = high;
      Rate = rate;
    }
    public int Low { get; set; }
    public int High { get; set; }
    public double Rate { get; set; }
  }
}
