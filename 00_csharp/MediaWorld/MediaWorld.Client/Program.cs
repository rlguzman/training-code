using System;
using MediaWorld.Domain.Models;

namespace MediaWorld.Client
{
  /// <summary>
  /// contains the start point
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// starts the application
    /// </summary>
    private static void Main()
    {
      var helper = MediaSingleton.GetInstance();
      
      System.Console.WriteLine(helper);
    }
  }
}
