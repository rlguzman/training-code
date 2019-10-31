using System;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Book : AAudio 
  {
    public int PageCount { get; set; }
    public Book()
    {
      Initialize();
    }

    public Book(string author, string title, TimeSpan duration, int pageCount, int bitRate=32000)
    {
      Initialize(author, title, duration, pageCount, bitRate);
    }

    private void Initialize(string author="Unknown", string title="Unknown", TimeSpan duration=new TimeSpan(),int pageCount=0, int bitRate=32000)
    {
      Author = author;
      Title = title;
      Duration = duration;
      PageCount = pageCount;
      BitRate = bitRate;
    }

  }
}
