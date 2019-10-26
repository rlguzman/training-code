using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton : IPlayer
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();

    private MediaPlayerSingleton() {}

    public static MediaPlayerSingleton GetInstance()
    {
      return _instance;
    }

    public void Play(AMedia m)
    {
      Console.WriteLine(m);
    }
  }
}
