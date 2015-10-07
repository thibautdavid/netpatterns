namespace Pediatre.Training.NetPatterns.State
{
    class Vcr
    {
        internal State StoppedState { get; }
        internal State PlayingState { get; }
        internal State RecordingState { get; }
        internal State State;

        public Vcr()
        {
            StoppedState = new StoppedState(this);
            PlayingState = new PlayingState(this);
            RecordingState = new RecordingState(this);
            State = StoppedState;
        }

        public void Play()
        {
            State = State.Play();
        }

        public void Stop()
        {
            State = State.Stop();
        }

        public void Record()
        {
            State = State.Record();
        }
    }
}
