using System;

namespace Pediatre.Training.NetPatterns.State
{
    internal class StoppedState : State
    {
        public StoppedState(Vcr vcr) : base(vcr){}
        public override State Play()
        {
            Console.Out.WriteLine("Start playing");
            return Vcr.PlayingState;
        }

        public override State Stop()
        {
            Console.Out.WriteLine("Stay stopped");
            return this;
        }

        public override State Record()
        {
            Console.Out.WriteLine("Start recording");
            return Vcr.RecordingState;
        }
    }
}