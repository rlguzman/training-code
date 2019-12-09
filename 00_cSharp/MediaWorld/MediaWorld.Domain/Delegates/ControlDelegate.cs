using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Delegates
{
  //placeholder for a method with same signature
  public abstract class ControlDelegate 
  {
    public delegate bool ButtonDelegate();
    public delegate void ResultDelegate(AMedia media);
  }
}
