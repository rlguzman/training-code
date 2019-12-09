using System;
using System.Threading;
using MediaWorld.Domain.Interfaces;
using static MediaWorld.Domain.Delegates.ControlDelegate;

namespace MediaWorld.Domain.Abstracts
{
  public abstract class AMedia : IControl
  {
    public AMedia(){}

    public int FrameRate { get; set; }

    public event ResultDelegate ResultEvent;
    public TimeSpan Duration { get; set; }
    public string Title { get; set; }

    public abstract bool Forward();

    public virtual bool Pause()
    {
      throw new System.NotImplementedException();
    }

    public virtual bool Play()
    {
      int count = 0;
      
      if (ResultEvent == null)
      {
        return false;
      }

      while(count < 10)
      {
        Thread.Sleep(0001);
        ResultEvent(this);
        count+=1;

      }
      return true;
    }

    public abstract bool Rewind();

    public bool Stop()
    {
      throw new System.NotImplementedException();
    }

    public override string ToString()
    {
      return $"this.Title";
    }
  }
}
