using System;

namespace Pediatre.Training.NetPatterns.State
{
    internal class RecordingState : State
    {
        public RecordingState(Vcr vcr) : base(vcr){}
        public override State Play()
        {
            Console.Out.WriteLine("Keep recording");
            return this;
        }

        public override State Stop()
        {
            Console.Out.WriteLine("Stop recording");
            return Vcr.StoppedState;
        }

        public override State Record()
        {
            Console.Out.WriteLine("Keep recording");
            return this;
        }
    }
}