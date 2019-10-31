using System;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Song : AAudio 
  {
    public Song()
    {
      Initialize();
    }
    // NO LONGER NEEDED BECAUSE WE HAVE A FACTORY 
    // public Song(string artist,string title, TimeSpan duration, int bitRate)
    // {
    //   Initialize(artist, title, duration, bitRate);
    // }

    private void Initialize(string artist="Unkown", string title="Unknown", TimeSpan duration=new TimeSpan(), int bitRate=32000)
    {
      Author=artist;
      Title=title;
      Duration=duration;
      BitRate=bitRate;
    }
  }
}
