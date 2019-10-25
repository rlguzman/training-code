using System;
using MediaWorld.Domain.Models;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();

    private MediaPlayerSingleton() {}

    public static MediaPlayerSingleton GetInstance()
    {
      return _instance;
    }

    public void Play(Music m)
    {
      Console.WriteLine(m);
    }
  }
}
