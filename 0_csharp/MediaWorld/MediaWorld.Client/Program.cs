using System;
using MediaWorld.Domain.Singletons;

namespace MediaWorld.Client
{
  /// <summary>
  /// contains the starting method
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// starts the application
    /// </summary>
    private static void Main()
    {
      var mediaPlayer = MediaPlayerSingleton.GetInstance();
      
      Console.WriteLine(mediaPlayer);
    }
  }
}
