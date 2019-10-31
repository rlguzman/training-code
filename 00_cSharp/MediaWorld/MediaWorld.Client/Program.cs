using MediaWorld.Domain.Singletons;
using MediaWorld.Storing.Repositories;
using System;
// using MediaWorld.Domain.Abstracts;
// using MediaWorld.Domain.Factories;
// using MediaWorld.Domain.Models;

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
    private static MediaRepository _repository = new MediaRepository();
  
    private static void Main()
    {
      Play();
    }

    private static void Play()
    {
      //DONT NEED BECAUSE WE IMPORTED REPOS FROM STORING 
      // var mediaPlayer = MediaPlayerSingleton.Instance;
      // var audioFactory = new AudioFactory();
      // AMedia song = audioFactory.Create<Song>();
      // AMedia movie = new Movie();
      // mediaPlayer.Execute("play", song); 
      // mediaPlayer.Execute("play", movie);

      var mediaPlayer = MediaPlayerSingleton.Instance;

      foreach(var item in _repository.MediaLibrary)
      {
        mediaPlayer.Execute(item.Play);
      }

    }
  }
}
