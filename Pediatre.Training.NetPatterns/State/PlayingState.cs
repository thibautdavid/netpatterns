using System;

namespace Pediatre.Training.NetPatterns.State
{
    internal class PlayingState : State
    {
        public PlayingState(Vcr vcr) : base(vcr){}

        public override State Play()
        {
            Console.Out.WriteLine("Keep playing");
            return this;
        }

        public override State Stop()
        {
            Console.Out.WriteLine("Stop playing");
            return Vcr.StoppedState;
        }

        public override State Record()
        {
            Console.Out.WriteLine("Keep playing");
            return this;
        }
    }
}