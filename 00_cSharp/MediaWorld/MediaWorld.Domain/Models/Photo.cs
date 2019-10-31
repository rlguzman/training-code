using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Photo : AVideo 
  {
    public Photo()
    {
      Initialize();
    }

    public Photo(string s){
      Initialize(s);
    }

    private void Initialize(string title="Unknown")
    {
      Title = title;
    }
  }
}
