using System;

namespace Pediatre.Training.NetPatterns.State
{
    internal abstract class State
    {
        protected readonly Vcr Vcr;

        protected State(Vcr vcr)
        {
            if (vcr == null) throw new ArgumentNullException(nameof(vcr));
            Vcr = vcr;
        }

        public abstract State Play();
        public abstract State Stop();
        public abstract State Record();
    }
}