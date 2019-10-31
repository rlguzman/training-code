using System.Collections.Generic;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Factories;
using MediaWorld.Domain.Models;

namespace MediaWorld.Storing.Repositories
{
  public class MediaRepository 
  {
    private List<AMedia> _mediaLibrary;
    public List<AMedia> MediaLibrary
    {
      get 
      {
        return  _mediaLibrary;
      }
    }
    public MediaRepository()
    {
      Initialize();
    }
    private List<AMedia> Initialize()
    {
      var audioFactory = new AudioFactory();
      var videoFactory = new VideoFactory();
      if (_mediaLibrary == null)
      {
        _mediaLibrary = new List<AMedia>();
        
        _mediaLibrary.AddRange(new AMedia[]
        {
          audioFactory.Create<Book>(),
          audioFactory.Create<Song>(),
          videoFactory.Create<Movie>(),
          videoFactory.Create<Photo>()
        });

        _mediaLibrary.Add(audioFactory.Create<Book>());
        _mediaLibrary.Add(audioFactory.Create<Book>());
        _mediaLibrary.Add(audioFactory.Create<Book>());
        _mediaLibrary.Add(audioFactory.Create<Book>());
      }
      return _mediaLibrary;
    }
  }
}
