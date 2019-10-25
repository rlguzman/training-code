using System;
using MediaWorld.Domain.Models;
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
      Play();
    }

    private static void Play()
    {
      var mediaPlayer = MediaPlayerSingleton.GetInstance();
      Music song = new Song();
      Music audible = new Audible();

      mediaPlayer.Play(song); 
      mediaPlayer.Play(audible);
    }
  }
}
