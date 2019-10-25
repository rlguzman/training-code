namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton
  {
    private static readonly string _instance = "media player";

    private MediaPlayerSingleton() {}

    public static string GetInstance()
    {
      return _instance;
    }
  }
}
