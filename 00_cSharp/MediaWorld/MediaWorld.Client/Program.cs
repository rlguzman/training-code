﻿using System;
using MediaWorld.Domain.Abstracts;
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
      var mediaPlayer = MediaPlayerSingleton.Instance;
      AMedia song = new Song();
      AMedia movie = new Movie();

      mediaPlayer.Execute("play", song); 
      mediaPlayer.Execute("play", movie);
    }
  }
}
