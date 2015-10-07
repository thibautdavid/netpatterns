using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.TemplateMethod
{
    [TestClass]
    public class RemoteControlTests
    {
        [TestMethod]
        public void ChooseChannelOneOnTv_Should_WriteMessageOnOutput()
        {
            var sut = new RemoteControl();
            sut.PointAt(new Tv());
            sut.TurnOnOff();
            sut.One();
        }

        [TestMethod]
        public void ChooseChannelOneOnCdPlayer_Should_WriteMessageOnOutput()
        {
            var sut = new RemoteControl();
            sut.PointAt(new CdPlayer());
            sut.TurnOnOff();
            sut.One();
        }
    }
}
