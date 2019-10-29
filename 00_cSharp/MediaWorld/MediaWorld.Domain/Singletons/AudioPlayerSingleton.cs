using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class AudioPlayerSingleton : IPlayer {

    private static readonly AudioPlayerSingleton _instance = new AudioPlayerSingleton();

    public static AudioPlayerSingleton Instance 
    {
      get {
        return _instance;
      }
    }

    private AudioPlayerSingleton() {}

    public void Execute(string command, AAudio audio)
    {
      Console.WriteLine(audio);
    }
  }
}
