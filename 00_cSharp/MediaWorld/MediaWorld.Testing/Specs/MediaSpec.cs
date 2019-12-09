using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Factories;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Singletons;
using Moq;
using Xunit;

namespace MediaWorld.Testing.Specs
{
  public class MediaSpec 
  {
    AudioFactory af = new AudioFactory();
    VideoFactory vf = new VideoFactory();

    Mock<AMedia> mock;

    public MediaSpec()
    {
      mock = new Mock<AMedia>();
      mock.Setup(am => am.Play()).Returns(false);
    }

    [Fact]
    public void Test_AudioObject()
    {
      // arrange
      var sut = af;
      var expected = typeof(Song);

      // act
      var actual = af.Create<Song>();

      // assert
      Assert.True(expected == actual.GetType());
      
    }

    [Fact]
    public void Test_VideoPlay()
    {
      var sut = MediaPlayerSingleton.Instance;
      var mm = mock.Object;

      Assert.False(sut.Execute(mm.Play, mm));
    }
  }
}
