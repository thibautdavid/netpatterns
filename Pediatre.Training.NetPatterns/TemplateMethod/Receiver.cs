namespace Pediatre.Training.NetPatterns.TemplateMethod
{
    public abstract class Receiver
    {
        public bool IsOn { get; set; }
        public int Channel { get; set; }
        public int Volume { get; set; }

        public void VolumeUp()
        {
            Volume++;
            Play();
        }

        public void TurnOnOff()
        {
            IsOn = !IsOn;
            Play();
        }

        public void One()
        {
            Channel = 1;
            Play();
        }

        protected abstract void Play();
    }
}