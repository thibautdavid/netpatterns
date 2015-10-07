namespace Pediatre.Training.NetPatterns.TemplateMethod
{
    public class RemoteControl
    {
        private Receiver _receiver;

        public void PointAt(Receiver receiver)
        {
            _receiver = receiver;
        }

        public void TurnOnOff()
        {
            _receiver.TurnOnOff();
        }

        public void One()
        {
            _receiver.One();
        }

        public void VoumeUp()
        {
            _receiver.VolumeUp();
        }
    }
}