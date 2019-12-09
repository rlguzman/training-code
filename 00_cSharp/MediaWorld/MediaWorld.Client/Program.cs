using MediaWorld.Domain.Singletons;
using MediaWorld.Storing.Repositories;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
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
  
    private static async Task Main()
    {
      // var program = new Program();
      // program.ApplicationStart();
      // Play();
      await MagicAsync();
      Console.WriteLine("End of Code");
      // Thread.Sleep(1000);
      // Log.Warning("end of Main Method");
    }

    private void ApplicationStart() 
    {
      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("log.txt")
        .CreateLogger();
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
      Log.Information("Play Method");
      var mediaPlayer = MediaPlayerSingleton.Instance;

      foreach(var item in _repository.MediaLibrary)
      {
        Log.Debug("{one} {second}", item.Title, item.Duration);
        mediaPlayer.Execute(item.Play, item);
      }

    }

    private static void MagicThread() 
    {
      var t1 = new Thread(() => { Run("A");});

      var t2 = new Thread(() => { Run("B"); });

      t1.Start();
      t2.Start();

      t1.Join();
      t2.Join();

    }

    private static void MagicTask() 
    {
      var t1 = new Task(() => { Run("A");});

      var t2 = new Task(() => { Run("B"); });

      t1.Start();
      t2.Start();

      Task.WaitAll(new Task[] {t1, t2}, 1000);



    }

    private static async Task MagicAsync()
    {
      await Task.Run(() => {Run("C");});
      await Task.Run(() => { Run("D");});
    }

    private static void Run(string s)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write(s);
        }
    }
    }
  }

