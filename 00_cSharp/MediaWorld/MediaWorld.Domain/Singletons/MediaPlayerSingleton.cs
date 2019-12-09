using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;
using static MediaWorld.Domain.Delegates.ControlDelegate;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton : IPlayer
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();

    public static MediaPlayerSingleton Instance
    {
      get
      {
        return _instance;
      }
    }

    private MediaPlayerSingleton() {}

    public bool Execute(ButtonDelegate button, AMedia media)
    {
      media.ResultEvent += ResultHandler;
      return button();
    }
    public void ResultHandler(AMedia media)
    {
      System.Console.WriteLine("{0} is playing..", media.Title);
    }
    public bool PowerUp()
    {
      throw new NotImplementedException();
    }

    public bool PowerDown()
    {
      throw new NotImplementedException();
    }

    public bool VolumeUp()
    {
      throw new NotImplementedException();
    }

    public bool VolumeDown()
    {
      throw new NotImplementedException();
    }

    public bool VolumeMute()
    {
      throw new NotImplementedException();
    }
  }
}
