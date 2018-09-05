using StringToClass;
using System;

namespace Example
{
  public class A
  {
    public string a { get; set; }
    public string b { get; set; }
    public string c { get; set; }
    public string d { get; set; }
    public string e { get; set; }
  }
  class Program
  {
    static void Main(string[] args)
    {
      string input = "input";
      A inst = new A();
      new Mapper<A>(inst, input).Map(c => c.a, str => str.Substring(0, 1))
                                .Map(c => c.b, str => str.Substring(1, 1))
                                .Map(c => c.c, str => str.Substring(2, 1))
                                .Map(c => c.d, str => str.Substring(3, 1))
                                .Map(c => c.e, str => str.Substring(4, 1));

      Console.WriteLine(inst.a);
      Console.WriteLine(inst.b);
      Console.WriteLine(inst.c);
      Console.WriteLine(inst.d);
      Console.WriteLine(inst.e);
      Console.ReadKey();
    }
  }
}
