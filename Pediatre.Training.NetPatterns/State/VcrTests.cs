using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.State
{
    [TestClass]
    public class VcrTests
    {
        [TestMethod]
        public void PlayWhenStopped_ShouldPlay()
        {
            // Arrange
            var sut = new Vcr();
            sut.Stop();

            // Act
            sut.Play();

            // Assert
            Assert.AreEqual(sut.PlayingState, sut.State);
        }

        [TestMethod]
        public void PlayWhenRecording_ShouldKeepRecording()
        {
            // Arrange
            var sut = new Vcr();
            sut.Record();

            // Act
            sut.Play();
        }

        [TestMethod]
        public void RecordWhenRecording_ShouldKeepRecording()
        {
            // Arrange
            var sut = new Vcr();
            sut.Record();

            // Act
            sut.Record();
            
            // Assert
            Assert.AreEqual(sut.RecordingState, sut.State);
        }


        [TestMethod]
        public void RecordWhenPlaying_ShouldKeepPlaying()
        {
            // Arrange
            var sut = new Vcr();
            sut.Play();

            // Act
            sut.Record();

            // Assert
            Assert.AreEqual(sut.PlayingState, sut.State);
        }
    }
}
